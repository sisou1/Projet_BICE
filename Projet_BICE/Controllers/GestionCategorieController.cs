using BICE.DTO;
using BICE.SRV;
using Microsoft.AspNetCore.Mvc;

namespace Projet_BICE.API.Controllers
{
    [ApiController]
    public class GestionCategorieControllers
    {
        private readonly GestionCategorie_SRV _gestionCategorie_SRV;

        public GestionCategorieControllers(GestionCategorie_SRV gestionCategorie_SRV)
        {
            _gestionCategorie_SRV = gestionCategorie_SRV;
        }

        [HttpPost]
        [Route("/CategorieAjouter")]
        public Categorie_DTO Insert(Categorie_DTO categorie)
        {
            return _gestionCategorie_SRV.Insert(categorie);
        }
        [HttpPost]
        [Route("/CategorieModifier")]
        public Categorie_DTO Update(Categorie_DTO categorie)
        {
            return _gestionCategorie_SRV.Update(categorie);
        }
        [HttpPost]
        [Route("/CategorieGetAll")]
        public List<Categorie_DTO> GetAll()
        {
            return _gestionCategorie_SRV.GetAll().ToList();
        }
        [HttpPost]
        [Route("/CategorieDelete")]
        public void Delete(Categorie_DTO categorie)
        {
            _gestionCategorie_SRV.Delete(categorie);
        }
    }
}
