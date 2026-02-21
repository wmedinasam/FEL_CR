using FELCR.Helpers;
using FELCR.Models;
using FELCR.Services;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using WIS_Security;

namespace FELCR.Views.Pages
{
    /// <summary>
    /// Lógica de interacción para User.xaml
    /// </summary>
    public partial class User : Page, INotifyPropertyChanged
    {
        private int _id = 0;
        private bool _isLoading;

        public bool IsLoading
        {
            get => _isLoading;
            set
            {
                _isLoading = value;
                OnPropertyChanged();
            }
        }

        public User()
        {
            InitializeComponent();
            Loaded += User_Loaded;
        }

        private async void User_Loaded(object sender, RoutedEventArgs e)
        {
            DisableControls();
            await GetRolesAsync();
            await GetUsersAsync();

        }



        private async Task GetUsersAsync()
        {
            LoaderOverlay.Visibility = Visibility.Visible;
            await Task.Delay(200); // pequeño respiro visual

            await Task.Run(() =>
            {
                UserModel userModel = new UserModel();
                var response = userModel.GetUsers();

                Dispatcher.Invoke(() =>
                {
                    if (response.Success)
                    {
                        grdUser.ItemsSource = response.Object;
                    }
                    else
                    {
                        MessageService.ShowError("Error de Sistema", response.Message);
                    }
                    LoaderOverlay.Visibility = Visibility.Collapsed;
                });
            });
        }

        private async Task GetRolesAsync()
        {
            LoaderOverlay.Visibility = Visibility.Visible;
            await Task.Delay(200); // pequeño respiro visual

            await Task.Run(() =>
            {
                RoleModel roleModel = new RoleModel();
                var response = roleModel.Get();

                Dispatcher.Invoke(() =>
                {
                    if (response.Success)
                    {
                        cbRoles.ItemsSource = response.Object;
                        cbRoles.DisplayMemberPath = "Name";
                        cbRoles.SelectedValuePath = "Id";
                    }
                    else
                    {
                        MessageService.ShowError("Error de Sistema", response.Message);
                    }
                    LoaderOverlay.Visibility = Visibility.Collapsed;

                });
            });
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
            var fieldsToValidate = new List<Control>
            {
                txtName,
                txtUsername,
                txtPassword,
                txtConfirmPassword
            };

            if (ValidationHelper.HasValidationErrors(fieldsToValidate))
            {
                MessageService.ShowWarning("Error de validación", "Por favor completa todos los campos requeridos.");
                return;
            }

            string password = txtPassword.Password;
            string confirmPassword = txtConfirmPassword.Password;

            if (!ValidationHelper.IsPasswordComplex(txtPassword))
            {
                MessageService.ShowWarning("Contraseña no segura", "La contraseña debe tener al menos 6 caracteres, una mayúscula, un número y un símbolo.");
                return;
            }

            if (!ValidationHelper.ArePasswordsMatching(txtPassword, txtConfirmPassword))
            {
                MessageService.ShowWarning("Error de confirmación", "Las contraseñas no coinciden.");
                return;
            }

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
                MessageService.ShowSuccess("Exito!", "Usuario guardado correctamente");
                _ = GetUsersAsync();

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
                MessageService.ShowError("Error de Sistema", response.Message);
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

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}

