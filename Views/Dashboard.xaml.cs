using FELRD.Models;
using FELRD.Views.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using Monitor = FELRD.Views.Pages.Monitor;
using Application = System.Windows.Application;

namespace FELRD.Views
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
                Settings settings = new Settings();
                settings.isFirstTime = isFirstTime;
                fContainer.Navigate(settings);
            }
            else
            {
                ConfigurationModel configurationModel = new ConfigurationModel();
                var response = configurationModel.GetConfiguration();

                if (userModel.role.CanAccessMonitor)
                {
                    Monitor monitor = new Monitor();
                    monitor._sync = response.Object.SyncTime;
                    monitor.canUserSign = _userModel.role.CanSign;
                    fContainerMonitor.Navigate(monitor);
                    fContainerMonitor.Visibility = Visibility.Hidden;
                }

                Home home = new Home();
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
            btnMonitoring.Visibility = userModel.role.CanAccessMonitor ? Visibility.Visible : Visibility.Hidden;
            btnDocuments.Visibility = userModel.role.CanAccessDocuments ? Visibility.Visible : Visibility.Hidden;
            btnCompany.Visibility = userModel.role.CanAccessCompanies ? Visibility.Visible : Visibility.Hidden;
            btnSubsidiary.Visibility = userModel.role.CanAccessCompanies ? Visibility.Visible : Visibility.Hidden;
            btnUsers.Visibility = userModel.role.CanAccessUsers ? Visibility.Visible : Visibility.Hidden;
            btnLogs.Visibility = userModel.role.CanAccessLogs ? Visibility.Visible : Visibility.Hidden;
            btnSetting.Visibility = userModel.role.CanAccessConfigurations ? Visibility.Visible : Visibility.Hidden;
            btnRole.Visibility = userModel.role.CanAccessRoles ? Visibility.Visible : Visibility.Hidden;
            btnCertifier.Visibility = userModel.role.CanAccessCertifiers ? Visibility.Visible : Visibility.Hidden;
        }


        private void BG_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Tg_Btn.IsChecked = false;
        }

        // Start: MenuLeft PopupButton //
        private void btnHome_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (Tg_Btn.IsChecked == false)
            {
                Popup.PlacementTarget = btnHome;
                Popup.Placement = PlacementMode.Right;
                Popup.IsOpen = true;
                Header.PopupText.Text = "Inicio";
            }
        }

        private void btnHome_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Popup.Visibility = Visibility.Collapsed;
            Popup.IsOpen = false;
        }



        private void btnMonitoring_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (Tg_Btn.IsChecked == false)
            {
                Popup.PlacementTarget = btnMonitoring;
                Popup.Placement = PlacementMode.Right;
                Popup.IsOpen = true;
                Header.PopupText.Text = "Monitor";
            }
        }

        private void btnMonitoring_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Popup.Visibility = Visibility.Collapsed;
            Popup.IsOpen = false;
        }

        private void btnCompany_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (Tg_Btn.IsChecked == false)
            {
                Popup.PlacementTarget = btnCompany;
                Popup.Placement = PlacementMode.Right;
                Popup.IsOpen = true;
                Header.PopupText.Text = "Empresa";
            }
        }

        private void btnCompany_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Popup.Visibility = Visibility.Collapsed;
            Popup.IsOpen = false;
        }

        private void btnUsers_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (Tg_Btn.IsChecked == false)
            {
                Popup.PlacementTarget = btnUsers;
                Popup.Placement = PlacementMode.Right;
                Popup.IsOpen = true;
                Header.PopupText.Text = "Usuarios";
            }
        }

        private void btnUsers_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Popup.Visibility = Visibility.Collapsed;
            Popup.IsOpen = false;
        }

        private void btnConsultDocuments_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Popup.Visibility = Visibility.Collapsed;
            Popup.IsOpen = false;
        }

        private void btnLogs_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (Tg_Btn.IsChecked == false)
            {
                Popup.PlacementTarget = btnLogs;
                Popup.Placement = PlacementMode.Right;
                Popup.IsOpen = true;
                Header.PopupText.Text = "Logs";
            }
        }

        private void btnLogs_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Popup.Visibility = Visibility.Collapsed;
            Popup.IsOpen = false;
        }

        private void btnSetting_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (Tg_Btn.IsChecked == false)
            {
                Popup.PlacementTarget = btnSetting;
                Popup.Placement = PlacementMode.Right;
                Popup.IsOpen = true;
                Header.PopupText.Text = "Configuracion";
            }
        }

        private void btnSetting_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Popup.Visibility = Visibility.Collapsed;
            Popup.IsOpen = false;
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
            fContainerMonitor.Visibility = Visibility.Hidden;
            fContainerHome.Visibility = Visibility.Visible;
        }


        private void btnMonitoring_Click(object sender, RoutedEventArgs e)
        {
            fContainer.Navigate(new System.Uri("../Views/Pages/Monitor.xaml", UriKind.RelativeOrAbsolute));
            fContainerHome.Visibility = Visibility.Hidden;
            fContainerMonitor.Visibility = Visibility.Visible;
        }

        private void btnCompany_Click(object sender, RoutedEventArgs e)
        {
            fContainerHome.Visibility = Visibility.Hidden;
            fContainerMonitor.Visibility = Visibility.Hidden;
            fContainer.Navigate(new System.Uri("../Views/Pages/Company.xaml", UriKind.RelativeOrAbsolute));
        }

        private void btnUsers_Click(object sender, RoutedEventArgs e)
        {
            fContainerHome.Visibility = Visibility.Hidden;
            fContainerMonitor.Visibility = Visibility.Hidden;
            fContainer.Navigate(new System.Uri("../Views/Pages/User.xaml", UriKind.RelativeOrAbsolute));
        }

        private void btnConsultDocuments_Click(object sender, RoutedEventArgs e)
        {
            fContainerHome.Visibility = Visibility.Hidden;
            fContainerMonitor.Visibility = Visibility.Hidden;
            fContainer.Navigate(new System.Uri("../Views/Pages/ConsultDocuments.xaml", UriKind.RelativeOrAbsolute));
        }

        private void btnAnulllments_Click(object sender, RoutedEventArgs e)
        {
            fContainerHome.Visibility = Visibility.Hidden;
            fContainerMonitor.Visibility = Visibility.Hidden;
            fContainer.Navigate(new System.Uri("../Views/Pages/Anullments.xaml", UriKind.RelativeOrAbsolute));
        }

        private void btnLogs_Click(object sender, RoutedEventArgs e)
        {
            fContainerHome.Visibility = Visibility.Hidden;
            fContainerMonitor.Visibility = Visibility.Hidden;
            fContainer.Navigate(new System.Uri("../Views/Pages/Logs.xaml", UriKind.RelativeOrAbsolute));
        }

        private void btnSetting_Click(object sender, RoutedEventArgs e)
        {
            fContainerHome.Visibility = Visibility.Hidden;
            fContainerMonitor.Visibility = Visibility.Hidden;
            fContainer.Navigate(new System.Uri("../Views/Pages/Settings.xaml", UriKind.RelativeOrAbsolute));
        }

        private void btnSubsidiary_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (Tg_Btn.IsChecked == false)
            {
                Popup.PlacementTarget = btnSubsidiary;
                Popup.Placement = PlacementMode.Right;
                Popup.IsOpen = true;
                Header.PopupText.Text = "Sucursal";
            }
        }

        private void btnSubsidiary_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Popup.Visibility = Visibility.Collapsed;
            Popup.IsOpen = false;
        }

        private void btnSubsidiary_Click(object sender, RoutedEventArgs e)
        {
            fContainerHome.Visibility = Visibility.Hidden;
            fContainerMonitor.Visibility = Visibility.Hidden;
            fContainer.Navigate(new System.Uri("../Views/Pages/Subsidiary.xaml", UriKind.RelativeOrAbsolute));
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void btnRole_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (Tg_Btn.IsChecked == false)
            {
                Popup.PlacementTarget = btnRole;
                Popup.Placement = PlacementMode.Right;
                Popup.IsOpen = true;
                Header.PopupText.Text = "Roles";
            }
        }

        private void btnRole_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Popup.Visibility = Visibility.Collapsed;
            Popup.IsOpen = false;
        }

        private void btnRole_Click(object sender, RoutedEventArgs e)
        {
            fContainerHome.Visibility = Visibility.Hidden;
            fContainerMonitor.Visibility = Visibility.Hidden;
            fContainer.Navigate(new System.Uri("../Views/Pages/Role.xaml", UriKind.RelativeOrAbsolute));
        }

        private void btnCertifier_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (Tg_Btn.IsChecked == false)
            {
                Popup.PlacementTarget = btnCertifier;
                Popup.Placement = PlacementMode.Right;
                Popup.IsOpen = true;
                Header.PopupText.Text = "Certificadores";
            }
        }

        private void btnCertifier_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Popup.Visibility = Visibility.Collapsed;
            Popup.IsOpen = false;
        }

        private void btnCertifier_Click(object sender, RoutedEventArgs e)
        {
            fContainerHome.Visibility = Visibility.Hidden;
            fContainerMonitor.Visibility = Visibility.Hidden;
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
            if (Tg_Btn.IsChecked == false)
            {
                Popup.PlacementTarget = btnDocuments;
                Popup.Placement = PlacementMode.Right;
                Popup.IsOpen = true;
                Header.PopupText.Text = "Documentos";
            }
        }

        private void btnDocuments_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Popup.Visibility = Visibility.Collapsed;
            Popup.IsOpen = false;
        }

        private void btnDocuments_Click(object sender, RoutedEventArgs e)
        {
            fContainerHome.Visibility = Visibility.Hidden;
            fContainerMonitor.Visibility = Visibility.Hidden;
            fContainer.Navigate(new System.Uri("../Views/Pages/Documents.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}
