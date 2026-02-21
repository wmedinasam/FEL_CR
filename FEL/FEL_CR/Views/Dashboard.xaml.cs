using FELCR.Controls;
using FELCR.Properties;
using FELCR.Views.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WIS_Security;
using Monitor = FELCR.Views.Pages.Monitor;
using Application = System.Windows.Application;
using FELCR.Models;
using FELCR.Views;

namespace FELCR.Views
{
    /// <summary>
    /// Lógica de interacción para Dashboard.xaml
    /// </summary>
    public partial class Dashboard : Window
    {
        UserModel _userModel = new UserModel();
        NotifyIcon notificationIcon;

        public Dashboard(UserModel userModel, bool isFirstTime)
        {
            _userModel = userModel;
            InitializeComponent();
            AjustarResolucion();
            // Notification Toast
            notificationIcon = new NotifyIcon();
            notificationIcon.BalloonTipText = "El monitor FEL se encuentra en ejecución.";
            notificationIcon.BalloonTipTitle = "Notificación monitor FEL";
            notificationIcon.Text = "Presione clic para mostrar el monitor.";
            notificationIcon.Icon = new System.Drawing.Icon("667370_contract_document_paper_pen_sign_icon.ico"); // recurso incrustado en la app formato .ico
            notificationIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            notificationIcon.Click += new EventHandler(notificationIcon_click);
            //this.Width = SystemParameters.WorkArea.Width * 0.8;
            //this.Height = SystemParameters.WorkArea.Height * 0.8;

            GrantAccess(userModel);
            if (isFirstTime)
            {
                Pages.Settings settings = new Pages.Settings();
                settings.isFirstTime = isFirstTime;
                fContainer.Navigate(settings);
            }
            else
            {
                ConfigurationModel configurationModel = new ConfigurationModel();
                var response = configurationModel.GetConfiguration();
                Monitor monitor = new Monitor();

                if (userModel.role.CanAccessMonitor)
                {
                    monitor._sync = response.Object.SyncTime;
                    monitor.canUserSign = _userModel.role.CanSign;
                    fContainerMonitor.Navigate(monitor);
                    fContainerMonitor.Visibility = Visibility.Collapsed;
                }

                Home home = new Home(monitor);
                home.user = _userModel.UserName;
                home.sync = response.Object.SyncTime.ToString();
                fContainerHome.Navigate(home);
            }
        }

        private void AjustarResolucion()
        {
            // Obtener el ancho y alto de la pantalla primaria
            double screenWidth = SystemParameters.PrimaryScreenWidth;
            double screenHeight = SystemParameters.PrimaryScreenHeight;

            // Definir proporción deseada de ocupación (por ejemplo, 80%)
            double porcentaje = 0.75;

            // Aplicar proporción a la ventana
            this.Width = screenWidth * porcentaje;
            this.Height = screenHeight * porcentaje;

            // Centrar la ventana en la pantalla
            this.Left = (screenWidth - this.Width) / 2;
            this.Top = (screenHeight - this.Height) / 2;
        }

        private void notificationIcon_click(object sender, EventArgs e)
        {
            this.Show();
            WindowState = System.Windows.WindowState.Normal;
        }

        private void GrantAccess(UserModel userModel)
        {
            btnMonitoring.Visibility = userModel.role.CanAccessMonitor ? Visibility.Visible : Visibility.Collapsed;
            //btnDocuments.Visibility = userModel.role.CanAccessDocuments ? Visibility.Visible : Visibility.Collapsed;
            btnCompany.Visibility = userModel.role.CanAccessCompanies ? Visibility.Visible : Visibility.Collapsed;
            btnSubsidiary.Visibility = userModel.role.CanAccessCompanies ? Visibility.Visible : Visibility.Collapsed;
            btnUsers.Visibility = userModel.role.CanAccessUsers ? Visibility.Visible : Visibility.Collapsed;
            btnLogs.Visibility = userModel.role.CanAccessLogs ? Visibility.Visible : Visibility.Collapsed;
            btnSetting.Visibility = userModel.role.CanAccessConfigurations ? Visibility.Visible : Visibility.Collapsed;
            btnRole.Visibility = userModel.role.CanAccessRoles ? Visibility.Visible : Visibility.Collapsed;
            btnCertifier.Visibility = userModel.role.CanAccessCertifiers ? Visibility.Visible : Visibility.Collapsed;
        }


