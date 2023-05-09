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
        protected IDepot_DAL<Materiel_DAL> depot_intervention;
        public GestionIntervention_SRV(IDepot_DAL<Materiel_DAL> depot)
        {
            this.depot_intervention = depot;
        }
        public GestionIntervention_SRV() : this(new Intervention_Depot_DAL()) { }
        public Materiel_DTO Insert(Materiel_DTO materiel)
        {
            var materiel_DAL = new Materiel_DAL(
                materiel.Id,
                materiel.UtilisationMax,
                materiel.DateExpiration,
                materiel.DateControle,
                materiel.EstStocke,
                materiel.Stock,
                materiel.Denomination,
                materiel.EstActive,
                materiel.Utilisation,
                materiel.Categorie
                );
            depot_materiel.Insert(materiel_DAL);

            return materiel;
        }
    }
}
