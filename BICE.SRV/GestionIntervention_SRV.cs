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
                intervention.Description,
                intervention.Id_categorie
                );
            depot_intervention.Insert(intervention_dal);

            return intervention;
        }
        public IEnumerable<Intervention_DTO> GetAll()
        {
            //retourne une liste de intervention DTO
            return (IEnumerable<Intervention_DTO>)depot_intervention.GetAll().Select(intervention_DAL => new Intervention_DTO()
            {
                Id = intervention_DAL.Id,
                Date = intervention_DAL.Date,
                Denomination = intervention_DAL.Denomination,
                Description = intervention_DAL.Description,
                Id_categorie = intervention_DAL.Id_categorie,
                Lib_categorie = intervention_DAL.Lib_categorie,
            });
        }
        public Intervention_DTO? GetById(int id)
        {
            var intervention_DAL = depot_intervention.GetById(id);
            if(depot_intervention.GetById(id)== null) { return null; }

            return new Intervention_DTO()
            {
                Id = intervention_DAL.Id,
                Date = intervention_DAL.Date,
                Denomination = intervention_DAL.Denomination,
                Description = intervention_DAL.Description,
                Id_categorie = intervention_DAL.Id_categorie,
            };
        }
    }
}
