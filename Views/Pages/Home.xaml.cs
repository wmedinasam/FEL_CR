using FELRD.Models;
using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Animation;
using WIS_Security;

namespace FELRD.Views.Pages
{
    /// <summary>
    /// Lógica de interacción para Home.xaml
    /// </summary>
    /// 

    public partial class Home : Page, INotifyPropertyChanged
    {
        public static Home Instance { get; private set; }
        public HomeViewModel LicenceVM { get; set; } = new HomeViewModel();
        DashboardModel model = new DashboardModel();
        public string user = string.Empty;
        public string sync = string.Empty;


        public Monitor MonitorRef { get; set; }

        public Home() : this(new Monitor()) { }
        public Home(Monitor monitor)
        {
            InitializeComponent();
            Instance = this;

            MonitorRef = monitor;

            MonitorRef.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == nameof(Monitor.AcceptedCount))
                    AnimateTextBlockBounce(txtAccepted);
                else if (e.PropertyName == nameof(Monitor.RejectedCount))
                    AnimateTextBlockBounce(txtRejected);
                else if (e.PropertyName == nameof(Monitor.LastUpdated))
                    AnimateTextBlockBounce(txtSync);
            };

            var multiContext = new
            {
                Monitor = MonitorRef,
                Licence = LicenceVM
            };
            this.DataContext = multiContext;

        }



        private void GetLicence()
        {
            var isLifeTime = SuscriptionsService.isLifetimeLicence();

            if (isLifeTime)
            {
                LicenceVM.LicenceText = "Licencia Permanente";
                LicenceVM.LicenceBrush = new LinearGradientBrush
                {
                    StartPoint = new Point(0.5, 0),
                    EndPoint = new Point(0.5, 1),
                    GradientStops = new GradientStopCollection
                        {
                            new GradientStop((Color)ColorConverter.ConvertFromString("#FF000000"), 0),
                            new GradientStop((Color)ColorConverter.ConvertFromString("#FF0F9B0F"), 0.5)
                        }
                };
                LicenceVM.AlertVisibility = Visibility.Collapsed;
                return;
            }

            var responseDate = SuscriptionsService.GetServerDate();
            if (responseDate.Success)
            {
                var serverDate = responseDate.Object;
                var dueDate = SuscriptionsService.GetDueDate().ToString();
                SettingModel settingModel = new SettingModel();
                string format = "M/d/yyyy h:mm:ss tt";
                CultureInfo provider = CultureInfo.InvariantCulture;

                var isAboutToExpire = settingModel.isSuscriptionAboutToExpired(serverDate);

                if (isAboutToExpire)
                {
                    var remainingDays = SuscriptionsService.remainingDays(serverDate);
                    LicenceVM.LicenceText = $"Vence en {remainingDays} días";

                    if (remainingDays > 20)
                    {
                        LicenceVM.LicenceBrush = new LinearGradientBrush
                        {
                            StartPoint = new Point(0.5, 0),
                            EndPoint = new Point(0.5, 1),
                            GradientStops = new GradientStopCollection
                                {
                                    new GradientStop((Color)ColorConverter.ConvertFromString("#FFF7B733"), 0),
                                    new GradientStop((Color)ColorConverter.ConvertFromString("#FFFC4A1A"), 0.5)
                                }
                        };
                        LicenceVM.AlertVisibility = Visibility.Collapsed;
                    }
                    else if (remainingDays > 10)
                    {
                        LicenceVM.LicenceBrush = new LinearGradientBrush
                        {
                            StartPoint = new Point(0.5, 0),
                            EndPoint = new Point(0.5, 1),
                            GradientStops = new GradientStopCollection
                            {
                                new GradientStop((Color)ColorConverter.ConvertFromString("#FFEF473A"), 0),
                                new GradientStop((Color)ColorConverter.ConvertFromString("#FFCB2D3E"), 0.5)
                            }
                        };
                        LicenceVM.AlertVisibility = Visibility.Collapsed;
                    }
                    else if (remainingDays > 5)
                    {
                        LicenceVM.LicenceBrush = new LinearGradientBrush
                        {
                            StartPoint = new Point(0.5, 0),
                            EndPoint = new Point(0.5, 1),
                            GradientStops = new GradientStopCollection
                                {
                                    new GradientStop((Color)ColorConverter.ConvertFromString("#FFB31217"), 0.5),
                                    new GradientStop((Color)ColorConverter.ConvertFromString("#FFE52D27"), 1)
                                }
                        };
                        LicenceVM.AlertVisibility = Visibility.Collapsed;
                    }
                    else
                    {
                        LicenceVM.LicenceBrush = new LinearGradientBrush
                        {
                            StartPoint = new Point(0.5, 0),
                            EndPoint = new Point(0.5, 1),
                            GradientStops = new GradientStopCollection
                                {
                                    new GradientStop((Color)ColorConverter.ConvertFromString("#FF190A05"), 0),
                                    new GradientStop((Color)ColorConverter.ConvertFromString("#FF870000"), 0.9)
                                }
                        };
                        LicenceVM.AlertText = "¡Tu sistema dejará de funcionar pronto!\nContacta a tu asesor de Ventas";
                        LicenceVM.AlertVisibility = Visibility.Visible;
                    }


                    var notificationSent = settingModel.isNotificationSent(serverDate);
                    if (!notificationSent)
                    {
                        settingModel.SendEmail();
                        settingModel.ChangeNotificationSent(serverDate);
                    }
                }
                else
                {
                    DateTime parsedDate = DateTime.ParseExact(dueDate, format, provider);
                    LicenceVM.LicenceText = $"Vence el {parsedDate.ToString("dd/MM/yyyy")}";

                    LicenceVM.LicenceBrush = new LinearGradientBrush
                    {
                        StartPoint = new Point(0.5, 0),
                        EndPoint = new Point(0.5, 1),
                        GradientStops = new GradientStopCollection
                        {
                            new GradientStop((Color)ColorConverter.ConvertFromString("#FF000000"), 0),
                            new GradientStop((Color)ColorConverter.ConvertFromString("#FF0F9B0F"), 0.5)
                        }
                    };
                    LicenceVM.AlertVisibility = Visibility.Collapsed;
                }
            }
        }




        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            txtUsuario.Text = $"{user}";
            GetLicence();
            Storyboard sb = (Storyboard)this.FindResource("CardEntranceAnimation");
            sb.Begin(cardDocuments);
            sb.Begin(cardRejected);
            sb.Begin(cardSync);
            sb.Begin(cardLicence);

        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void TestChange_Click(object sender, RoutedEventArgs e)
        {
            MonitorRef.AcceptedCount = new Random().Next(1, 999);
            MonitorRef.RejectedCount = new Random().Next(0, 50);
            MonitorRef.LastUpdated = DateTime.Now.ToString("HH:mm:ss");
        }

        public void AnimateAllDashboardCards()
        {
            if (txtAccepted != null)
                AnimateTextBlockBounce(txtAccepted);
            if (txtRejected != null)
                AnimateTextBlockBounce(txtRejected);
            if (txtSync != null)
                AnimateTextBlockBounce(txtSync);
        }

        private void AnimateTextBlockBounce(TextBlock target)
        {
            var scale = new ScaleTransform(1, 1);
            target.RenderTransform = scale;
            target.RenderTransformOrigin = new Point(0.5, 0.5);

            var sb = new Storyboard();

            var animX = new DoubleAnimation
            {
                From = 1,
                To = 1.75,
                AutoReverse = true,
                Duration = TimeSpan.FromMilliseconds(1500)
            };

            var animY = animX.Clone();

            Storyboard.SetTarget(animX, target);
            Storyboard.SetTargetProperty(animX, new PropertyPath("RenderTransform.ScaleX"));

            Storyboard.SetTarget(animY, target);
            Storyboard.SetTargetProperty(animY, new PropertyPath("RenderTransform.ScaleY"));

            sb.Children.Add(animX);
            sb.Children.Add(animY);

            sb.Begin(target, true);
        }

        private void TextBlock_TargetUpdated(object sender, DataTransferEventArgs e)
        {
            if (sender is TextBlock tb)
                AnimateTextBlockBounce(tb);
        }
    }
}
