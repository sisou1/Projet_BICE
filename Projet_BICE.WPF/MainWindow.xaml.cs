using BICE.DTO;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Documents;
using BICE.Client;

namespace Projet_BICE.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void UploadButton_AddMateriel_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
            bool? result = openFileDialog.ShowDialog();
            if (result == true)
            {
                using (StreamReader reader = new StreamReader(openFileDialog.FileName))
                {
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var client = new Client("https://localhost:7238/", new System.Net.Http.HttpClient());
                        var data = line.Split(';');
                        var dto = new BICE.Client.Materiel_DTO()
                           {
                                Id = int.Parse(data[0]),
                                Denomination = data[1],
                                Categorie = data[2],
                                Utilisation = int.Parse(data[3]),
                                UtilisationMax = String.IsNullOrEmpty(data[4]) ? null : int.Parse(data[4]),
                                DateControle = data[5] == "" ? null : DateTime.Parse(data[5]),
                                DateExpiration = data[6] == "" ? null : DateTime.Parse(data[6]),
                                Stock = "Caserne",
                                EstStocke = true,
                                EstActive = true
                            };   
                        Trace.WriteLine(dto);
                        if (client.MaterielGetbyID(dto.Id) is null)
                        {
                            client.MaterielAjouter(dto);
                        }
                        else
                        {
                            client.MaterielUpdate();
                        }
                    }
                }

            }

        }

        private void UploadButton_DelMAteriel_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
            bool? result = openFileDialog.ShowDialog();
            if (result == true)
            {
                using (StreamReader reader = new StreamReader(openFileDialog.FileName))
                {
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var client = new Client("https://localhost:7238/", new System.Net.Http.HttpClient());
                        var data = line.Split(';');
                        var dto = client.MaterielGetById(data[0]);
                        Trace.WriteLine(dto);
                        if (client.MaterielGetbyID(dto.Id) is null)
                        {
                            throw new Exception("Vous avez essayé de supprimer un matériel inexistant");
                        }
                    }
                }

            }

        }

    }
}
