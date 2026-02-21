using FELCR.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FELCR.Services
{
    public static class MessageService
    {
        public static void ShowError(string title, string message)
        {
            customMessageBox.Show(title, message,
            customMessageBox.MessageBoxType.Error,
            customMessageBox.MessageBoxButtons.Ok);
        }

        public static void ShowInfo(string title, string message)
        {
            customMessageBox.Show(title, message,
                customMessageBox.MessageBoxType.Info,
                customMessageBox.MessageBoxButtons.Ok);
        }

        public static void ShowSuccess(string title, string message)
        {
            customMessageBox.Show(title, message,
                customMessageBox.MessageBoxType.Success,
                customMessageBox.MessageBoxButtons.Ok);
        }

        public static void ShowWarning(string title, string message)
        {
            customMessageBox.Show(
                title,
                message,
                customMessageBox.MessageBoxType.Warning,
                customMessageBox.MessageBoxButtons.Ok);
        }

        public static bool Confirm(string title, string message)
        {
            var result = customMessageBox.Show(title, message,
                customMessageBox.MessageBoxType.Confirm,
                customMessageBox.MessageBoxButtons.YesNo);

            return result == customMessageBox.CustomMessageBoxResult.Yes;
        }
    }
}
