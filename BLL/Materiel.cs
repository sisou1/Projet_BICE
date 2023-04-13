using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BICE.BLL
{
    public class Materiel
    {

        #region constructeur

        public int ID { get; private set; }
        public int Utilisation { get; private set; }
        public int? UtilisationMax { get; private set; }
        public bool EstActif { get; private set; }
        public bool EstStocke { get; private set; }
        public string? Stock { get; private set; }

        public Materiel(int id, int utilisation, int? utilisationMax, bool estActif, bool estStocke, string? stock)
        {
            ID = id;
            Utilisation = utilisation;
            UtilisationMax = utilisationMax;
            EstActif = estActif;
            EstStocke = estStocke;
            Stock = stock;
        }
        #endregion

        #region Methodes

        public void AjoutUtilisation()
        {
            Utilisation =+ 1;
        }
        public bool Test_Max()
        {
            if (Utilisation < UtilisationMax) { return true; } else { return false; }
        }
        
        #endregion
    }
}