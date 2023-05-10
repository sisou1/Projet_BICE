using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BICE.DAL
{
    public class Materiel_DAL
    {
        public int Id { get; set; }
        public int? UtilisationMax { get; set; }
        public DateTime? DateExpiration { get; set; }
        public DateTime? DateControle { get; set; }
        public bool EstStocke { get; set; }
        public string Stock { get; set; }
        public int? Id_vehicule { get; set; }
        public string Denomination { get; set; }
        public bool EstActive { get; set; }
        public int Utilisation { get; set; }
        public string Categorie { get; set; }

        public Materiel_DAL(int id, int? utilisationMax, DateTime? dateExpiration, DateTime? dateControle, bool estStocke, string stock, int? id_vehicule, string denomination, bool estActive, int utilisation, string categorie) 
        { 
            Id = id;
            Utilisation = utilisation;
            DateExpiration = dateExpiration;
            DateControle = dateControle;
            EstStocke = estStocke;
            Stock = stock;
            Id_vehicule = id_vehicule;
            Denomination = denomination;
            EstActive = estActive;
            UtilisationMax = utilisationMax;
            Categorie = categorie;
                
        }

        public Materiel_DAL(int? utilisationMax, DateTime? dateExpiration, DateTime? dateControle, bool estStocke, string stock, int? id_vehicule, string denomination, bool estActive, int utilisation, string categorie)
        {
            UtilisationMax = utilisationMax;
            DateExpiration = dateExpiration;
            DateControle = dateControle;
            EstStocke = estStocke;
            Stock = stock;
            Id_vehicule = id_vehicule;
            Denomination = denomination;
            EstActive = estActive;
            Utilisation = utilisation;
            Categorie = categorie;
        }
    }
}
