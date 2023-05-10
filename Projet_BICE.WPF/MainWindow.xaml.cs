using BICE.DTO;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Documents;
using BICE.Client;
using System.Windows.Controls;

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

        Client client = new Client("https://localhost:7238/", new System.Net.Http.HttpClient());

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
                        var data = line.Split(';');
                        Trace.WriteLine(client.MaterielGetById(384056));
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

                        if (client.MaterielGetById(dto.Id) == null)
                        {
                            Trace.WriteLine(client.MaterielGetById(dto.Id));
                            client.MaterielAjouter(dto);
                        }
                        else
                        {
                            client.MaterielModifier(dto);
                        }
                    }
                }

            }

        }

        private void UploadButton_DelMateriel_Click(object sender, RoutedEventArgs e)
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
                        var dto = client.MaterielGetById(Int32.Parse(data[0]));
                        Trace.WriteLine(dto);
                        if (client.MaterielGetById(dto.Id) == null)
                        {
                            throw new Exception("Vous avez essayé de supprimer un matériel inexistant");
                        }
                        else
                        {
                            client.MaterielDelete(dto);
                        }
                    }
                }

            }

        }

        private void UploadButton_AddVehicule_Click(object sender, RoutedEventArgs e)
        {
            TextBox immatriculation = FindName("ajoutImmatriculation") as TextBox;
            TextBox denomination = FindName("ajoutDénomination") as TextBox;
            TextBox numero = FindName("ajoutNuméro") as TextBox;

            var dto = new BICE.Client.Vehicule_DTO()
            {
                Immatriculation = immatriculation.Text,
                Denomination = denomination.Text,
                Numero = numero.Text,
            };

            if (client.VehiculeGetById(dto.Id) == null)
            {
                client.VehiculeAjouter(dto);
            }
            else
            {
                client.VehiculeModifier(dto);
            }
        }

        private void UploadButton_DelVehicule_Click(Object sender, RoutedEventArgs e)
        {
            TextBox idTextBox = FindName("supprId") as TextBox;

            var id = idTextBox.Text;
            var dto = client.VehiculeGetById(int.Parse(id));
            if (dto == null)
            {
                throw new Exception("Vous avez essayé de supprimer un véhicule inexistant");
            }
            else
            {
                client.VehiculeDelete(dto);
            }
        }
    }
}
