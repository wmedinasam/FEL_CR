using FELRD.Models;
using System.Windows;
using System.Windows.Controls;
using WIS_Security;

namespace FELRD.Views.Pages
{
    /// <summary>
    /// Lógica de interacción para Company.xaml
    /// </summary>
    public partial class Company : Page
    {
        int _id = 0;
        public Company()
        {
            InitializeComponent();
            GetCompanies();
            GetCertifiers();
            DisableControllers();
        }

        private void GetCompanies()
        {
            CompanyModel companyModel = new CompanyModel();
            var response = companyModel.Get();
            if (response.Success)
            {
                grdCompany.ItemsSource = response.Object;
            }
            else
            {
                MessageBox.Show(response.Message, "Error del sistema", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private void GetCertifiers()
        {
            CertificadorModel model = new CertificadorModel();
            var response = model.Get();
            if (response.Success)
            {
                cbCertifiers.ItemsSource = response.Object;
                cbCertifiers.DisplayMemberPath = "Name";
                cbCertifiers.SelectedValuePath = "Id";
            }
            else
            {
                MessageBox.Show(response.Message, "Error del sistema", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ClearControllers()
        {
            _id = 0;
            txtTaxId.Text = string.Empty;
            txtPrefix.Text = string.Empty;
            txtDTEFolder.Text = string.Empty;
            txtDBSae.Text = string.Empty;
            txtSuffixTable.Text = string.Empty;
            cbCertifiers.SelectedIndex = -1;
            txtName.Text = string.Empty;
        }

        private void EnableControllers()
        {
            txtTaxId.IsEnabled = true;
            txtPrefix.IsEnabled = true;
            txtDTEFolder.IsEnabled = true;
            txtDBSae.IsEnabled = true;
            txtSuffixTable.IsEnabled = true;
            btnAceptar.IsEnabled = true;
            cbCertifiers.IsEnabled = true;
            txtName.IsEnabled = true;
        }
        private void DisableControllers()
        {
            txtTaxId.IsEnabled = false;
            txtPrefix.IsEnabled = false;
            txtDTEFolder.IsEnabled = false;
            txtDBSae.IsEnabled = false;
            txtSuffixTable.IsEnabled = false;
            btnAceptar.IsEnabled = false;
            cbCertifiers.IsEnabled = false;
            txtName.IsEnabled = false;
        }

        private void btnAceptar_Click(object sender, RoutedEventArgs e)
        {
            CompanyModel companyModel = new CompanyModel();
            companyModel.Id = _id;
            companyModel.Nit = txtTaxId.Text;
            companyModel.Prefix = txtPrefix.Text;
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
                GetCompanies();
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
            var model = item.DataContext as CompanyModel;
            if (model != null)
            {
                _id = model.Id;
                txtTaxId.Text = model.Nit;
                txtPrefix.Text = model.Prefix;
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
    }
}