        private void BG_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Tg_Btn.IsChecked = false;
        }

        // Start: MenuLeft PopupButton //
        private void btnHome_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            ShowPopup(btnHome, "Inicio");
        }

        private void btnHome_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            HidePopup();
        }



        private void btnMonitoring_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            //ShowPopup(btnMonitoring, "Monitor");
        }

        private void btnMonitoring_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            HidePopup();
        }

        private void btnCompany_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            //ShowPopup(btnCompany, "Empresa");
        }

        private void btnCompany_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            HidePopup();
        }

        private void btnUsers_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            //ShowPopup(btnUsers, "Usuarios");
        }

        private void btnUsers_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            HidePopup();
        }

        private void btnConsultDocuments_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            HidePopup();
        }

        private void btnLogs_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            ShowPopup(btnLogs, "Logs");
        }

        private void btnLogs_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            HidePopup();
        }

        private void btnSetting_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            ShowPopup(btnSetting, "Configuracion");
        }

        private void btnSetting_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            HidePopup();
        }
        // End: MenuLeft PopupButton //

        // Start: Button Close | Restore | Minimize 
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnRestore_Click(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Normal)
                WindowState = WindowState.Maximized;
            else
                WindowState = WindowState.Normal;
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
        // End: Button Close | Restore | Minimize

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            fContainer.Navigate(new System.Uri("../Views/Pages/Home.xaml", UriKind.RelativeOrAbsolute));
            fContainerMonitor.Visibility = Visibility.Collapsed;
            fContainerHome.Visibility = Visibility.Visible;
        }


        private void btnMonitoring_Click(object sender, RoutedEventArgs e)
        {
            fContainer.Navigate(new System.Uri("../Views/Pages/Monitor.xaml", UriKind.RelativeOrAbsolute));
            fContainerHome.Visibility = Visibility.Collapsed;
            fContainerMonitor.Visibility = Visibility.Visible;
        }

        private void btnCompany_Click(object sender, RoutedEventArgs e)
        {
            fContainerHome.Visibility = Visibility.Collapsed;
            fContainerMonitor.Visibility = Visibility.Collapsed;
            fContainer.Navigate(new System.Uri("../Views/Pages/Company.xaml", UriKind.RelativeOrAbsolute));
        }

        private void btnUsers_Click(object sender, RoutedEventArgs e)
        {
            fContainerHome.Visibility = Visibility.Collapsed;
            fContainerMonitor.Visibility = Visibility.Collapsed;
            fContainer.Navigate(new System.Uri("../Views/Pages/User.xaml", UriKind.RelativeOrAbsolute));
        }

        private void btnConsultDocuments_Click(object sender, RoutedEventArgs e)
        {
            fContainerHome.Visibility = Visibility.Collapsed;
            fContainerMonitor.Visibility = Visibility.Collapsed;
            fContainer.Navigate(new System.Uri("../Views/Pages/ConsultDocuments.xaml", UriKind.RelativeOrAbsolute));
        }

        private void btnAnulllments_Click(object sender, RoutedEventArgs e)
        {
            fContainerHome.Visibility = Visibility.Collapsed;
            fContainerMonitor.Visibility = Visibility.Collapsed;
            fContainer.Navigate(new System.Uri("../Views/Pages/Anullments.xaml", UriKind.RelativeOrAbsolute));
        }

        private void btnLogs_Click(object sender, RoutedEventArgs e)
        {
            fContainerHome.Visibility = Visibility.Collapsed;
            fContainerMonitor.Visibility = Visibility.Collapsed;
            fContainer.Navigate(new System.Uri("../Views/Pages/Logs.xaml", UriKind.RelativeOrAbsolute));
        }

        private void btnSetting_Click(object sender, RoutedEventArgs e)
        {
            fContainerHome.Visibility = Visibility.Collapsed;
            fContainerMonitor.Visibility = Visibility.Collapsed;
            fContainer.Navigate(new System.Uri("../Views/Pages/Settings.xaml", UriKind.RelativeOrAbsolute));
        }

        private void btnSubsidiary_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            ShowPopup(btnSubsidiary, "Sucursal");
        }

        private void btnSubsidiary_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            HidePopup();
        }

        private void btnSubsidiary_Click(object sender, RoutedEventArgs e)
        {
            fContainerHome.Visibility = Visibility.Collapsed;
            fContainerMonitor.Visibility = Visibility.Collapsed;
            fContainer.Navigate(new System.Uri("../Views/Pages/Subsidiary.xaml", UriKind.RelativeOrAbsolute));
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void btnRole_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            ShowPopup(btnRole, "Roles");
        }

        private void btnRole_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            HidePopup();
        }

        private void btnRole_Click(object sender, RoutedEventArgs e)
        {
            fContainerHome.Visibility = Visibility.Collapsed;
            fContainerMonitor.Visibility = Visibility.Collapsed;
            fContainer.Navigate(new System.Uri("../Views/Pages/Role.xaml", UriKind.RelativeOrAbsolute));
        }

        private void btnCertifier_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            ShowPopup(btnCertifier, "Certificadores");
        }

        private void btnCertifier_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            HidePopup();
        }

        private void btnCertifier_Click(object sender, RoutedEventArgs e)
        {
            fContainerHome.Visibility = Visibility.Collapsed;
            fContainerMonitor.Visibility = Visibility.Collapsed;
            fContainer.Navigate(new System.Uri("../Views/Pages/Certifier.xaml", UriKind.RelativeOrAbsolute));
        }

        private void ShowIcon(bool show)
        {
            if (notificationIcon != null)
                notificationIcon.Visible = show;
        }

        private void VerificateIcon()
        {
            ShowIcon(!IsVisible);
        }

        private void Window_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            VerificateIcon();
        }

        private void Window_StateChanged(object sender, EventArgs e)
        {
            if (WindowState == WindowState.Minimized)
            {
                Hide();
                if (notificationIcon != null)
                {
                    notificationIcon.BalloonTipText = "El monitor FEL se encuentra en ejecución.";
                    notificationIcon.BalloonTipTitle = "Notificación monitor FEL";
                    notificationIcon.ShowBalloonTip(10000);
                }

            }
        }

        private void btnDocuments_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            //ShowPopup(btnDocuments, "Consulta Documentos");
        }

        private void btnDocuments_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            HidePopup();
        }

        private void btnDocuments_Click(object sender, RoutedEventArgs e)
        {
            fContainerHome.Visibility = Visibility.Collapsed;
            fContainerMonitor.Visibility = Visibility.Collapsed;
            fContainer.Navigate(new System.Uri("../Views/Pages/Documents.xaml", UriKind.RelativeOrAbsolute));
        }

        public static readonly DependencyProperty IconBrushProperty =
        DependencyProperty.Register("IconBrush", typeof(Brush), typeof(System.Windows.Controls.MenuItem), new PropertyMetadata(Brushes.Black));

        public Brush IconBrush
        {
            get { return (Brush)GetValue(IconBrushProperty); }
            set { SetValue(IconBrushProperty, value); }
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            var result = customMessageBox.Show(
                    "Cerrar Sesión",
                    "¿Estás seguro que deseas cerrar sesión?",
                    customMessageBox.MessageBoxType.Warning,
                    customMessageBox.MessageBoxButtons.YesNo);

            if (result == customMessageBox.CustomMessageBoxResult.Yes)
            {
                // Mostrar Login nuevamente
                Login loginWindow = new Login();
                loginWindow.Show();

                // Cerrar el Dashboard actual
                this.Close();
            }
        }

        private void btnLogout_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {

            ShowPopup(btnLogout, "Cerrar Sesión");

        }

        private void btnLogout_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            HidePopup();
        }


        private void ShowPopup(System.Windows.Controls.Button target, string text)
        {
            if (Tg_Btn.IsChecked == false)
            {
                Popup.PlacementTarget = target;
                Popup.Placement = PlacementMode.Right;
                Header.PopupText.Text = text;
                Popup.IsOpen = true;
            }
        }

        private void HidePopup()
        {
            Popup.IsOpen = false;
            Popup.Visibility = Visibility.Collapsed;
        }


    }
}
