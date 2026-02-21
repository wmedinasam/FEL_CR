using System.Windows.Controls;

namespace FELCR.Controls
{
    /// <summary>
    /// Lógica de interacción para UserPopup.xaml
    /// </summary>
    public partial class UserPopup : UserControl
    {
        public UserPopup()
        {
            InitializeComponent();
        }

        public string Text
        {
            get => PopupText.Text;
            set => PopupText.Text = value;
        }
    }
}
