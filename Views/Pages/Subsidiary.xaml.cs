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
using FELRD.Helpers;
using System.Xml.Linq;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace FELRD.Views.Pages
{
    /// <summary>
    /// Lógica de interacción para Subsidiary.xaml
    /// </summary>
    public partial class Subsidiary : Page
    {
        int _id = 0;
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
        public Subsidiary()
        {
            InitializeComponent();
            Loaded += User_Loaded;

        }

        private async void User_Loaded(object sender, RoutedEventArgs e)
        {
            DisableControllers();
            await GetCountriesAsync();
            await GetUsersAsync();
            await GetSubsidiariesAsync();

        }


        private async Task GetUsersAsync()
        {
            LoaderOverlay.Visibility = Visibility.Visible;
            await Task.Delay(200);

            await Task.Run(() =>
            {

                CompanyModel company = new CompanyModel();
                var response = company.Get();
                Dispatcher.Invoke(() =>
                {

                    if (response.Success)
                    {
                        cbCompanies.ItemsSource = response.Object;
                        cbCompanies.DisplayMemberPath = "Name";
                        cbCompanies.SelectedValuePath = "Id";
                    }
                    else
                    {
                        MessageBox.Show(response.Message, "Error del sistema", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    LoaderOverlay.Visibility = Visibility.Collapsed;
                });

            });
        }

        private Task GetCountriesAsync()
        {
            cbCountry.IsEnabled = false;
            LoaderOverlay.Visibility = Visibility.Visible;

            // No necesitamos Task.Run porque esto es inmediato
            cbCountry.ItemsSource = EnumHelper.GetEnumItems<Models.Helpers.AmericaCountries>();
            cbCountry.DisplayMemberPath = "Description";
            cbCountry.SelectedValuePath = "Code";
            cbCountry.Items.Refresh();

            cbCountry.IsEnabled = true;
            LoaderOverlay.Visibility = Visibility.Collapsed;

            return Task.CompletedTask;
        }


        private async Task GetSubsidiariesAsync()
        {

            LoaderOverlay.Visibility = Visibility.Visible;
            await Task.Delay(200);

            await Task.Run(() =>
            {
                SubsidiaryModel model = new SubsidiaryModel();
                var response = model.Get();
                Dispatcher.Invoke(() =>
                {
                    if (response.Success)
                    {
                        grdSubsidiary.ItemsSource = response.Object;
                    }
                    else
                    {
                        MessageBox.Show(response.Message, "Error del sistema", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    LoaderOverlay.Visibility = Visibility.Collapsed;
                });


            });
        }
        private void ClearControllers()
        {
            _id = 0;
            cbCompanies.SelectedIndex = -1;
            txtEstablishmentName.Text = string.Empty;
            txtEstablishmentCode.Text = string.Empty;
            txtPostalCode.Text = string.Empty;
            cbCountry.SelectedIndex = -1;
            txtSubsidiaryFolder.Text = string.Empty;
        }
        private void EnableControllers()
        {
            cbCompanies.IsEnabled = true;
            txtEstablishmentName.IsEnabled = true;
            txtEstablishmentCode.IsEnabled = true;
            txtPostalCode.IsEnabled = true;
            cbCountry.IsEnabled = true;
            txtSubsidiaryFolder.IsEnabled = true;
            btnAceptar.IsEnabled = true;
            btnFolder.IsEnabled = true;
        }
        private void DisableControllers()
        {
            cbCompanies.IsEnabled = false;
            txtEstablishmentName.IsEnabled = false;
            txtEstablishmentCode.IsEnabled = false;
            txtPostalCode.IsEnabled = false;
            cbCountry.IsEnabled = false;
            txtSubsidiaryFolder.IsEnabled = false;
            btnAceptar.IsEnabled = false;
            btnFolder.IsEnabled = false;
        }
        private void btnNew_Click(object sender, RoutedEventArgs e)
        {
            ClearControllers();
            EnableControllers();
        }

        private void btnAceptar_Click(object sender, RoutedEventArgs e)
        {

            var fieldsToValidate = new List<Control>
            {
                txtEstablishmentCode,
                txtPostalCode,
                txtEstablishmentName,
                txtSubsidiaryFolder,
                cbCompanies,
                cbCountry
            };

            if (ValidationHelper.HasValidationErrors(fieldsToValidate))
            {
                MessageBox.Show("Por favor completa todos los campos requeridos.", "Campos vacíos", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            SubsidiaryModel subsidiaryModel = new SubsidiaryModel();
            subsidiaryModel.Id = _id;
            subsidiaryModel.Company = cbCompanies.SelectedItem as CompanyModel;
            subsidiaryModel.EstablishmentName = txtEstablishmentName.Text;
            subsidiaryModel.EstablishmentCode = txtEstablishmentCode.Text;
            subsidiaryModel.PostalCode = txtPostalCode.Text;
            subsidiaryModel.Country = cbCountry.SelectedValue?.ToString();
            subsidiaryModel.SubsidiaryFolder = txtSubsidiaryFolder.Text;
            ResponseModel<SubsidiaryModel> response = new ResponseModel<SubsidiaryModel>();
            if (_id == 0)
            {
                response = subsidiaryModel.Action("Add", subsidiaryModel);
            }
            else
            {
                response = subsidiaryModel.Action("Update", subsidiaryModel);
            }
            if (response.Success)
            {
                _ = GetUsersAsync();
                _ = GetSubsidiariesAsync();
                _ = GetCountriesAsync();
                ClearControllers();
                DisableControllers();
            }
            else
            {
                MessageBox.Show(response.Message, "Error del sistema", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var item = sender as Button;
            var model = item.DataContext as SubsidiaryModel;
            if (model != null)
            {
                _id = model.Id;


                txtEstablishmentName.Text = model.EstablishmentName;
                txtEstablishmentCode.Text = model.EstablishmentCode;
                txtPostalCode.Text = model.PostalCode;
                txtSubsidiaryFolder.Text = model.SubsidiaryFolder;
                EnableControllers();

                Dispatcher.InvokeAsync(async () =>
                {
                    await Task.Delay(50);
                    cbCompanies.SelectedValue = model.Company.Id;
                    cbCountry.SelectedValue = model.Country;
                });
            }
        }


        private void BrowseSubsidiaryFolder_Click(object sender, RoutedEventArgs e)
        {
            using (var dialog = new System.Windows.Forms.FolderBrowserDialog())
            {
                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    txtSubsidiaryFolder.Text = dialog.SelectedPath;
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
