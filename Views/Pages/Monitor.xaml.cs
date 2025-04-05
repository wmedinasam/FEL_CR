using FELRD.Helpers;
using FELRD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;
using WIS_Security;

namespace FELRD.Views.Pages
{
    /// <summary>
    /// Interaction logic for Monitor.xaml
    /// </summary>
    public partial class Monitor : Page
    {
        public int _sync = 0;
        public SolidColorBrush CardColor, IconColor, TextColor;
        DispatcherTimer dispatcherTimer = new DispatcherTimer();
        private Thread thread;

        public bool canUserSign = false;

        TransactionModel transactionModel = new TransactionModel();
        ResponseModel<List<TransactionModel>> transactionsResponse = new ResponseModel<List<TransactionModel>>();

        private void GetTransactions()
        {
            transactionsResponse = transactionModel.GetProcessed();
            if (transactionsResponse.Success)
            {
                if (canUserSign)
                {
                    try
                    {
                        TransactionMethods.SignDocument();
                    }
                    catch (Exception ex)
                    {
                        HandleLogs.SaveLog("Debug", "Problemas al iniciar monitor " + ex.Message);
                    }

                }
            }
        }

        private void ShutDownProcess()
        {
            if (dispatcherTimer != null)
            {
                dispatcherTimer.Stop();
            }
            if (thread != null)
            {
                thread.Abort();
            }
        }

        private void ShowConnected()
        {
            try
            {
                var SuccessColor = FindResource("SuccessColor").ToString();
                var converterSuccessColor = new System.Windows.Media.BrushConverter();
                var brushconverterSuccessColor = (System.Windows.Media.Brush)converterSuccessColor.ConvertFromString(SuccessColor);
                cardEstado.Background = brushconverterSuccessColor;
                IconColor = (SolidColorBrush)brushconverterSuccessColor;

                var SuccessTextColor = FindResource("SuccessTextColor").ToString();
                var converterSuccessTextColor = new System.Windows.Media.BrushConverter();
                var brushconverterSuccessTextColor = (System.Windows.Media.Brush)converterSuccessTextColor.ConvertFromString(SuccessTextColor);
                TextColor = (SolidColorBrush)brushconverterSuccessTextColor;

                txtState.Text = "Conectado";
                iconState.Kind = MaterialDesignThemes.Wpf.PackIconKind.CheckCircleOutline;
                btnIniciar.IsChecked = true;
            }
            catch (Exception)
            {
                throw;
            }

        }

        private void ShowDisconnected()
        {
            ShutDownProcess();
            try
            {
                IconColor = (SolidColorBrush)FindResource("DangerColor");
                TextColor = (SolidColorBrush)FindResource("DangerTextColor");

                var DangerColorColor = FindResource("DangerColor").ToString();
                var converterDangerColor = new System.Windows.Media.BrushConverter();
                var brushconverterDangerColor = (System.Windows.Media.Brush)converterDangerColor.ConvertFromString(DangerColorColor);
                cardEstado.Background = brushconverterDangerColor;
                IconColor = (SolidColorBrush)brushconverterDangerColor;

                var DangerTextColor = FindResource("DangerTextColor").ToString();
                var converterDangerTextColor = new System.Windows.Media.BrushConverter();
                var brushconverterDangerTextColor = (System.Windows.Media.Brush)converterDangerTextColor.ConvertFromString(DangerTextColor);
                TextColor = (SolidColorBrush)brushconverterDangerTextColor;


                txtState.Text = "Desconectado";
                iconState.Kind = MaterialDesignThemes.Wpf.PackIconKind.CloseCircleOutline;
                btnIniciar.IsChecked = false;
                dgvSuccess.ItemsSource = null;
                grdRejected.ItemsSource = null;
            }
            catch (Exception)
            {

                throw;
            }

        }

