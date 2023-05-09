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

        private void UploadButton_Add_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
            bool? result = openFileDialog.ShowDialog();
            var list = new List<Materiel_DTO>();

            if (result == true)
            {
                using (StreamReader reader = new StreamReader(openFileDialog.FileName))
                {
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var data = line.Split(';');
                        var dto = new Materiel_DTO()
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

                        
                        list.Add(dto);
                        var nouveau = new Client().;
                    }



                }

            }
        }

    }
}
