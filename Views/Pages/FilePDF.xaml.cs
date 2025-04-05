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
using System.Windows.Shapes;

namespace FELRD.Views.Pages
{
    /// <summary>
    /// Lógica de interacción para FilePDF.xaml
    /// </summary>
    public partial class FilePDF : Window
    {
        string url;
        string uuid;
        public FilePDF(string url, string uuid)
        {
            InitializeComponent();
            this.url = url;
            this.uuid = uuid;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //string temp = System.IO.Path.GetTempPath();
            string remoteUri = url + uuid + "&formato=pdf";
            //WebClient webClient = new WebClient();
            //webClient.DownloadFile(remoteUri, temp + "PDF_FEL_" + uuid + ".pdf");
            //string uri = temp + @"PDF_FEL_" + uuid + ".pdf";
            //webClient.Dispose();
            if (remoteUri != null)
            {
                wbPDF.Navigate(remoteUri);
            }
            this.Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //wbPDF.Dispose();
            //string temp = System.IO.Path.GetTempPath();
            ////wbPDF.Dispose();
            //if (File.Exists(temp + @"PDF_FEL_" + uuid + ".pdf"))
            //{
            //    wbPDF.Dispose();
            //    Thread.Sleep(3000);
            //    try
            //    {
            //        File.Delete(temp + @"PDF_FEL_" + uuid + ".pdf");
            //    }
            //    catch (Exception ex)
            //    {
            //        System.Windows.MessageBox.Show(ex.Message);
            //    }
            //}
        }
    }
}
