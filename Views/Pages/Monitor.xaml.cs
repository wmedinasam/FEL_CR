using FELRD.Helpers;
using FELRD.Models;
using ServiceCore.Infile.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Threading;
using WIS_Security;

namespace FELRD.Views.Pages
{
    public partial class Monitor : Page, INotifyPropertyChanged
    {
        #region Campos y propiedades principales


        public int _sync = 10;
        public int Sync
        {
            get => _sync;
            set => _sync = value <= 0 ? 10 : value;
        }

        private DispatcherTimer dispatcherTimer = new DispatcherTimer();
        private bool isMonitorActive = false;
        private bool isProcessing = false;
        private CancellationTokenSource cancellationTokenSource;

        public ObservableCollection<TransactionModel> TransactionsSuccess { get; set; } = new ObservableCollection<TransactionModel>();
        public ObservableCollection<TransactionModel> TransactionsRejected { get; set; } = new ObservableCollection<TransactionModel>();

        public bool canUserSign = false;
        private readonly TransactionModel transactionModel = new TransactionModel();
        private ResponseModel<List<TransactionModel>> transactionsResponse = new ResponseModel<List<TransactionModel>>();

        public static Monitor Instance { get; private set; }

        private int _rejectedCount;
        public int RejectedCount
        {
            get => _rejectedCount;
            set { _rejectedCount = value; OnPropertyChanged(nameof(RejectedCount)); }
        }

        private int _acceptedCount;
        public int AcceptedCount
        {
            get => _acceptedCount;
            set { _acceptedCount = value; OnPropertyChanged(nameof(AcceptedCount)); }
        }

        #endregion

        #region Estado visual del monitor (Conectado, Cargando, Desconectado)

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        private bool _isLoading;
        public bool IsLoading
        {
            get => _isLoading;
            set { _isLoading = value; OnPropertyChanged(nameof(IsLoading)); }
        }

        private string _stateText = "Desconectado";
        public string StateText
        {
            get => _stateText;
            set { _stateText = value; OnPropertyChanged(nameof(StateText)); }
        }

        private string _iconType = "CloseCircleOutline";
        public string IconType
        {
            get => _iconType;
            set { _iconType = value; OnPropertyChanged(nameof(IconType)); }
        }

        private string _lastUpdated;
        public string LastUpdated
        {
            get => _lastUpdated;
            set
            {
                _lastUpdated = value;
                OnPropertyChanged(nameof(LastUpdated));
                Application.Current.Dispatcher.Invoke(() =>
                {
                    var tb = FindName("txtLastUpdated") as TextBlock;
                    if (tb != null)
                    {
                        var anim = new DoubleAnimation(1, 1.5, TimeSpan.FromMilliseconds(500))
                        {
                            AutoReverse = true,
                            EasingFunction = new SineEase()
                        };
                        tb.RenderTransform = new ScaleTransform(1, 1.75);
                        tb.RenderTransformOrigin = new Point(0.5, 0.5);
                        tb.RenderTransform.BeginAnimation(ScaleTransform.ScaleXProperty, anim);
                        tb.RenderTransform.BeginAnimation(ScaleTransform.ScaleYProperty, anim);
                    }
                });
            }
        }

        public SolidColorBrush CardColor { get; set; }
        public SolidColorBrush IconColor { get; set; }
        public SolidColorBrush TextColor { get; set; }

        private void ShowConnected()
        {
            IsLoading = false;
            StateText = "Conectado";
            IconType = "CheckCircleOutline";

            SetColors("#294B3D", "#81F1B0", "#CFFFE4");
        }

        private void ShowDisconnected()
        {
            IsLoading = false;
            StateText = "Desconectado";
            IconType = "CloseCircleOutline";

            SetColors("#432E2E", "#FF9A9A", "#FFD6D6");
            TransactionsSuccess.Clear();
            TransactionsRejected.Clear();
            ShutDownProcess();
        }

        private void ShowConnecting()
        {
            StateText = "Conectando...";
            IconType = "Loading";
            SetColors("#2F3A52", "#88B0FF", "#D8E4FF");
        }

        private void SetColors(string background, string icon, string text)
        {
            AnimateCardColor((Color)ColorConverter.ConvertFromString(background));
            IconColor = (SolidColorBrush)new BrushConverter().ConvertFromString(icon);
            TextColor = (SolidColorBrush)new BrushConverter().ConvertFromString(text);

            iconState.Foreground = IconColor;
            txtState.Foreground = TextColor;
        }

        private void AnimateCardColor(Color toColor)
        {
            var baseColor = (cardEstado.Background as SolidColorBrush)?.Color ?? Colors.Transparent;
            var brush = new SolidColorBrush(baseColor);

            cardEstado.Background = brush;

            var animation = new ColorAnimation
            {
                To = toColor,
                Duration = TimeSpan.FromMilliseconds(300),
                EasingFunction = new QuadraticEase { EasingMode = EasingMode.EaseInOut }
            };

            brush.BeginAnimation(SolidColorBrush.ColorProperty, animation);
        }

        /// <summary>
        /// Función encargada de obtener las transacciones procesadas y pendientes
        /// </summary>
        /// <returns></returns>
        private async Task GetTransactionsAsync()
        {
            transactionsResponse = await Task.Run(() => transactionModel.GetProcessed());

            if (canUserSign)
            {
                var pendings = await Task.Run(() => TransactionMethods.GetPendings());
                if (!pendings.Success)
                {
                    HandleLogs.SaveLog("Debug", $"obtuve pendientes? resultado = {pendings.Object.Count} {pendings.Message}");
                    return;
                }
                try
                {                   
                    foreach (var pending in pendings.Object)
                    {
                        await Task.Run(() => TransactionMethods.Sign(pending));
                    }
                }
                catch (Exception ex)
                {
                    HandleLogs.SaveLog("Debug", "Problemas al firmar documento: " + ex.Message);
                }
            }
            else
            {
                HandleLogs.SaveLog("Debug", "No se pudo obtener transacciones pendientes: " + transactionsResponse.Message);
            }
        }

