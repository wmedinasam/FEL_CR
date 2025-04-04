using FELRD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WIS_Security;

namespace FELRD.Views
{
    /// <summary>
    /// Lógica de interacción para Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public static string appVersion = String.Format($"Versión: {Assembly.GetExecutingAssembly().GetName().Version.ToString()}");
        public static string appName = String.Format($"{Assembly.GetExecutingAssembly().GetName().Name}");

        public Login()
        {
            InitializeComponent();
            //ValidationConfigurationFile();
            lblVersion.Content = appVersion;
            lblAppName.Text = appName;
        }

        #region Functions

        private void CheckSubscription()
        {
            UnBlockControls();
            var responseDate = SuscriptionsService.GetServerDate();
            if (responseDate.Success)
            {
                var serverDate = responseDate.Object;
                if (!SuscriptionsService.isLifetimeLicence())
                {
                    var isExpired = SuscriptionsService.isSuscriptionExpired(serverDate);
                    if (isExpired)
                    {
                        BlockControls();
                        MessageBox.Show("Tu suscripcion ha vencido");
                    }
                }
            }
        }

        private void BlockControls()
        {
            btnLogin.IsEnabled = false;
        }

        private void UnBlockControls()
        {
            btnLogin.IsEnabled = true;
        }

        private void ValidationConfigurationFile()
        {
            UserModel userModel = new UserModel();
            userModel.role.CanAccessConfigurations = true;
            ConfigurationModel config = new ConfigurationModel();
            HandleCfg file = new HandleCfg();
            if (!file.CfgExists(config.path))
            {
                MessageBox.Show("No existe archivo de configuración, para iniciar el sistema debe configuralo primero.", "ADVERTENCIA", MessageBoxButton.OK, MessageBoxImage.Warning);
                //Dashboard dashboard = new Dashboard(userModel, true);
                //dashboard.ShowDialog();
                Application.Current.Shutdown();
            }

            var responseConfiguration = config.GetConfiguration();
            if (responseConfiguration.Success)
                CheckSubscription();
        }
        #endregion

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(txtUsername.Text) && !String.IsNullOrWhiteSpace(txtPassword.Password))
            {
                UserModel userModel = new UserModel();
                var response = userModel.GetUserByUserName(txtUsername.Text);
                if (response.Success)
                {
                    if (response.Object != null)
                    {
                        var decryptedPassword = response.Object.UserPassword.DesencriptarDatos();
                        if (decryptedPassword == txtPassword.Password)
                        {
                            this.Hide();
                            //Dashboard dasboard = new Dashboard(response.Object, false);
                            //dasboard.ShowDialog();
                            //Application.Current.Shutdown();
                        }
                        else
                        {
                            MessageBox.Show("Usurio o contraseña inválidos", "Error de sistema", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Usurio o contraseña inválidos", "Error de sistema", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    MessageBox.Show(response.Message, "Error de sistema", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Debe ingresar usuario y contraseña!", "MENSAJE DE SISTEMA", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }

        private void Card_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}
