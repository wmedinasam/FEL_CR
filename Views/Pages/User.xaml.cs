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
using WIS_Security;

namespace FELRD.Views.Pages
{
    /// <summary>
    /// Lógica de interacción para User.xaml
    /// </summary>
    public partial class User : Page
    {
        private int _id = 0;

        public User()
        {
            InitializeComponent();
            GetUsers();
            GetRoles();
            DisableControls();
        }

        private void GetUsers()
        {
            UserModel userModel = new UserModel();
            var response = userModel.GetUsers();
            if (response.Success)
            {
                grdUser.ItemsSource = response.Object;
            }
            else
            {
                MessageBox.Show(response.Message, "Error de sistema", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void GetRoles()
        {
            RoleModel roleModel = new RoleModel();
            var response = roleModel.Get();
            if (response.Success)
            {
                cbRoles.ItemsSource = response.Object;
                cbRoles.DisplayMemberPath = "Name";
                cbRoles.SelectedValuePath = "Id";
            }
            else
            {
                MessageBox.Show(response.Message, "Error del sistema", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void EnableControls()
        {
            txtName.IsEnabled = true;
            txtUsername.IsEnabled = true;
            txtPassword.IsEnabled = true;
            txtConfirmPassword.IsEnabled = true;
            btnStatus.IsEnabled = true;
            cbRoles.IsEnabled = true;
            btnAceptar.IsEnabled = true;
        }
        private void DisableControls()
        {
            txtName.IsEnabled = false;
            txtUsername.IsEnabled = false;
            txtPassword.IsEnabled = false;
            txtConfirmPassword.IsEnabled = false;
            btnStatus.IsEnabled = false;
            btnAceptar.IsEnabled = false;
            cbRoles.IsEnabled = false;

        }
        private void btnAceptar_Click(object sender, RoutedEventArgs e)
        {
            UserModel model = new UserModel();
            model.Id = _id;
            model.FullName = txtName.Text;
            model.UserName = txtUsername.Text;
            model.UserPassword = txtPassword.Password.EncriptarDatos();
            model.UserStatus = btnStatus.IsChecked.Value;
            model.role = cbRoles.SelectedItem as RoleModel;

            ResponseModel<object> response = new ResponseModel<object>();
            if (_id == 0)
            {
                response = model.Create(model);
            }
            else
            {
                response = model.Update(model);
            }

            if (response.Success)
            {
                MessageBox.Show("Usuario guardado correctamente", "Sistema", MessageBoxButton.OK, MessageBoxImage.Information);
                GetUsers();

                _id = 0;
                txtName.Text = string.Empty;
                txtUsername.Text = string.Empty;
                txtPassword.Password = string.Empty;
                txtConfirmPassword.Password = string.Empty;
                cbRoles.SelectedIndex = -1;
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
            txtUsername.Text = string.Empty;
            txtPassword.Password = string.Empty;
            txtConfirmPassword.Password = string.Empty;
            cbRoles.SelectedIndex = -1;
            btnStatus.IsChecked = true;
            EnableControls();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var item = sender as Button;
            var model = item.DataContext as UserModel;
            _id = model.Id;
            txtName.Text = model.FullName;
            txtUsername.Text = model.UserName;
            txtPassword.Password = model.UserPassword.DesencriptarDatos();
            txtConfirmPassword.Password = model.UserPassword.DesencriptarDatos();
            btnStatus.IsChecked = model.UserStatus;
            cbRoles.SelectedValue = model.role.Id;

            EnableControls();
        }
    }
}
