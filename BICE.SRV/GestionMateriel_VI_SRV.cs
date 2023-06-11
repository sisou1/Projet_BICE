using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BICE.DAL;
using BICE.DTO;

namespace BICE.SRV
{
    public class GestionMateriel_VI_SRV : IGestionMateriel_VI_SRV
    {
        protected IDepot_DAL<Materiel_VI_DAL> depot_materiel_VI;
        public GestionMateriel_VI_SRV(IDepot_DAL<Materiel_VI_DAL> depot)
        {
            this.depot_materiel_VI = depot;
        }
        public GestionMateriel_VI_SRV() : this(new Materiel_VI_Depot_DAL()) { }
        public IEnumerable<Materiel_VI_DTO> GetAllById(int id)
        {
            return depot_materiel_VI.GetAllById(id).Select(materiel_VI_DAL => new Materiel_VI_DTO()
            {
                Id_Materiel = materiel_VI_DAL.Id_Materiel,
                Id_VehiculeIntervention = materiel_VI_DAL.Id_VehiculeIntervention,
                Etat = materiel_VI_DAL.Etat
            });
        }

        public Materiel_VI_DTO Insert(Materiel_VI_DTO materiel_VI)
        {
            var materiel_VI_DAL = new Materiel_VI_DAL(
                materiel_VI.Id_Materiel,
                materiel_VI.Id_VehiculeIntervention,
                materiel_VI.Etat
                );
            depot_materiel_VI.Insert(materiel_VI_DAL);

            return materiel_VI;
        }
    }
}
