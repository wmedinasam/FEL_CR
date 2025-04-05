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

namespace FELRD.Views
{
    /// <summary>
    /// Lógica de interacción para wdwWIS_OKCancel.xaml
    /// </summary>
    public partial class wdwWIS_OKCancel : Window
    {
        public bool Ok = false;

        public wdwWIS_OKCancel(string title, string content)
        {
            InitializeComponent();
            FillInfo(title, content);
        }

        public void FillInfo(string Titulo, string Contenido)
        {
            lblTitle.Content = Titulo;
            txtContent.Text = Contenido;
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            Ok = true;
            this.Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Ok = false;
            this.Close();
        }


    }
}
