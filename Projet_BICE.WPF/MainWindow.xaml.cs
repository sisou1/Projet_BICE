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
                            EstActive = true,
                            Id_vehicule = null,
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
            client.VehiculeAjouter(dto);
        }

        private void UploadButton_UpdateVehicule_Click(object sender, RoutedEventArgs e)
        {
            TextBox id = FindName("modifId") as TextBox;
            TextBox immatriculation = FindName("modifImmatriculation") as TextBox;
            TextBox denomination = FindName("modifDénomination") as TextBox;
            TextBox numero = FindName("modifNuméro") as TextBox;
            var dto = new BICE.Client.Vehicule_DTO()
            {
                Id = int.Parse(id.Text),
                Immatriculation = immatriculation.Text,
                Denomination = denomination.Text,
                Numero = numero.Text,
                EstActive = true,
            };
            client.VehiculeModifier(dto);
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
                        var dto = client.MaterielGetById(int.Parse(data[0]));
                        if (dto == null)
                        {
                            throw new Exception("Vous avez essayé de rajouter un matériel inexistant dans un véhicule");
                        }
                        else
                        {
                            dto.Stock = "Véhicule";
                            dto.Id_vehicule = id;
                            client.MaterielModifier(dto);
                        }
                    }
                }

            }
        }
        

        

    
        private void UploadButton_RetourIntervention(Object sender, RoutedEventArgs e)
        {
            List<BICE.Client.Materiel_DTO> listeDTONonUtilise = new List<BICE.Client.Materiel_DTO> { };
            List<BICE.Client.Materiel_DTO> listeDTOUtilise = new List<BICE.Client.Materiel_DTO> { };
            TextBox idVehicule = FindName("retourId") as TextBox;
            Microsoft.Win32.OpenFileDialog pasUtilise = new Microsoft.Win32.OpenFileDialog();
            Microsoft.Win32.OpenFileDialog utilise = new Microsoft.Win32.OpenFileDialog();
            bool? result = pasUtilise.ShowDialog();
            if (result == true)
            {
                using (StreamReader reader = new StreamReader(pasUtilise.FileName))
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
            result = utilise.ShowDialog();
            if (result == true)
            {
                using (StreamReader reader = new StreamReader(utilise.FileName))
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
            //Gestion des matériels utilisés
            foreach(var dto in listeDTOUtilise)
            {
                client.MaterielAjoutUtilisation(dto);
            }
            //Gestion des matériels perdus
            var id = int.Parse(idVehicule.Text);
            var listeMateriel = client.MaterielGetAll();
            var listeDansLeVehicule = listeMateriel.Where(m=> m.Id_vehicule==id).ToList();
            var nbRetour = listeDansLeVehicule.Count();
            var nbParti = listeDTONonUtilise.Count() + listeDTOUtilise.Count();
            if (nbRetour == nbParti)
            {
                //retourner quelque chose de vide
            }
            else
            {
                List<BICE.Client.Materiel_DTO> fusion = listeDTOUtilise.Concat(listeDTONonUtilise).ToList();
                int cpt = 0;
                List<BICE.Client.Materiel_DTO> differences = new List<BICE.Client.Materiel_DTO>();
                foreach (var materiel in listeDansLeVehicule)
                {
                    cpt = 0;
                    foreach(var materielRetour in fusion)
                    {
                        if(materiel.Id == materielRetour.Id)
                        {
                            cpt++;
                        }

                    }
                    if (cpt == 0) 
                    {
                        differences.Add(materiel);
                    }
                }
                foreach(var item in differences)
                {
                    item.Stock = "Perdu";
                    item.EstStocke = false;
                    client.MaterielModifier(item);
                }
            }
            //Ajout de l'intervention
            TextBox denom = FindName("ajoutDénominationInter") as TextBox;
            TextBox description = FindName("ajoutDescription") as TextBox;
            var interventionDto = new BICE.Client.Intervention_DTO()
            {
                Date = DateTime.Now,
                Denomination = denom.Text,
                Description = description.Text, 
            };
            client.InterventionAjouter(interventionDto);

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
                        item.Id_vehicule.ToString() ?? "",
                    });

                    streamWriter.Write(row + newLine);
                };
            };

            streamWriter.Close();
        }

        private void ExportListeMaterielJeter(object sender, RoutedEventArgs e)
        {
            TextBox directory = FindName("directory2") as TextBox;
            var streamWriter = new StreamWriter(directory.Text + "/materielJeter.csv");

            var listMateriel = (List<BICE.Client.Materiel_DTO>)client.MaterielGetAll();

            if (listMateriel == null) return;

            string newLine = Environment.NewLine;

            //this acts as datarow
            foreach (var item in listMateriel)
            {

                if (!item.EstActive && item.EstStocke)
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
                        item.Id_vehicule.ToString() ?? "",
                    });

                    streamWriter.Write(row + newLine);
                };
            };

            streamWriter.Close();
        }

        private void ExportListeMaterielControler(object sender, RoutedEventArgs e)
        {
            TextBox directory = FindName("directory3") as TextBox;
            var streamWriter = new StreamWriter(directory.Text + "/materielControler.csv");

            var listMateriel = (List<BICE.Client.Materiel_DTO>)client.MaterielGetAll();

            if (listMateriel == null) return;

            string newLine = Environment.NewLine;

            //this acts as datarow
            foreach (var item in listMateriel)
            {
                var date = DateTime.Now;
                var dateonly = date.ToString("dd/mm/yyyy");
                var d = item.DateControle.ToString().Substring(0,10);
                if (d == dateonly && item.EstActive == true)
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
                        item.Id_vehicule.ToString()?? "",
                    });

                    streamWriter.Write(row + newLine);
                };
            };

            streamWriter.Close();
        }


    }
}