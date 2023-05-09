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
        public Materiel_DTO Insert(Materiel_DTO materiel)
        {
            return _gestionMateriel_SRV.Insert(materiel);

        }
    }
}
