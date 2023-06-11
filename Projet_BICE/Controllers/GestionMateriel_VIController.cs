using BICE.DTO;
using BICE.SRV;
using Microsoft.AspNetCore.Mvc;

namespace Projet_BICE.API.Controllers
{
    [ApiController]
    public class GestionMateriel_VIController
    {
        private readonly GestionMateriel_VI_SRV _gestionMateriel_VI_SRV;

        public GestionMateriel_VIController(GestionMateriel_VI_SRV gestionMateriel_VI_SRV)
        {
            _gestionMateriel_VI_SRV = gestionMateriel_VI_SRV;
        }
        [HttpPost]
        [Route("/Materiel_VIAjouter")]
        public Materiel_VI_DTO Insert(Materiel_VI_DTO materiel_VI)
        {
            return _gestionMateriel_VI_SRV.Insert(materiel_VI);
        }
        [HttpPost]
        [Route("/Materiel_VIGettAllById")]
        public List<Materiel_VI_DTO> GetAllById(int id)
        {
            return _gestionMateriel_VI_SRV.GetAllById(id).ToList();
        }
    }
}
