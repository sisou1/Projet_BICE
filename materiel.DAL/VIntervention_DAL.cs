using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BICE.DAL
{
    public class VIntervention_DAL
    {
        public int Id { get; set; }
        public int Id_Vehicule { get; set; }
        public int Id_Intervention { get; set; }
        public VIntervention_DAL(int id, int id_Vehicule, int id_Intervention)
        {
            Id = id;
            Id_Vehicule = id_Vehicule;
            Id_Intervention = id_Intervention;
        }
    }
}
