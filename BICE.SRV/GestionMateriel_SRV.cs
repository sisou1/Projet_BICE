using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BICE.BLL;
using BICE.DAL;
using BICE.DTO;

namespace BICE.SRV
{
    public class GestionMateriel_SRV : IGestionMateriel_SRV
    {
        protected IDepot_DAL<Materiel_DAL> depot_materiel;
        public GestionMateriel_SRV(IDepot_DAL<Materiel_DAL> depot)
        {
            this.depot_materiel = depot;
        }
        public GestionMateriel_SRV() : this(new Materiel_Depot_DAL()) { }

        public Materiel_DTO Insert(Materiel_DTO materiel)
        {
            var materiel_DAL = new Materiel_DAL(
                materiel.Id,
                materiel.UtilisationMax,
                materiel.DateExpiration,
                materiel.DateControle,
                materiel.EstStocke,
                materiel.Stock,
                materiel.Id_vehicule,
                materiel.Denomination,
                materiel.EstActive, 
                materiel.Utilisation,
                materiel.Categorie
                );
            depot_materiel.Insert(materiel_DAL);

            return materiel;
        }

        public Materiel_DTO? GetById(int id)
        {
            var Materiel_DAL = depot_materiel.GetById(id);
            if (Materiel_DAL == null) { return null; }

            return new Materiel_DTO()
            {
                Id = Materiel_DAL.Id,
                UtilisationMax = Materiel_DAL.UtilisationMax,
                DateExpiration = Materiel_DAL.DateExpiration,
                DateControle = Materiel_DAL.DateControle,
                EstStocke = Materiel_DAL.EstStocke,
                Stock = Materiel_DAL.Stock,
                Id_vehicule = Materiel_DAL.Id_vehicule,
                Denomination = Materiel_DAL.Denomination,
                EstActive = Materiel_DAL.EstActive,
                Utilisation = Materiel_DAL.Utilisation,
                Categorie = Materiel_DAL.Categorie
            };
        }

        public Materiel_DTO Update(Materiel_DTO materiel)
        {
            var materiel_DAL = new Materiel_DAL(
            materiel.Id,
                materiel.UtilisationMax,
                materiel.DateExpiration,
                materiel.DateControle,
                materiel.EstStocke,
                materiel.Stock,
                materiel.Id_vehicule,
                materiel.Denomination,
                materiel.EstActive,
                materiel.Utilisation,
                materiel.Categorie
                );
            depot_materiel.Update(materiel_DAL);

            return materiel;
        }

        public IEnumerable<Materiel_DTO> GetAll()
        {
            //retourne une liste de materiel DTO
            return depot_materiel.GetAll().Select(materiel_DAL => new Materiel_DTO()
            {
                Id = materiel_DAL.Id,
                UtilisationMax = materiel_DAL.UtilisationMax,
                DateExpiration = materiel_DAL.DateExpiration,
                DateControle = materiel_DAL.DateControle,
                EstStocke = materiel_DAL.EstStocke,
                Stock = materiel_DAL.Stock,
                Id_vehicule = materiel_DAL.Id_vehicule,
                Denomination = materiel_DAL.Denomination,
                EstActive = materiel_DAL.EstActive,
                Utilisation = materiel_DAL.Utilisation,
                Categorie = materiel_DAL.Categorie,
            });
        }
        public void Delete(Materiel_DTO materiel)
        {
            var materiel_DAL = new Materiel_DAL(
            materiel.Id,
                materiel.UtilisationMax,
                materiel.DateExpiration,
                materiel.DateControle,
                materiel.EstStocke,
                materiel.Stock,
                materiel.Id_vehicule,
                materiel.Denomination,
                materiel.EstActive,
                materiel.Utilisation,
                materiel.Categorie
                );
           depot_materiel.Delete(materiel_DAL);
        }
        public void UtilisationRetourIntervention(Materiel_DTO m)
        {
            if (m == null)
                throw new Exception("pas de materiel avec cette id");
            var materiel_BLL = new Materiel_BLL(m.Id, m.UtilisationMax, m.DateExpiration, m.DateControle, m.EstStocke, m.Stock, m.Id_vehicule, m.Denomination, m.EstActive, m.Utilisation, m.Categorie);

            materiel_BLL.AjoutUtilisation();
            materiel_BLL.Test_Max();

            var materiel_dal = new Materiel_DAL(materiel_BLL.Id, materiel_BLL.UtilisationMax, materiel_BLL.DateExpiration, materiel_BLL.DateControle, materiel_BLL.EstStocke, materiel_BLL.Stock, materiel_BLL.Id_vehicule, materiel_BLL.Denomination, materiel_BLL.EstActive, materiel_BLL.Utilisation, materiel_BLL.Categorie);
            depot_materiel.Update(materiel_dal);

        }
        public void ControleMateriel(Materiel_DTO m)
        {
            if (m == null)
                throw new Exception("pas de materiel avec cette id");
            var materiel_BLL = new Materiel_BLL(m.Id, m.UtilisationMax, m.DateExpiration, m.DateControle, m.EstStocke, m.Stock, m.Id_vehicule, m.Denomination, m.EstActive, m.Utilisation, m.Categorie);

            materiel_BLL.Controle();

            var materiel_dal = new Materiel_DAL(materiel_BLL.Id, materiel_BLL.UtilisationMax, materiel_BLL.DateExpiration, materiel_BLL.DateControle, materiel_BLL.EstStocke, materiel_BLL.Stock, materiel_BLL.Id_vehicule, materiel_BLL.Denomination, materiel_BLL.EstActive, materiel_BLL.Utilisation, materiel_BLL.Categorie);
            depot_materiel.Update(materiel_dal);

        }
    }
}
//La couche SRV recoit une collection de DTO et la découpe afin de l'envoyer à la couche DAL