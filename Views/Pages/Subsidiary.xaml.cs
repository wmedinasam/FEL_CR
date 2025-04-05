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
    /// Lógica de interacción para Subsidiary.xaml
    /// </summary>
    public partial class Subsidiary : Page
    {
        int _id = 0;
        public Subsidiary()
        {
            InitializeComponent();
            GetCompanies();
            GetCountries();
            GetSubsidiaries();
        }

        private void GetCompanies()
        {
            CompanyModel company = new CompanyModel();
            var response = company.Get();
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
        }

        private void GetCountries()
        {
            cbCountry.ItemsSource = Enum.GetValues(typeof(Models.Helpers.Countries)).Cast<Models.Helpers.Countries>();
        }


        private void GetSubsidiaries()
        {
            SubsidiaryModel model = new SubsidiaryModel();
            var response = model.Get();
            if (response.Success)
            {
                grdSubsidiary.ItemsSource = response.Object;
            }
            else
            {
                MessageBox.Show(response.Message, "Error del sistema", MessageBoxButton.OK, MessageBoxImage.Error);
            }

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
        }
        private void btnNew_Click(object sender, RoutedEventArgs e)
        {
            ClearControllers();
            EnableControllers();
        }

        private void btnAceptar_Click(object sender, RoutedEventArgs e)
        {
            SubsidiaryModel subsidiaryModel = new SubsidiaryModel();
            subsidiaryModel.Id = _id;
            subsidiaryModel.Company = cbCompanies.SelectedItem as CompanyModel;
            subsidiaryModel.EstablishmentName = txtEstablishmentName.Text;
            subsidiaryModel.EstablishmentCode = txtEstablishmentCode.Text;
            subsidiaryModel.PostalCode = txtPostalCode.Text;
            subsidiaryModel.Country = cbCountry.Text;
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
                GetCompanies();
                GetSubsidiaries();
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
                cbCompanies.SelectedValue = model.Company.Id;
                txtEstablishmentName.Text = model.EstablishmentName;
                txtEstablishmentCode.Text = model.EstablishmentCode;
                txtPostalCode.Text = model.PostalCode;
                cbCountry.Text = model.Country;
                txtSubsidiaryFolder.Text = model.SubsidiaryFolder;
                EnableControllers();
            }
        }
    }
}
