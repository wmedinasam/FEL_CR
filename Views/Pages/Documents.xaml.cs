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
using FELRD.Helpers;
using FELRD.Models;
using WIS_Security;

namespace FELRD.Views.Pages
{
    /// <summary>
    /// Interaction logic for Documents.xaml
    /// </summary>
    public partial class Documents : Page
    {

        private ResponseModel<List<TransactionModel>> documentsRespose = new ResponseModel<List<TransactionModel>>();
        private readonly TransactionModel transactionModel = new TransactionModel();
        public Documents()
        {
            InitializeComponent();

            Loaded += Documents_Loaded;
        }

        private void Documents_Loaded(object sender, RoutedEventArgs e)
        {
            // Cargar opciones del filtro
            cbFilter.Items.Add("1 - Documento SAE");
            cbFilter.Items.Add("2 - Fecha Documento");

            // Ocultar todos los controles al iniciar
            txtNoDocument.Visibility = Visibility.Collapsed;
            startDate.Visibility = Visibility.Collapsed;
            endDate.Visibility = Visibility.Collapsed;
            btnBuscar.Visibility = Visibility.Collapsed;
        }

        private void cbFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbFilter.SelectedItem == null)
                return;

            string selectedFilter = cbFilter.SelectedItem.ToString();

            // Reset visibilidad
            txtNoDocument.Visibility = Visibility.Collapsed;
            startDate.Visibility = Visibility.Collapsed;
            endDate.Visibility = Visibility.Collapsed;
            btnBuscar.Visibility = Visibility.Collapsed;

            if (selectedFilter.StartsWith("1"))
            {
                txtNoDocument.Visibility = Visibility.Visible;
                btnBuscar.Visibility = Visibility.Visible;
            }
            else if (selectedFilter.StartsWith("2"))
            {
                startDate.Visibility = Visibility.Visible;
                endDate.Visibility = Visibility.Visible;
                btnBuscar.Visibility = Visibility.Visible;
            }
        }


        private async void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            if (!ValidarFiltroBusqueda())
                return;

            LoaderOverlay.Visibility = Visibility.Visible;
            await Task.Delay(100);

            string selectedFilter = cbFilter.SelectedItem?.ToString();

            if (selectedFilter.StartsWith("1"))
            {
                if (int.TryParse(txtNoDocument.Text.Trim(), out int documentNumber))
                {
                    await GetDocumentsByNumberAsync(documentNumber);
                }
                else
                {
                    LoaderOverlay.Visibility = Visibility.Collapsed;
                    MessageBox.Show("El número de documento ingresado no es válido.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            else if (selectedFilter.StartsWith("2"))
            {
                string dateInit = startDate.SelectedDate?.ToString("yyyy-MM-dd");
                string dateEnd = endDate.SelectedDate?.ToString("yyyy-MM-dd");

                await GetDocumentsByDatesAsync(dateInit, dateEnd);
            }
        }

        private bool ValidarFiltroBusqueda()
        {
            string selectedFilter = cbFilter.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(selectedFilter))
            {
                MessageBox.Show("Debe seleccionar un filtro.", "Validación", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            if (selectedFilter.StartsWith("1")) // No Documento
            {
                if (string.IsNullOrWhiteSpace(txtNoDocument.Text))
                {
                    MessageBox.Show("Debe ingresar un número de documento.", "Validación", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return false;
                }

                return true; // válido para búsqueda por documento
            }
            else if (selectedFilter.StartsWith("2")) // Fecha Documento
            {
                if (!startDate.SelectedDate.HasValue || !endDate.SelectedDate.HasValue)
                {
                    MessageBox.Show("Debe seleccionar ambas fechas.", "Validación", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return false;
                }

                DateTime start = startDate.SelectedDate.Value.Date;
                DateTime end = endDate.SelectedDate.Value.Date;
                DateTime today = DateTime.Today;

                if (start > today || end > today)
                {
                    MessageBox.Show("Las fechas no pueden ser mayores a la fecha actual.", "Validación", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return false;
                }

                if (start > end)
                {
                    MessageBox.Show("La fecha inicial no puede ser mayor que la fecha final.", "Validación", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return false;
                }

                return true; // válido para búsqueda por fecha
            }

            return false; // filtro no reconocido
        }


        private async Task GetDocumentsByNumberAsync(int documentNumber)
        {
            await Task.Delay(200);

            await Task.Run(() =>
            {
                documentsRespose = transactionModel.GetDocumentsByNumber(documentNumber);
                Dispatcher.Invoke(() =>
                {
                    if (documentsRespose.Success)
                    {
                        grdDocuments.ItemsSource = documentsRespose.Object;
                    }
                    else
                    {
                        MessageBox.Show(documentsRespose.Message, "Error de sistema", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    LoaderOverlay.Visibility = Visibility.Collapsed;
                });

            });
        }

        private async Task GetDocumentsByDatesAsync(string dateInit, string dateEnd)
        {
            await Task.Delay(200);

            await Task.Run(() =>
            {
                documentsRespose = transactionModel.GetDocumentsByDates(dateInit, dateEnd);
                Dispatcher.Invoke(() =>
                {
                    if (documentsRespose.Success)
                    {
                        grdDocuments.ItemsSource = documentsRespose.Object;
                    }
                    else
                    {
                        MessageBox.Show(documentsRespose.Message, "Error de sistema", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    LoaderOverlay.Visibility = Visibility.Collapsed;
                });

            });
        }

        private void BtnViewDetail_Click(object sender, RoutedEventArgs e)
        {
            var row = (sender as FrameworkElement)?.DataContext as TransactionModel;
            if (row != null)
            {
                MessageBox.Show($"Ver detalle del documento con ID {row.Id}", "Detalle", MessageBoxButton.OK, MessageBoxImage.Information);
                // Aquí puedes abrir un modal o nueva pantalla con más detalle
            }
        }

        private void BtnDownloadPDF_Click(object sender, RoutedEventArgs e)
        {
            var row = (sender as FrameworkElement)?.DataContext as TransactionModel;
            if (row != null)
            {
                MessageBox.Show($"Descargar PDF del documento {row.SAEDocumentId}", "Descargar", MessageBoxButton.OK, MessageBoxImage.Information);
                // Aquí iría la lógica real de descarga
            }
        }



    }
}