        private void GetTransactionsFirstTime()
        {
            transactionsResponse = transactionModel.GetProcessed();
            if (transactionsResponse.Success)
            {
                dgvSuccess.ItemsSource = transactionsResponse.Object.Where(x => x.Status == "ACEPTADO");
                grdRejected.ItemsSource = transactionsResponse.Object.Where(x => x.Status == "RECHAZADO" || x.Status == "PROCESANDO");
                StartProcess();
                ShowConnected();
            }
            else
            {
                ShowDisconnected();
                MessageBox.Show(transactionsResponse.Message, "Error del sistema", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void GetTransactionsAfterAction()
        {
            transactionsResponse = transactionModel.GetProcessed();
            if (transactionsResponse.Success)
            {
                dgvSuccess.ItemsSource = transactionsResponse.Object.Where(x => x.Status == "ACEPTADO");
                grdRejected.ItemsSource = transactionsResponse.Object.Where(x => x.Status == "RECHAZADO" || x.Status == "PROCESANDO");
            }
            else
            {
                ShowDisconnected();
                MessageBox.Show(transactionsResponse.Message, "Error del sistema", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void StartProcess()
        {
            if (dispatcherTimer.Interval.Seconds == 0)
            {
                dispatcherTimer.Tick += CrearHilo;
                dispatcherTimer.Interval = new TimeSpan(0, 0, _sync);
            }
            dispatcherTimer.Start();
        }

        private void CrearHilo(object sender, EventArgs e)
        {
            thread = new Thread(GetTransactions);
            thread.Start();
            thread.Join();
            displayResults();
        }

        private void displayResults()
        {
            if (transactionsResponse.Success)
            {
                ShowConnected();
                dgvSuccess.ItemsSource = transactionsResponse.Object.Where(x => x.Status == "ACEPTADO");
                grdRejected.ItemsSource = transactionsResponse.Object.Where(x => x.Status == "RECHAZADO" || x.Status == "PROCESANDO");
            }
            else
            {
                ShowDisconnected();
            }
        }

        private void btnIniciar_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void btnIniciar_Unchecked(object sender, RoutedEventArgs e)
        {
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            ShowDisconnected();
        }

        private void btnRetry_Click(object sender, RoutedEventArgs e)
        {
            var item = sender as Button;
            var model = item.DataContext as TransactionModel;
            model.Status = "PENDIENTE";
            model.Result = string.Empty;
            model.ActionTransaction("ChangeStatusResult", model);
            GetTransactionsAfterAction();
        }

        private void btnError_Click(object sender, RoutedEventArgs e)
        {
            var item = sender as Button;
            var model = item.DataContext as TransactionModel;
            MessageBox.Show(model.Result, "Razones del Fallo", MessageBoxButton.OK, MessageBoxImage.Information);

        }

        private void btnDescartar_Click(object sender, RoutedEventArgs e)
        {
            var item = sender as Button;
            var model = item.DataContext as TransactionModel;
            model.Status = "DESCARTADO";
            model.ActionTransaction("ChangeStatus", model);
            GetTransactionsAfterAction();
        }

        private void btnConsultar_Click(object sender, RoutedEventArgs e)
        {
            var item = sender as Button;
            var model = item.DataContext as TransactionModel;
            FilePDF filePDF = new FilePDF(model.Company.Certificador.EndPointVerDoc, model.UUID);
            filePDF.ShowDialog();
            //string remoteUri = model.Company.Certificador.EndPointVerDoc + model.UUID + "&formato=pdf";
            //wbPDF.Navigate(remoteUri);
        }

        private void btnAnular_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = (TransactionModel)dgvSuccess.SelectedItem;
            // TODO: lógica de anulación
            var msg = $"¿Esta seguro de que desea anular el siguiente documento: \nDocumento Interno:{selectedItem.SAEDocumentId} \nUUID: {selectedItem.UUID}";
            wdwWIS_OKCancel confirmation = new wdwWIS_OKCancel("Anulación", msg);
            confirmation.ShowDialog();
            if (confirmation.Ok)
            {
                var response = TransactionMethods.CancelDocument(selectedItem.Id);
                if (!response)
                {
                    MessageBox.Show("Documento no se pudo anular, revisar el Log de errores!");
                }
                else
                {
                    MessageBox.Show($"Documento {selectedItem.UUID} anulado con éxito!");
                }
            }
        }

        public Monitor()
        {
            InitializeComponent();
            this.DataContext = this;
            btnIniciar_Unchecked(null, null);
        }

        private void btnIniciar_Click(object sender, RoutedEventArgs e)
        {
            if (btnIniciar.IsChecked.Value)
            {
                GetTransactionsFirstTime();
            }
            else
            {
                ShowDisconnected();
            }
        }
    }
}
