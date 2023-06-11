using BICE.DAL;
using BICE.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BICE.SRV
{
    public class GestionVIntervention_SRV : IGestionVIntervention_SRV
    {
        protected IDepot_DAL<VIntervention_DAL> depot_vIntervention;
        public GestionVIntervention_SRV(IDepot_DAL<VIntervention_DAL> depot)
        {
            this.depot_vIntervention = depot;
        }
        public GestionVIntervention_SRV() : this(new VIntervention_Depot_DAL()) { }
        public IEnumerable<VIntervention_DTO> GetAllById(int id)
        {
            return depot_vIntervention.GetAllById(id).Select(vIntervention_DAL => new VIntervention_DTO()
            {
                Id = vIntervention_DAL.Id,
                Id_Vehicule = vIntervention_DAL.Id_Vehicule,
                Id_Intervention = vIntervention_DAL.Id_Intervention
            });
        }

        public VIntervention_DTO Insert(VIntervention_DTO vIntervention)
        {
            var vIntervention_DAL = new VIntervention_DAL(
                vIntervention.Id,
                vIntervention.Id_Vehicule,
                vIntervention.Id_Intervention
                );
            depot_vIntervention.Insert(vIntervention_DAL);

            return vIntervention;
        }
    }
}
