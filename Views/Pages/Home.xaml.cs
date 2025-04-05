using FELRD.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using WIS_Security;

namespace FELRD.Views.Pages
{
    /// <summary>
    /// Lógica de interacción para Home.xaml
    /// </summary>
    public partial class Home : Page
    {
        public string user = string.Empty;
        public string sync = string.Empty;

        DispatcherTimer dispatcherTimer = new DispatcherTimer();
        DashboardModel model = new DashboardModel();

        public Home()
        {
            InitializeComponent();
        }

        private void GetLicence()
        {
            lblLicence.Visibility = Visibility.Hidden;
            var isLifeTime = SuscriptionsService.isLifetimeLicence();
            if (!isLifeTime)
            {
                lblLicence.Visibility = Visibility.Visible;
                var responseDate = SuscriptionsService.GetServerDate();
                if (responseDate.Success)
                {
                    SettingModel settingModel = new SettingModel();
                    var serverDate = responseDate.Object;
                    var dueDate = SuscriptionsService.GetDueDate().ToString();
                    var isAboutToExpire = settingModel.isSuscriptionAboutToExpired(serverDate);
                    if (isAboutToExpire)
                    {
                        var remainingDays = SuscriptionsService.remainingDays(serverDate);
                        lblLicence.Content = $"SU LICENCIA VENCE EN: {remainingDays} DÍAS";
                        SolidColorBrush brush = new SolidColorBrush(Color.FromRgb(255, 0, 0));
                        lblLicence.Foreground = brush;

                        var responseNotificationSent = settingModel.isNotificationSent(serverDate);
                        if (!responseNotificationSent)
                        {
                            settingModel.SendEmail();
                            settingModel.ChangeNotificationSent(serverDate);
                        }
                    }
                    else
                    {
                        lblLicence.Content = $"SU LICENCIA VENCE EL: {dueDate} ";
                        SolidColorBrush brush = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                        lblLicence.Foreground = brush;
                    }
                }
            }

        }


        private void GetDashboard()
        {
            txtUsuario.Text = user;
            var response = model.GetDashboard();
            if (response.Success)
            {
                if (response.Object.Count > 0)
                {
                    txtDocuments.Text = response.Object.FirstOrDefault().Documents;
                    txtUsers.Text = response.Object.FirstOrDefault().Users;
                    txtSyncTime.Text = sync;
                    var date = DateTime.Now;
                    txtHour.Text = GetTimeString();
                    StartProcess();
                }
            }
            else
            {
                MessageBox.Show(response.Message, "Error del sistema", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void StartProcess()
        {
            dispatcherTimer.Tick += GetTime;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 60);
            dispatcherTimer.Start();
        }


        private void GetTime(object sender, EventArgs e)
        {
            var date = DateTime.Now;
            txtHour.Text = GetTimeString();
        }

        private string GetTimeString()
        {
            var date = DateTime.Now;
            return String.Format($"{date.ToString("t", CultureInfo.CreateSpecificCulture("en-us"))}");
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            GetLicence();
            GetDashboard();
        }
    }
}
