using FELCR.Helpers;
using FELCR.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using Microsoft.Win32;

namespace FELCR.Views.Pages
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
            string fullPath = path + ComplementaryPath;
            txtFilePath.Text = fullPath;

            if (File.Exists(fullPath))
            {
                try
                {
                    ConvertFileToObject(fullPath);
                    ReadLogs();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al leer el archivo de logs:\n" + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    lstLog.Clear();
                    rtbLog.Document = new FlowDocument();
                }
            }
            else
            {
                // No existe archivo de log: limpiar y mostrar mensaje informativo
                lstLog.Clear();
                FlowDocument doc = new FlowDocument();
                Paragraph p = new Paragraph();
                Run infoRun = new Run("No se encontraron logs en la ruta: " + fullPath);
                infoRun.Foreground = Brushes.Gray;
                p.Inlines.Add(infoRun);
                p.FontFamily = new FontFamily("Segoe UI");
                doc.Blocks.Add(p);
                rtbLog.Document = doc;
            }
        }

        private void ConvertFileToObject(string ComplementaryPath)
        {
            var response = HandleLogs.ReadLog(ComplementaryPath);
            if (string.IsNullOrWhiteSpace(response))
            {
                lstLog.Clear();
                return;
            }

            var splitedText = response.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
            lstLog.Clear();
            foreach (var item in splitedText)
            {
                try
                {
                    var itemLog = JsonSerializer.Deserialize<LogModel>(item);
                    if (itemLog != null)
                    {
                        lstLog.Add(itemLog);
                    }
                }
                catch
                {
                    // Ignorar líneas que no se puedan deserializar
                }
            }
        }

        private void ReadLogs()
        {
            FlowDocument mcFlowDoc = new FlowDocument();

            foreach (var log in lstLog)
            {
                if (log != null)
                {
                    Paragraph para = new Paragraph();

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
                }
            }

            rtbLog.Document = mcFlowDoc;
        }

        private void btnSearchFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text files (*.log)|*.log|All files (*.*)|*.*";
            openFileDialog.InitialDirectory = @"C:\";
            if (openFileDialog.ShowDialog() == true)
            {
                txtFilePath.Text = openFileDialog.FileName;
                try
                {
                    if (File.Exists(txtFilePath.Text))
                    {
                        ConvertFileToObject(txtFilePath.Text);
                        ReadLogs();
                    }
                    else
                    {
                        MessageBox.Show("El archivo seleccionado no existe.", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
                        lstLog.Clear();
                        rtbLog.Document = new FlowDocument();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar el archivo:\n" + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
