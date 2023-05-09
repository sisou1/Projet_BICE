using BICE.DAL;
using BICE.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BICE.SRV
{
    public class GestionIntervention_SRV : IGestionIntervention_SRV
    {
        protected IDepot_DAL<Intervention_DAL> depot_intervention;
        public GestionIntervention_SRV(IDepot_DAL<Intervention_DAL> depot)
        {
            this.depot_intervention = depot;
        }
        public GestionIntervention_SRV() : this(new Intervention_Depot_DAL()) { }
        public Intervention_DTO Insert(Intervention_DTO intervention)
        {
            var intervention_dal = new Intervention_DAL(
                intervention.Id,
                intervention.Date,
                intervention.Denomination,
                intervention.Description
                );
            depot_intervention.Insert(intervention_dal);

            return intervention;
        }
    }
}
