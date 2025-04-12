using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace FELRD.Views.Pages
{
    public class HomeViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string _licenceText;
        public string LicenceText
        {
            get => _licenceText;
            set { _licenceText = value; OnPropertyChanged(nameof(LicenceText)); }
        }

        private Brush _licenceBrush;
        public Brush LicenceBrush
        {
            get => _licenceBrush;
            set { _licenceBrush = value; OnPropertyChanged(nameof(LicenceBrush)); }
        }

        private Visibility _alertVisibility = Visibility.Collapsed;
        public Visibility AlertVisibility
        {
            get => _alertVisibility;
            set { _alertVisibility = value; OnPropertyChanged(nameof(AlertVisibility)); }
        }

        private string _alertText = "¡Tu sistema dejará de funcionar pronto!";
        public string AlertText
        {
            get => _alertText;
            set { _alertText = value; OnPropertyChanged(nameof(AlertText)); }
        }

        private string _documentsText = "0";
        public string DocumentsText
        {
            get => _documentsText;
            set
            {
                _documentsText = value;
                OnPropertyChanged(nameof(DocumentsText));
            }
        }

        protected void OnPropertyChanged(string name) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
