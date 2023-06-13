using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BICE.DAL
{
    public class Categorie_DAL
    {
        public int Id { get; set; }
        public string Nom { get; set; }

        public Categorie_DAL(int id, string nom)
        {
            Id = id;
            Nom = nom;
        }
    }
}
