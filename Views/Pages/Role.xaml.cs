using FELRD.Models;
using System.Windows;
using System.Windows.Controls;
using static FELRD.Models.Helpers;
using WIS_Security;
using FELRD.Helpers;
using System.Collections.Generic;
using System.Xml.Linq;

namespace FELRD.Views.Pages
{
    /// <summary>
    /// Lógica de interacción para Role.xaml
    /// </summary>
    public partial class Role : Page
    {
        private int _id = 0;

        public Role()
        {
            InitializeComponent();
            GetRoles();
            DisableControls();
        }


        private void GetRoles()
        {
            RoleModel roleModel = new RoleModel();
            var response = roleModel.Get();
            if (response.Success)
            {
                grdRole.ItemsSource = response.Object;
            }
            else
            {
                MessageBox.Show(response.Message, "Error de sistema", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void EnableControls()
        {
            txtRoleName.IsEnabled = true;
            btnStatus.IsEnabled = true;
            btnCanMonitor.IsEnabled = true;
            btnCanAnull.IsEnabled = true;
            btnCanCompany.IsEnabled = true;
            btnCanUsers.IsEnabled = true;
            btnCanLogs.IsEnabled = true;
            btnCanSettings.IsEnabled = true;
            btnAceptar.IsEnabled = true;
            btnCanSign.IsEnabled = true;
            btnCanAccessRoles.IsEnabled = true;
            btnCanAccessCertifiers.IsEnabled = true;
        }

        private void DisableControls()
        {
            txtRoleName.IsEnabled = false;
            btnStatus.IsEnabled = false;
            btnCanMonitor.IsEnabled = false;
            btnCanAnull.IsEnabled = false;
            btnCanCompany.IsEnabled = false;
            btnCanUsers.IsEnabled = false;
            btnCanLogs.IsEnabled = false;
            btnCanSettings.IsEnabled = false;
            btnAceptar.IsEnabled = false;
            btnCanSign.IsEnabled = false;
            btnCanAccessRoles.IsEnabled = false;
            btnCanAccessCertifiers.IsEnabled = false;
        }

        private void New()
        {
            _id = 0;
            txtRoleName.Text = string.Empty;
            btnStatus.IsChecked = false;
            btnCanMonitor.IsChecked = false;
            btnCanAnull.IsChecked = false;
            btnCanCompany.IsChecked = false;
            btnCanUsers.IsChecked = false;
            btnCanLogs.IsChecked = false;
            btnCanSettings.IsChecked = false;
            btnCanSign.IsChecked = false;
            btnCanAccessRoles.IsChecked = false;
            btnCanAccessCertifiers.IsChecked = false;
        }

        private void btnAceptar_Click(object sender, RoutedEventArgs e)
        {

            var fieldsToValidate = new List<Control>
            {
                txtRoleName
            };

            if (ValidationHelper.HasValidationErrors(fieldsToValidate))
            {
                MessageBox.Show("Por favor completa todos los campos requeridos.", "Campos vacíos", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            RoleModel model = new RoleModel();
            model.Id = _id;
            model.Name = txtRoleName.Text;
            model.State = btnStatus.IsChecked.Value;
            model.CanAccessMonitor = btnCanMonitor.IsChecked.Value;
            model.CanCancel = btnCanAnull.IsChecked.Value;
            model.CanAccessCompanies = btnCanCompany.IsChecked.Value;
            model.CanAccessUsers = btnCanUsers.IsChecked.Value;
            model.CanAccessDocuments = btnCanAnull.IsChecked.Value;
            model.CanAccessLogs = btnCanLogs.IsChecked.Value;
            model.CanAccessConfigurations = btnCanSettings.IsChecked.Value;
            model.CanSign = btnCanSign.IsChecked.Value;
            model.CanAccessRoles = btnCanAccessRoles.IsChecked.Value;
            model.CanAccessCertifiers = btnCanAccessCertifiers.IsChecked.Value;

            ResponseModel<RoleModel> response = new ResponseModel<RoleModel>();
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
                GetRoles();

                New();
                txtRoleName.Text = string.Empty;
                btnStatus.IsChecked = false;
                btnCanMonitor.IsChecked = false;
                btnCanAnull.IsChecked = false;
                btnCanCompany.IsChecked = false;
                btnCanUsers.IsChecked = false;
                btnCanLogs.IsChecked = false;
                btnCanSettings.IsChecked = false;
                btnCanSign.IsChecked = false;
                btnCanAccessRoles.IsChecked = false;
                btnCanAccessCertifiers.IsChecked = false;
                DisableControls();
            }
            else
            {
                MessageBox.Show(response.Message, "Error de sistema", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnNew_Click(object sender, RoutedEventArgs e)
        {

            New();
            EnableControls();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var item = sender as Button;
            var model = item.DataContext as RoleModel;
            _id = model.Id;

            txtRoleName.Text = model.Name;
            btnStatus.IsChecked = model.State;
            btnCanMonitor.IsChecked = model.CanAccessMonitor;
            btnCanAnull.IsChecked = model.CanCancel;
            btnCanCompany.IsChecked = model.CanAccessCompanies;
            btnCanUsers.IsChecked = model.CanAccessUsers;
            btnCanLogs.IsChecked = model.CanAccessLogs;
            btnCanSettings.IsChecked = model.CanAccessConfigurations;
            btnCanSign.IsChecked = model.CanSign;
            btnCanAccessRoles.IsChecked = model.CanAccessRoles;
            btnCanAccessCertifiers.IsChecked = model.CanAccessCertifiers;
            EnableControls();
        }
    }
}
