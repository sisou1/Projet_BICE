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
        public string Denomination { get; set; }
        public string Stock { get; set; }
        public int Utilisation { get; set; }
        public int? UtilisationMax { get; set; }
        public DateTime? DateControle { get; set; }
        public DateTime? DateExpiration { get; set; }
        public bool EstStocke { get; set; }
        public bool EstActive { get; set; }

        public Materiel_DAL(int id, string denomination, string stock, int utilisation, int? utilisationMax, DateTime? dateControle, DateTime? dateExpiration, bool estStocke, bool estActive)
        {
            Id = id;
            Denomination = denomination;
            Stock = stock;
            Utilisation = utilisation;
            UtilisationMax = utilisationMax;
            DateControle = dateControle;
            DateExpiration = dateExpiration;
            EstStocke = estStocke;
            EstActive = estActive;
        }
    }
}
