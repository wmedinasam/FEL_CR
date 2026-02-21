using FELCR.Helpers;
using FELCR.Models;
using FELCR.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace FELCR.Views.Pages
{
    /// <summary>
    /// Lógica de interacción para Company.xaml
    /// </summary>
    public partial class Company : Page
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
        public Company()
        {
            InitializeComponent();
            Loaded += User_Loaded;
        }

        private async void User_Loaded(object sender, RoutedEventArgs e)
        {
            DisableControllers();
            await GetCompaniesAsync();
            await GetCertifiersAsync();

        }

        private async Task GetCompaniesAsync()
        {

            LoaderOverlay.Visibility = Visibility.Visible;
            await Task.Delay(200);

            await Task.Run(() =>
            {
                CompanyModel companyModel = new CompanyModel();
                var response = companyModel.Get();
                Dispatcher.Invoke(() =>
                {
                    if (response.Success)
                    {
                        grdCompany.ItemsSource = response.Object;
                    }
                    else
                    {
                        MessageService.ShowError("Error de Sistema", response.Message);
                    }
                    LoaderOverlay.Visibility = Visibility.Collapsed;
                });

            });


        }


        private async Task GetCertifiersAsync()
        {
            LoaderOverlay.Visibility = Visibility.Collapsed;
            await Task.Delay(200);
            await Task.Run(() =>
            {
                CertificadorModel model = new CertificadorModel();
                var response = model.Get();
                Dispatcher.Invoke(() =>
                {
                    if (response.Success)
                    {
                        cbCertifiers.ItemsSource = response.Object;
                        cbCertifiers.DisplayMemberPath = "Name";
                        cbCertifiers.SelectedValuePath = "Id";
                    }
                    else
                    {
                        MessageService.ShowError("Error de Sistema", response.Message);
                    }
                    LoaderOverlay.Visibility = Visibility.Collapsed;
                });
            });


        }

        private void ClearControllers()
        {
            _id = 0;
            txtTaxId.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtMunicipality.Text = string.Empty;
            txtProvince.Text = string.Empty;
            txtPhone.Text = string.Empty;
            txtDTEFolder.Text = string.Empty;
            txtDBSae.Text = string.Empty;
            txtSuffixTable.Text = string.Empty;
            cbCertifiers.SelectedIndex = -1;
            txtName.Text = string.Empty;
        }

        private void EnableControllers()
        {
            txtTaxId.IsEnabled = true;
            txtAddress.IsEnabled = true;
            txtMunicipality.IsEnabled = true;
            txtProvince.IsEnabled = true;
            txtPhone.IsEnabled = true;
            txtDTEFolder.IsEnabled = true;
            txtDBSae.IsEnabled = true;
            txtSuffixTable.IsEnabled = true;
            btnAceptar.IsEnabled = true;
            cbCertifiers.IsEnabled = true;
            txtName.IsEnabled = true;
            btnFolder.IsEnabled = true;
        }
        private void DisableControllers()
        {
            txtTaxId.IsEnabled = false;
            txtAddress.IsEnabled = false;
            txtMunicipality.IsEnabled = false;
            txtProvince.IsEnabled = false;
            txtPhone.IsEnabled = false;
            txtDTEFolder.IsEnabled = false;
            txtDBSae.IsEnabled = false;
            txtSuffixTable.IsEnabled = false;
            btnAceptar.IsEnabled = false;
            cbCertifiers.IsEnabled = false;
            txtName.IsEnabled = false;
            btnFolder.IsEnabled = false;
        }

        private void btnAceptar_Click(object sender, RoutedEventArgs e)
        {

            var fieldsToValidate = new List<Control>
            {
                txtTaxId,
                txtName,
                txtAddress,
                txtMunicipality,
                txtProvince,
                txtPhone,
                txtDBSae,
                txtSuffixTable,
                txtDTEFolder,
                cbCertifiers
            };

            if (ValidationHelper.HasValidationErrors(fieldsToValidate))
            {
                MessageService.ShowWarning("Error de validación", "Por favor completa todos los campos requeridos.");
                return;
            }

            CompanyModel companyModel = new CompanyModel();
            companyModel.Id = _id;
            companyModel.Nit = txtTaxId.Text;
            companyModel.Address = txtAddress.Text;
            companyModel.Municipality = txtMunicipality.Text;
            companyModel.Province = txtProvince.Text;
            companyModel.Phone = txtPhone.Text;
            companyModel.DTEFolder = txtDTEFolder.Text;
            companyModel.DBSAE = txtDBSae.Text;
            companyModel.SuffixTable = txtSuffixTable.Text;
            companyModel.Name = txtName.Text;
            companyModel.Certificador = cbCertifiers.SelectedItem as CertificadorModel;
            ResponseModel<CompanyModel> response = new ResponseModel<CompanyModel>();
            if (_id == 0)
            {
                response = companyModel.Action("Add", companyModel);
            }
            else
            {
                response = companyModel.Action("Update", companyModel);
            }
            if (response.Success)
            {
                MessageService.ShowSuccess("Éxito!", "Empresa guardada con éxito.");
                _ = GetCompaniesAsync();
                _ = GetCertifiersAsync();
                ClearControllers();
                DisableControllers();
            }
            else
            {
                MessageService.ShowError("Error de Sistema", response.Message);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var item = sender as Button;
            var model = item.DataContext as CompanyModel;
            if (model != null)
            {
                _id = model.Id;
                txtTaxId.Text = model.Nit;
                txtAddress.Text = model.Address;
                txtMunicipality.Text = model.Municipality;
                txtProvince.Text = model.Province;
                txtPhone.Text = model.Phone;
                txtDTEFolder.Text = model.DTEFolder;
                txtDBSae.Text = model.DBSAE;
                txtSuffixTable.Text = model.SuffixTable;
                cbCertifiers.SelectedValue = model.Certificador.Id;
                txtName.Text = model.Name;
                EnableControllers();
            }
        }

        private void btnNew_Click(object sender, RoutedEventArgs e)
        {
            ClearControllers();
            EnableControllers();
        }



        private void BrowseCompanyFolder_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new System.Windows.Forms.FolderBrowserDialog();
            System.Windows.Forms.DialogResult result = dialog.ShowDialog();

            if (result == System.Windows.Forms.DialogResult.OK && !string.IsNullOrWhiteSpace(dialog.SelectedPath))
            {
                txtDTEFolder.Text = dialog.SelectedPath;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
