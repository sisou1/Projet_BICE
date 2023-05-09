using BICE.DTO;
using BICE.SRV;
using Microsoft.AspNetCore.Mvc;

namespace Projet_BICE.API.Controllers
{
    [ApiController]
    public class GestionInterventionsControllers
    {
        private readonly GestionIntervention_SRV _gestionIntervention_SRV;

        public GestionInterventionsControllers(GestionIntervention_SRV gestionIntervention_SRV)
        {
            _gestionIntervention_SRV = gestionIntervention_SRV;
        }
        [HttpPost]
        [Route("/InterventionAjouter")]
        public Intervention_DTO Insert(Intervention_DTO intervention)
        {
            return _gestionIntervention_SRV.Insert(intervention);
        }
        [HttpPost]
        [Route("/InterventionGetById")]
        public Intervention_DTO GetById(int id)
        {
            return _gestionIntervention_SRV.GetById(id);
        }
        [HttpPost]
        [Route("/InterventionGetAll")]
        public List<Intervention_DTO> GetAll()
        {
            return (List<Intervention_DTO>)_gestionIntervention_SRV.GetAll();
        }
    }
}
