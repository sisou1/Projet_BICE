using BICE.DTO;
using BICE.SRV;
using Microsoft.AspNetCore.Mvc;

namespace Projet_BICE.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GestionMaterielController
    {
        private readonly GestionMateriel_SRV _gestionMateriel_SRV;

        public GestionMaterielController(GestionMateriel_SRV gestionMateriel_SRV)
        {
            _gestionMateriel_SRV = gestionMateriel_SRV;
        }

        [HttpPost]
        [Route("/MaterielAjouter")]
        public Materiel_DTO Insert(Materiel_DTO materiel)
        {
            return _gestionMateriel_SRV.Insert(materiel);
        }
        [HttpPost]
        [Route("/MaterielModifier")]
        public Materiel_DTO Update(Materiel_DTO materiel)
        {
            return _gestionMateriel_SRV.Update(materiel);
        }
        [HttpPost]
        [Route("/MaterielGetById")]
        public Materiel_DTO GetById(int id)
        {
            return _gestionMateriel_SRV.GetById(id);
        }
        public List<Materiel_DTO> GetAll()
        {
            return _gestionMateriel_SRV.GetAll();
        }
        public void Delete(Materiel_DTO materiel)
        {
            _gestionMateriel_SRV.Delete(materiel);
        }
    }
}
