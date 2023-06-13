using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BICE.DAL
{
    public class Intervention_DAL
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Denomination { get; set; }

        public string? Description { get; set; }
        public int? Id_categorie { get; set; }
        public string? Lib_categorie { get; set; }

        public Intervention_DAL(int id, DateTime date, string denomination, string description, int? id_categorie, string? lib_categorie)
        {
            Id = id;
            Date = date;
            Denomination = denomination;
            Description = description;
            Id_categorie = id_categorie;
            Lib_categorie = lib_categorie;
        }
    }
}
