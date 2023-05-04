using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BICE.BLL
{
    internal class Vehicule
    {
        public int Id { get; set; }
        public string Immatriculation { get; set; }
        public string Denomination { get; set; }
        public string Numero { get; set; }
        public bool EstActive { get; set; }

        public Vehicule(int id, string immatriculation, string denomination, string numero, bool estActive)
        {
            Id = id;
            Immatriculation = immatriculation;
            Denomination = denomination;
            Numero = numero;
            EstActive = estActive;
        }
    }
}
