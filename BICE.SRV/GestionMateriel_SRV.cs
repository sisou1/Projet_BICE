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
                materiel.Denomination,
                materiel.EstActive,
                materiel.Utilisation,
                materiel.Categorie
                );
           depot_materiel.Delete(materiel_DAL);
        }
    }
}
//La couche SRV recoit une collection de DTO et la découpe afin de l'envoyer à la couche DAL