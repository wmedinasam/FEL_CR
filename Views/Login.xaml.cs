using FELRD.Controls;
using FELRD.Helpers;
using FELRD.Models;
using FELRD.Services;
using System;
using System.Reflection;
using System.Windows;
using System.Windows.Input;
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
            this.Loaded += Login_Loaded;
            lblVersion.Content = appVersion;
            lblAppName.Text = appName;
        }

        public void Login_Loaded(object sender, RoutedEventArgs e)
        {
            ValidationConfigurationFile();
        }

        #region Functions


        private bool GetSystemName(ResponseModel<ConfigurationModel> config)
        {
            return config.Object.Key.Sistema.Equals("FELRD");
        }


        private void CheckSubscription(ResponseModel<ConfigurationModel> config)
        {
            UnBlockControls();
            var responseDate = SuscriptionsService.GetServerDate();
            if (responseDate.Success)
            {
                var serverDate = responseDate.Object;
                var iscorrectSystemName = GetSystemName(config);
                if (!iscorrectSystemName)
                {
                    BlockControls();
                    MessageService.ShowWarning("Licencia No Encontrada", "El sistema no es FELRD, por favor contactate con Soporte Técnico para obtener mas información.");
                    return;
                }


                if (!SuscriptionsService.isLifetimeLicence())
                {
                    var isExpired = SuscriptionsService.isSuscriptionExpired(serverDate);
                    if (isExpired)
                    {
                        BlockControls();
                        MessageService.ShowWarning("Suscripción vencida", "Tu suscripción ha vencido. Contactate con Soporte Técnico para obtener mas información.");
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
                MessageService.ShowWarning("Licencia No Encontrada", "No existe archivo de configuración, para iniciar el sistema debe configuralo primero.");
                Dashboard dashboard = new Dashboard(userModel, true);
                dashboard.ShowDialog();
                if (Application.Current != null)
                    Application.Current.Shutdown();

                return;

            }

            var responseConfiguration = config.GetConfiguration();
            if (responseConfiguration.Success)
            {
                var isCorrectSystemName = GetSystemName(responseConfiguration);
                if (!isCorrectSystemName)
                {
                    BlockControls();
                }

                CheckSubscription(responseConfiguration);
            }

        }
        #endregion

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(txtUsername.Text) && !String.IsNullOrWhiteSpace(txtPassword.Password))
            {
                UserModel userModel = new UserModel();
                var response = userModel.GetUserByUserName(txtUsername.Text);

                if (response.Success && response.Object != null)
                {
                    var decryptedPassword = response.Object.UserPassword.DesencriptarDatos();

                    if (decryptedPassword == txtPassword.Password)
                    {

                        try
                        {
                            Dashboard dashboard = new Dashboard(response.Object, false);
                            this.Hide();
                            dashboard.ShowDialog();
                        }
                        catch (Exception ex)
                        {
                            HandleLogs.SaveLog("Debug", "Problemas al abrir el Dashboard inicial: " + ex.Message);
                            MessageBox.Show("ERROR AL ABRIR DASHBOARD: " + ex.Message + "\n\n" + ex.StackTrace);
                        }
                    }
                    else
                    {
                        MessageService.ShowError("Error de Sistema", "Usuario o contraseña inválidos.");
                    }
                }
                else
                {
                    MessageService.ShowError("Error de Sistema", "Usuario o contraseña inválidos.");
                }
            }
            else
            {
                MessageService.ShowError("Error de validación", "Debe ingresar usuario y contraseña!");
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
