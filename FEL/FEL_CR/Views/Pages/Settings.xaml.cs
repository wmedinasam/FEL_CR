using FELCR.Helpers;
using FELCR.Models;
using FELCR.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
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
using WIS_Security.DAO;

namespace FELCR.Views.Pages
{
    /// <summary>
    /// Lógica de interacción para Settings.xaml
    /// </summary>
    public partial class Settings : Page
    {
        int sliderValue = 0;
        public bool isFirstTime = false;
        public string SyncDescription { get; set; }
        string _id = string.Empty;
        public Settings()
        {
            InitializeComponent();
        }
        private void GetConfigurations()
        {
            ConfigurationModel config = new ConfigurationModel();
            var configuration = config.GetConfiguration();
            if (configuration.Success)
            {
                txtSQLUsername.Text = configuration.Object.User;
                txtSQLPassword.Password = configuration.Object.Password;
                txtMasterPassword.Password = configuration.Object.MasterPassword;
                txtSystemKey.Text = JsonSerializer.Serialize(configuration.Object.Key).EncriptarDatos();
                sliderValue = configuration.Object.SyncTime == 0 ? 5 : configuration.Object.SyncTime;
                string valueDescription = $"Valor Actual: {sliderValue.ToString("0")} Segundos";
                SyncTime.Value = sliderValue;
                lblValue.Text = valueDescription;
            }
            else
            {
                MessageService.ShowError("Error de Sistema", configuration.Message);
            }
        }
        private void GetSettings()
        {
            SettingModel settingModel = new SettingModel();
            var settingsResponse = settingModel.GetSettings();
            if (settingsResponse.Success)
            {
                grdSettings.ItemsSource = settingsResponse.Object;
            }
            else
            {
                MessageService.ShowError("Error de Sistema", settingsResponse.Message);
            }
        }
        private void SyncTime_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            var slider = sender as Slider;
            double value = slider.Value;
            string valueDescription = $"Valor Actual: {value.ToString("0")} Segundos";
            lblValue.Text = valueDescription;
            sliderValue = Convert.ToInt32(value);
        }

        private void btnSaveConfig_Click(object sender, RoutedEventArgs e)
        {
            var fieldsToValidate = new List<Control>
            {
                txtSQLUsername,
                txtSQLPassword,
                txtMasterPassword,
                txtSystemKey
            };

            if (ValidationHelper.HasValidationErrors(fieldsToValidate))
            {
                MessageService.ShowWarning("Error de validación", "Por favor completa todos los campos requeridos.");
                return;
            }

            ConfigurationModel configModel = new ConfigurationModel
            {
                User = txtSQLUsername.Text,
                Password = txtSQLPassword.Password,
                SyncTime = sliderValue,
                MasterPassword = txtMasterPassword.Password
            };

            string llave = txtSystemKey.Text.DesencriptarDatos();
            try
            {
                configModel.Key = JsonSerializer.Deserialize<KeyModel>(llave);
            }
            catch (Exception ex)
            {
                MessageService.ShowError("Error de Sistema", $"Llave inválida: {ex.Message}");
                return;
            }

            if (configModel.Key == null || configModel.Key.Sistema != "FELCR")
            {
                MessageService.ShowError("Error de Sistema", "La llave ingresada no corresponde a este sistema");
                return;
            }

            var response = DaoConnection.TestConnection(configModel.User, configModel.Password, configModel.Key.Instancia);
            if (!response.Success)
            {
                MessageService.ShowError("Error de Sistema", response.Message);
                return;
            }

            var responseSave = configModel.SaveConfiguration(configModel);
            if (!responseSave.Success)
            {
                MessageService.ShowError("Error de Sistema", responseSave.Message);
                return;
            }

            MessageService.ShowInfo("Configuración", "Configuraciones Guardadas Correctamente\nCierre el programa y Vuelvalo a abrir para ver el cambio");
        }

        private void btnSaveApi_Click(object sender, RoutedEventArgs e)
        {
            var fieldsToValidate = new List<Control>
            {
                txtSystemKey,
                txtValue
            };

            if (ValidationHelper.HasValidationErrors(fieldsToValidate))
            {
                MessageService.ShowWarning("Error de validación", "Por favor completa todos los campos requeridos.");
                return;
            }

            SettingModel settingModel = new SettingModel();
            settingModel.Id = _id;
            settingModel.Key = txtKey.Text;
            settingModel.Value = txtValue.Text;
            settingModel.Description = txtDescription.Text;
            var action = _id == string.Empty ? "Insert" : "Update";
            var settingsResponseMake = settingModel.ActionSetting(action, settingModel);
            if (settingsResponseMake.Success)
            {
                MessageService.ShowSuccess("Éxito!", "Configuraciones Guardadas Correctamente");
                GetSettings();
                DisableControlls();
                _id = string.Empty;
                txtKey.Text = string.Empty;
                txtValue.Text = string.Empty;
                txtDescription.Text = string.Empty;
            }
            else
            {
                MessageService.ShowError("Error de Sistema", settingsResponseMake.Message);
            }
        }
        private void DisableControlls()
        {
            txtKey.IsEnabled = false;
            txtValue.IsEnabled = false;
            txtDescription.IsEnabled = false;
            btnSaveApi.IsEnabled = false;
        }
        private void EnableControlls()
        {
            txtKey.IsEnabled = true;
            txtValue.IsEnabled = true;
            txtDescription.IsEnabled = true;
            btnSaveApi.IsEnabled = true;
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if (!isFirstTime)
            {
                sliderValue = 5;
                lblValue.Text = $"Valor Actual: {sliderValue.ToString("0")} Segundos";
                GetConfigurations();
                GetSettings();
                DisableControlls();
                btnNewConfig.IsEnabled = true;
            }
            else
            {
                DisableControlls();
                btnNewConfig.IsEnabled = false;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var item = sender as Button;
            var model = item.DataContext as SettingModel;
            _id = model.Id;
            txtKey.Text = model.Key;
            txtValue.Text = model.Value;
            txtDescription.Text = model.Description;
            EnableControlls();
        }

        private void btnNewConfig_Click(object sender, RoutedEventArgs e)
        {
            _id = string.Empty;
            txtKey.Text = string.Empty;
            txtValue.Text = string.Empty;
            txtDescription.Text = string.Empty;
            EnableControlls();

        }

        private bool FieldsValidation(Control control)
        {
            bool hasError = false;

            if (control is TextBox textBox)
            {
                if (string.IsNullOrWhiteSpace(textBox.Text))
                {
                    textBox.BorderBrush = Brushes.Red;
                    hasError = true;
                }
                else
                {
                    textBox.BorderBrush = Brushes.Gray;
                }
            }
            else if (control is PasswordBox passwordBox)
            {
                if (string.IsNullOrWhiteSpace(passwordBox.Password))
                {
                    passwordBox.BorderBrush = Brushes.Red;
                    hasError = true;
                }
                else
                {
                    passwordBox.BorderBrush = Brushes.Gray;
                }
            }

            return hasError;
        }

    }
}
