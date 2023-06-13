using BICE.DAL;
using BICE.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BICE.SRV
{
    public class GestionCategorie_SRV : IGestionCategorie_SRV
    {
        protected IDepot_DAL<Categorie_DAL> depot_categorie;
        public GestionCategorie_SRV(IDepot_DAL<Categorie_DAL> depot)
        {
            this.depot_categorie = depot;
        }
        public GestionCategorie_SRV() : this(new Categorie_Depot_DAL()) { }
        public void Delete(Categorie_DTO categorie)
        {
            var categorie_DAL = new Categorie_DAL(
                categorie.Id,
                categorie.Nom
                );
            depot_categorie.Delete(categorie_DAL);
        }

        public IEnumerable<Categorie_DTO> GetAll()
        {
            
            return depot_categorie.GetAll().Select(Categorie_DAL => new Categorie_DTO()
            {
                Id = Categorie_DAL.Id,
                Nom = Categorie_DAL.Nom

            });
        }

        public Categorie_DTO Insert(Categorie_DTO categorie)
        {
            var categorie_DAL = new Categorie_DAL(
                categorie.Id,
                categorie.Nom
                );
            depot_categorie.Insert(categorie_DAL);

            return categorie;
        }

        public Categorie_DTO Update(Categorie_DTO categorie)
        {
            var categorie_DAL = new Categorie_DAL(
                categorie.Id,
                categorie.Nom
                );
            depot_categorie.Update(categorie_DAL);

            return categorie;
        }
    }
}
