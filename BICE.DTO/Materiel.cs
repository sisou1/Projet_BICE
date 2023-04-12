using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BICE.DTO
{
    public class Materiel
    {
        public int Id { get; set; }
        public string Denomination { get; set; }
        public string Stock { get; set; }
        public int UtilisationMax { get; set; }
        public DateTime DateControle { get; set; }
        public DateTime DateExpiration { get; set; }
        public bool estStocke { get; set; }
    }
}
