using FELRD.Models;
using System;
using System.Collections.Generic;
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
using static FELRD.Models.Helpers;
using WIS_Security;

namespace FELRD.Views.Pages
{
    /// <summary>
    /// Lógica de interacción para Certifier.xaml
    /// </summary>
    public partial class Certifier : Page
    {
        private int _id = 0;

        public Certifier()
        {
            InitializeComponent();
            GetCertifiers();
        }

        private void GetCertifiers()
        {
            CertificadorModel certificadorModel = new CertificadorModel();
            var response = certificadorModel.Get();
            if (response.Success)
            {
                grdCertifier.ItemsSource = response.Object;
            }
            else
            {
                MessageBox.Show(response.Message, "Error de sistema", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void EnableControls()
        {
            txtName.IsEnabled = true;
            txtEndPoint.IsEnabled = true;            
            txtCommercialName.IsEnabled = true;
            txtNit.IsEnabled = true;
            txtUsuarioWS.IsEnabled = true;
            txtPasswordWS.IsEnabled = true;    
            txtSecurityKey.IsEnabled = true;
        }

        private void DisableControls()
        {
            txtName.IsEnabled = false;
            txtEndPoint.IsEnabled = false;            
            txtCommercialName.IsEnabled = false;
            txtNit.IsEnabled = false;
            txtUsuarioWS.IsEnabled = false;
            txtPasswordWS.IsEnabled = false;
            txtSecurityKey.IsEnabled = false;

        }


        private void btnAceptar_Click(object sender, RoutedEventArgs e)
        {
            CertificadorModel model = new CertificadorModel();
            model.Id = _id;
            model.Name = txtName.Text;
            model.EndPoint = txtEndPoint.Text;            
            model.CommercialName = txtCommercialName.Text;
            model.Nit = txtNit.Text;
            model.UsuarioWS = txtUsuarioWS.Text;
            model.PasswordWS = txtPasswordWS.Text;
            model.SecurityKey = txtSecurityKey.Text;

            ResponseModel<CertificadorModel> response = new ResponseModel<CertificadorModel>();
            if (_id == 0)
            {
                response = model.Action(Actions.Add.ToString(), model);
            }
            else
            {
                response = model.Action(Actions.Update.ToString(), model);
            }

            if (response.Success)
            {
                MessageBox.Show("Usuario guardado correctamente", "Sistema", MessageBoxButton.OK, MessageBoxImage.Information);
                GetCertifiers();

                _id = 0;
                txtName.Text = string.Empty;
                txtEndPoint.Text = string.Empty;                
                txtCommercialName.Text = string.Empty;
                txtNit.Text = string.Empty;
                txtUsuarioWS.Text = string.Empty;
                txtPasswordWS.Text = string.Empty;
                txtSecurityKey.Text = string.Empty;
                DisableControls();
            }
            else
            {
                MessageBox.Show(response.Message, "Error de sistema", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnNew_Click(object sender, RoutedEventArgs e)
        {
            _id = 0;
            txtName.Text = string.Empty;
            txtEndPoint.Text = string.Empty;            
            txtCommercialName.Text = string.Empty;
            txtNit.Text = string.Empty;
            txtUsuarioWS.Text = string.Empty;
            txtPasswordWS.Text = string.Empty;
            txtSecurityKey.Text = string.Empty;
            EnableControls();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var item = sender as Button;
            var model = item.DataContext as CertificadorModel;
            _id = model.Id;
            txtName.Text = model.Name;
            txtEndPoint.Text = model.EndPoint;            
            txtCommercialName.Text = model.CommercialName;
            txtNit.Text = model.Nit;
            txtUsuarioWS.Text = model.UsuarioWS;
            txtPasswordWS.Text = model.PasswordWS;
            txtSecurityKey.Text = model.SecurityKey;
            EnableControls();
        }
    }
}
