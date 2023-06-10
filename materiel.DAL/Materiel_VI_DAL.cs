using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BICE.DAL
{
    public class Materiel_VI_DAL
    {
        public int Id_Materiel { get; set; }
        public int Id_VehiculeIntervention { get; set; }
        public string Etat { get; set; }
        public Materiel_VI_DAL(int id_Materiel, int id_VehiculeIntervention, string etat)
        {
            Id_Materiel = id_Materiel;
            Id_VehiculeIntervention = id_VehiculeIntervention;
            Etat = etat;
        }
    }
}