        /// <summary>
        /// Función que obtiene por primera vez las transacciones procesadas y pendientes 
        /// </summary>
        /// <returns></returns>
        private async Task GetTransactionsFirstTimeAsync()
        {
            IsLoading = true;
            ShowConnecting();

            await GetTransactionsAsync();

            Application.Current.Dispatcher.Invoke(() =>
            {
                if (transactionsResponse.Success)
                {
                    IsLoading = false;
                    ShowConnected();
                    LoadTransactionsOnScreen();
                    StartProcess();
                }
                else
                {
                    IsLoading = false;
                    ShowDisconnected();
                    MessageBox.Show(transactionsResponse.Message, "Error del sistema", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            });
        }

        private void GetTransactionsAfterAction()
        {
            transactionsResponse = transactionModel.GetProcessed();

            if (transactionsResponse.Success)
                LoadTransactionsOnScreen();
            else
            {
                ShowDisconnected();
                MessageBox.Show(transactionsResponse.Message, "Error del sistema", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void LoadTransactionsOnScreen()
        {
            TransactionsSuccess.Clear();
            TransactionsRejected.Clear();

            foreach (var tx in transactionsResponse.Object)
            {
                if (tx.Status == "ACEPTADO")
                    TransactionsSuccess.Add(tx);
                else if (tx.Status == "RECHAZADO" || tx.Status == "PROCESANDO")
                    TransactionsRejected.Add(tx);
            }
            AcceptedCount = TransactionsSuccess.Count;
            RejectedCount = TransactionsRejected.Count;
            LastUpdated = DateTime.Now.ToString("HH:mm:ss");
            Application.Current.Dispatcher.Invoke(async () =>
            {
                await Task.Delay(150);
                Home.Instance?.AnimateAllDashboardCards();
            });
        }

        private void StartProcess()
        {
            dispatcherTimer.Stop();
            dispatcherTimer.Tick -= CrearHilo;
            dispatcherTimer.Tick += CrearHilo;
            dispatcherTimer.Interval = TimeSpan.FromSeconds(Sync);
            dispatcherTimer.Start();
        }

        private async void CrearHilo(object sender, EventArgs e)
        {
            if (isProcessing || !isMonitorActive)
                return;

            isProcessing = true;
            cancellationTokenSource = new CancellationTokenSource();
            var token = cancellationTokenSource.Token;

            try
            {
                await GetTransactionsAsync();

                if (isMonitorActive && !token.IsCancellationRequested)
                {
                    Application.Current.Dispatcher.Invoke(LoadTransactionsOnScreen);
                }
            }
            catch (OperationCanceledException) { }
            finally
            {
                isProcessing = false;
            }
        }

        private void ShutDownProcess()
        {
            dispatcherTimer?.Stop();
            cancellationTokenSource?.Cancel();
            cancellationTokenSource?.Dispose();
            cancellationTokenSource = null;
            isProcessing = false;
        }

        #endregion

        #region Eventos de UI

        public Monitor()
        {
            InitializeComponent();
            Instance = this;
            this.DataContext = this;
            LastUpdated = "Sin sincronizar";
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            ShowDisconnected();
        }

        private async void btnIniciar_Click(object sender, RoutedEventArgs e)
        {
            if (btnIniciar.IsChecked == true)
            {
                isMonitorActive = true;
                await GetTransactionsFirstTimeAsync();
            }
            else
            {
                isMonitorActive = false;
                ShutDownProcess();
                ShowDisconnected();
            }
        }

        private void btnRetry_Click(object sender, RoutedEventArgs e)
        {
            var model = (sender as Button)?.DataContext as TransactionModel;
            if (model == null) return;

            model.Status = "PENDIENTE";
            model.Result = string.Empty;
            model.ActionTransaction("ChangeStatusResult", model);
            GetTransactionsAfterAction();
        }

        private void btnError_Click(object sender, RoutedEventArgs e)
        {
            var model = (sender as Button)?.DataContext as TransactionModel;
            if (model == null) return;

            MessageBox.Show(model.Result, "Razones del Fallo", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void btnDescartar_Click(object sender, RoutedEventArgs e)
        {
            var model = (sender as Button)?.DataContext as TransactionModel;
            if (model == null) return;

            model.Status = "DESCARTADO";
            model.ActionTransaction("ChangeStatus", model);
            GetTransactionsAfterAction();
        }

        private void btnConsultar_Click(object sender, RoutedEventArgs e)
        {
            var model = (sender as Button)?.DataContext as TransactionModel;
            if (model == null) return;

            InfileService.GetDocumentPdfInBrowser(model.url_pdf);

        }

        private void btnAnular_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = (TransactionModel)dgvSuccess.SelectedItem;
            if (selectedItem == null) return;

            var msg = $"¿Está seguro de que desea anular el siguiente documento:\nDocumento Interno: {selectedItem.SAEDocumentId}\nUUID: {selectedItem.UUID}";
            wdwWIS_OKCancel confirmation = new wdwWIS_OKCancel("Anulación", msg);
            confirmation.ShowDialog();

            if (confirmation.Ok)
            {
                //var response = TransactionMethods.CancelDocument(selectedItem.Id);
                //MessageBox.Show(response ? $"Documento {selectedItem.UUID} anulado con éxito!"
                //                        : "Documento no se pudo anular, revisar el Log de errores!");
                //GetTransactionsAfterAction();
            }
        }

        #endregion



    }
}
