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

namespace FELCR.Controls
{
    /// <summary>
    /// Interaction logic for customMessageBox.xaml
    /// </summary>
    public partial class customMessageBox : Window
    {
        public enum CustomMessageBoxResult
        {
            None,
            Ok,
            Cancel,
            Yes,
            No
        }

        public enum MessageBoxType
        {
            Info,
            Success,
            Warning,
            Error,
            Confirm
        }

        public enum MessageBoxButtons
        {
            Ok,
            YesNo
        }

        private CustomMessageBoxResult _result = CustomMessageBoxResult.None;

        public customMessageBox(string title, string message, MessageBoxType type = MessageBoxType.Info, MessageBoxButtons buttons = MessageBoxButtons.Ok)
        {
            InitializeComponent();
            TxtTitle.Text = title;
            TxtMessage.Text = message;

            ApplyStyleByType(type);
            SetupButtons(buttons);
        }

        public static CustomMessageBoxResult Show(string title, string message, MessageBoxType type = MessageBoxType.Info, MessageBoxButtons buttons = MessageBoxButtons.Ok)
        {
            var msgBox = new customMessageBox(title, message, type, buttons);
            msgBox.ShowDialog();
            return msgBox._result;
        }

        private void BtnOk_Click(object sender, RoutedEventArgs e)
        {
            _result = BtnOk.Content.ToString() == "Sí" ? CustomMessageBoxResult.Yes : CustomMessageBoxResult.Ok;
            this.Close();
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            _result = BtnCancel.Content.ToString() == "No" ? CustomMessageBoxResult.No : CustomMessageBoxResult.Cancel;
            this.Close();
        }

        private void ApplyStyleByType(MessageBoxType type)
        {
            switch (type)
            {
                case MessageBoxType.Info:
                    MainContainer.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#1E2634"));
                    AnimatedIcon.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#2196F3"));
                    AnimatedIcon.Data = Geometry.Parse("M440-280h80v-240h-80v240Zm40-320q17 0 28.5-11.5T520-640q0-17-11.5-28.5T480-680q-17 0-28.5 11.5T440-640q0 17 11.5 28.5T480-600Zm0 520q-83 0-156-31.5T197-197q-54-54-85.5-127T80-480q0-83 31.5-156T197-763q54-54 127-85.5T480-880q83 0 156 31.5T763-763q54 54 85.5 127T880-480q0 83-31.5 156T763-197q-54 54-127 85.5T480-80Zm0-80q134 0 227-93t93-227q0-134-93-227t-227-93q-134 0-227 93t-93 227q0 134 93 227t227 93Zm0-320Z");
                    break;

                case MessageBoxType.Success:
                    MainContainer.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#1E3B1E"));
                    AnimatedIcon.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#4CAF50"));
                    AnimatedIcon.Data = Geometry.Parse("m424-296 282-282-56-56-226 226-114-114-56 56 170 170Zm56 216q-83 0-156-31.5T197-197q-54-54-85.5-127T80-480q0-83 31.5-156T197-763q54-54 127-85.5T480-880q83 0 156 31.5T763-763q54 54 85.5 127T880-480q0 83-31.5 156T763-197q-54 54-127 85.5T480-80Zm0-80q134 0 227-93t93-227q0-134-93-227t-227-93q-134 0-227 93t-93 227q0 134 93 227t227 93Zm0-320Z");
                    break;

                case MessageBoxType.Warning:
                    MainContainer.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#3B3315"));
                    AnimatedIcon.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFC107"));
                    AnimatedIcon.Data = Geometry.Parse("M1 21h22L12 2 1 21zm12-3h-2v-2h2v2zm0-4h-2v-4h2v4z");
                    break;

                case MessageBoxType.Error:
                    MainContainer.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#3B1D1D"));
                    AnimatedIcon.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#F44336"));
                    AnimatedIcon.Data = Geometry.Parse("M12 2C6.48 2 2 6.48 2 12s4.48 10 10 10 10-4.48 10-10S17.52 2 12 2zm5 13.59L15.59 17 12 13.41 8.41 17 7 15.59 10.59 12 7 8.41 8.41 7 12 10.59 15.59 7 17 8.41 13.41 12 17 15.59z");
                    break;
                case MessageBoxType.Confirm:
                    MainContainer.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#1E2634"));
                    AnimatedIcon.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#00BCD4"));
                    AnimatedIcon.Data = Geometry.Parse("M478-240q21 0 35.5-14.5T528-290q0-21-14.5-35.5T478-340q-21 0-35.5 14.5T428-290q0 21 14.5 35.5T478-240Zm-36-154h74q0-33 7.5-52t42.5-52q26-26 41-49.5t15-56.5q0-56-41-86t-97-30q-57 0-92.5 30T342-618l66 26q5-18 22.5-39t53.5-21q32 0 48 17.5t16 38.5q0 20-12 37.5T506-526q-44 39-54 59t-10 73Zm38 314q-83 0-156-31.5T197-197q-54-54-85.5-127T80-480q0-83 31.5-156T197-763q54-54 127-85.5T480-880q83 0 156 31.5T763-763q54 54 85.5 127T880-480q0 83-31.5 156T763-197q-54 54-127 85.5T480-80Zm0-80q134 0 227-93t93-227q0-134-93-227t-227-93q-134 0-227 93t-93 227q0 134 93 227t227 93Zm0-320Z");
                    break;
            }
        }

        private void SetupButtons(MessageBoxButtons buttons)
        {
            switch (buttons)
            {
                case MessageBoxButtons.Ok:
                    BtnOk.Content = "Aceptar";
                    BtnCancel.Visibility = Visibility.Collapsed;
                    break;

                case MessageBoxButtons.YesNo:
                    BtnOk.Content = "Sí";
                    BtnCancel.Content = "No";
                    BtnCancel.Visibility = Visibility.Visible;
                    break;
            }
        }
    }
}
