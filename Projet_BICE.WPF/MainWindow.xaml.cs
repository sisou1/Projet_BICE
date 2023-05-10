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
using Microsoft.VisualBasic;
using System.Collections.ObjectModel;

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
                        var data = line.Split(';');
                        var dto = client.MaterielGetById(Int32.Parse(data[0]));
                        if (dto == null)
                        {
                            throw new Exception("Vous avez essayé de supprimer un matériel inexistant");
                        }
                        else
                        {
                            dto.EstActive = false;
                            dto.EstStocke = false;
                            client.MaterielModifier(dto);
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
                EstActive = true,
            };

            if (client.VehiculeGetById(dto.Id) == null)
            {
                client.VehiculeAjouter(dto);
            }
            else
            {
                dto.EstActive = false;
                client.VehiculeModifier(dto);
            }
        }

        private void UploadButton_DelVehicule_Click(Object sender, RoutedEventArgs e)
        {
            TextBox idTextBox = FindName("supprId") as TextBox;

            var id = idTextBox.Text;
            var dto = client.VehiculeGetById(int.Parse(id));
            dto.EstActive = false;
            if (dto == null)
            {
                throw new Exception("Vous avez essayé de supprimer un véhicule inexistant");
            }
            else
            {
                client.VehiculeModifier(dto);
            }
        }

        private void UploadButton_AddStockV_Click(Object sender, RoutedEventArgs e)
        {
            TextBox idVehicule = FindName("stockId") as TextBox;
            var id = int.Parse(idVehicule.Text);
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
                        var dto = client.MaterielGetById(Int32.Parse(data[0]));
                        if (dto == null)
                        {
                            throw new Exception("Vous avez essayé de rajouter un matériel inexistant dans un véhicule");
                        }
                        else
                        {
                            dto.Stock = "Caserne";
                            dto.vehiculeId = id;
                            client.MaterielModifier(dto);
                        }
                    }
                }

            }
        }

        List<BICE.Client.Materiel_DTO> listeDTONonUtilise = new List<BICE.Client.Materiel_DTO> {  }; 
        List<BICE.Client.Materiel_DTO> listeDTOUtilise = new List<BICE.Client.Materiel_DTO> {  }; 

        private void UploadButton_RetourInterventionMNU(Object sender, RoutedEventArgs e)
        {
            TextBox idVehicule = FindName("retourId") as TextBox;
            var id = int.Parse(idVehicule.Text);

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
                        var dto = client.MaterielGetById(Int32.Parse(data[0]));
                        listeDTONonUtilise.Add(dto);
                        
                    }
                }

            }
        }

        private void UploadButton_RetourInterventionMU(Object sender, RoutedEventArgs e)
        {
            TextBox idVehicule = FindName("retourId") as TextBox;
            var id = int.Parse(idVehicule.Text);

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
                        var dto = client.MaterielGetById(Int32.Parse(data[0]));
                        //ajouter une utilisation - estStocké = 0 si utilisation = utilisation max 
                        listeDTOUtilise.Add(dto);

                    }
                }

            }

        }
        private void UploadButton_RetourIntervention(Object sender, RoutedEventArgs e)
        {
            TextBox idVehicule = FindName("retourId") as TextBox;
            var id = int.Parse(idVehicule.Text);
            List<BICE.Client.Materiel_DTO> listeMateriel = new List<BICE.Client.Materiel_DTO> { };
            listeMateriel = client.MaterielGetAll;
            foreach ( var item in listeMateriel)
            {
                if (item.vehiculeId == id)
                {
                    listeMateriel.Add(item);
                }
            }
            var nbRetour = listeMateriel.Count();
            var nbParti = listeDTONonUtilise.Count() + listeDTOUtilise.Count();
            if (nbRetour == nbParti)
            {
                //retourner quelque chose de vide
            }
            else
            {
                List<BICE.Client.Materiel_DTO> fusion = listeDTOUtilise.Concat(listeDTONonUtilise).ToList();
                IEnumerable<BICE.Client.Materiel_DTO> différences = listeMateriel.Except(fusion);
                foreach(var item in différences)
                {
                    item.Stock = "Perdu";
                    item.EstStocke = false;
                }
            }

        }

        private void ExportListeMateriel(object sender, RoutedEventArgs e)
        {
            TextBox directory = FindName("directory") as TextBox;
            var streamWriter = new StreamWriter(directory.Text + "/materielStocker.csv");

            var listMateriel = (List<BICE.Client.Materiel_DTO>)client.MaterielGetAll();

            if (listMateriel == null) return;

            string newLine = Environment.NewLine;

            //this acts as datarow
            foreach (var item in listMateriel)
            {

                if (item.EstStocke)
                {
                    //this acts as datacolumn
                    var row = string.Join(";", new List<string>()
                    {
                        item.Id.ToString(),
                        item.Utilisation.ToString(),
                        item.Denomination.ToString(),
                        item.UtilisationMax?.ToString()?? "",
                        item.DateControle?.ToString()?? "",
                        item.DateExpiration?.ToString()?? "",
                        item.EstActive.ToString(),
                        item.EstStocke.ToString(),
                        item.Categorie.ToString(),
                        item.Stock.ToString(),
                    });

                    streamWriter.Write(row + newLine);
                };
            };

            streamWriter.Close();
        }

        private void ExportListeMaterielJeter(object sender, RoutedEventArgs e)
        {
            TextBox directory = FindName("directory") as TextBox;
            var streamWriter = new StreamWriter(directory.Text + "/materielJeter.csv");

            var listMateriel = (List<BICE.Client.Materiel_DTO>)client.MaterielGetAll();

            if (listMateriel == null) return;

            string newLine = Environment.NewLine;

            //this acts as datarow
            foreach (var item in listMateriel)
            {

                if (!item.EstStocke)
                {
                    //this acts as datacolumn
                    var row = string.Join(";", new List<string>()
                    {
                        item.Id.ToString(),
                        item.Utilisation.ToString(),
                        item.Denomination.ToString(),
                        item.UtilisationMax?.ToString()?? "",
                        item.DateControle?.ToString()?? "",
                        item.DateExpiration?.ToString()?? "",
                        item.EstActive.ToString(),
                        item.EstStocke.ToString(),
                        item.Categorie.ToString(),
                        item.Stock.ToString(),
                    });

                    streamWriter.Write(row + newLine);
                };
            };

            streamWriter.Close();
        }

        private void ExportListeMaterielControler(object sender, RoutedEventArgs e)
        {
            TextBox directory = FindName("directory") as TextBox;
            var streamWriter = new StreamWriter(directory.Text + "/materielControler.csv");

            var listMateriel = (List<BICE.Client.Materiel_DTO>)client.MaterielGetAll();

            if (listMateriel == null) return;

            string newLine = Environment.NewLine;

            //this acts as datarow
            foreach (var item in listMateriel)
            {

                if (item.DateControle == DateAndTime.Now)
                {
                    //this acts as datacolumn
                    var row = string.Join(";", new List<string>()
                    {
                        item.Id.ToString(),
                        item.Utilisation.ToString(),
                        item.Denomination.ToString(),
                        item.UtilisationMax?.ToString()?? "",
                        item.DateControle?.ToString()?? "",
                        item.DateExpiration?.ToString()?? "",
                        item.EstActive.ToString(),
                        item.EstStocke.ToString(),
                        item.Categorie.ToString(),
                        item.Stock.ToString(),
                    });

                    streamWriter.Write(row + newLine);
                };
            };

            streamWriter.Close();
        }


    }
}
