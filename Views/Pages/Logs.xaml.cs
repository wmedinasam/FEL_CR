using FELRD.Helpers;
using FELRD.Models;
using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

namespace FELRD.Views.Pages
{
    /// <summary>
    /// Lógica de interacción para Logs.xaml
    /// </summary>
    public partial class Logs : Page
    {
        List<LogModel> lstLog = new List<LogModel>();
        public Logs()
        {
            InitializeComponent();
            string timestamp = HandleLogs.GetTimestamp(DateTime.Now);
            string path = HandleLogs.GetLogPath();
            string ComplementaryPath = @"\Logs\Log" + timestamp + ".log";
            txtFilePath.Text = path + ComplementaryPath;
            ConvertFileToObject(path + ComplementaryPath);
            ReadLogs();
        }
        private void ConvertFileToObject(string ComplementaryPath)
        {
            var response = HandleLogs.ReadLog(ComplementaryPath);
            var splitedText = response.Split('\n');
            lstLog.Clear();
            foreach (var item in splitedText)
            {
                var itemLog = JsonConvert.DeserializeObject<LogModel>(item);
                if (itemLog != null)
                {
                    lstLog.Add(itemLog);
                }
            }
        }
        private void ReadLogs()
        {
            FlowDocument mcFlowDoc = new FlowDocument();
            Paragraph para = new Paragraph();


            foreach (var log in lstLog)
            {
                if (log != null)
                {
                    Run runDate = new Run();
                    runDate.Text = "Fecha: " + log.Date;
                    runDate.Foreground = Brushes.White;

                    Run runType = new Run();
                    runType.Text = " Tipo: " + log.Type;
                    if (log.Type == "Base de datos")
                    {
                        runType.Foreground = Brushes.YellowGreen;
                    }
                    else if (log.Type == "Debug")
                    {
                        runType.Foreground = Brushes.Red;
                    }

                    Run runDescription = new Run();
                    if (!string.IsNullOrEmpty(log.Consulta))
                    {
                        runDescription.Text = " Mensaje: " + log.Description;
                    }
                    else
                    {
                        runDescription.Text = " Mensaje: " + log.Description + "\r";
                    }

                    runDescription.Foreground = Brushes.Yellow;
                    Run runConsulta = new Run();
                    runConsulta.Text = " Consulta: " + log.Consulta + "\r";
                    runConsulta.Foreground = Brushes.CadetBlue;

                    para.Inlines.Add(runDate);
                    para.Inlines.Add(runType);
                    para.Inlines.Add(runDescription);
                    if (!string.IsNullOrEmpty(log.Consulta))
                    {
                        para.Inlines.Add(runConsulta);
                    }

                    para.FontFamily = new FontFamily("Lucida Console");
                    para.FontWeight = FontWeights.Bold;
                    mcFlowDoc.Blocks.Add(para);
                    rtbLog.Document = mcFlowDoc;
                }
            }
        }

        private void btnSearchFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text files (*.log)|*.log|All files (*.*)|*.*";
            openFileDialog.InitialDirectory = @"C:\";
            if (openFileDialog.ShowDialog() == true)
            {
                txtFilePath.Text = openFileDialog.FileName;
                ConvertFileToObject(txtFilePath.Text);
                ReadLogs();
            }
        }
    }
}
