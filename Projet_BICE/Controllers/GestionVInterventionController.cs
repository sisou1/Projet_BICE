using BICE.DTO;
using BICE.SRV;
using Microsoft.AspNetCore.Mvc;

namespace Projet_BICE.API.Controllers
{
    [ApiController]
    public class GestionVInterventionController
    {
        private readonly GestionVIntervention_SRV _gestionVIntervention_SRV;

        public GestionVInterventionController(GestionVIntervention_SRV gestionVIntervention_SRV)
        {
            _gestionVIntervention_SRV = gestionVIntervention_SRV;
        }
        [HttpPost]
        [Route("/VInterventionAjouter")]
        public VIntervention_DTO Insert(VIntervention_DTO VIntervention)
        {
            return _gestionVIntervention_SRV.Insert(VIntervention);
        }
        [HttpPost]
        [Route("/VInterventionGetAllById")]
        public List<VIntervention_DTO> GetAllById(int id)
        {
            return _gestionVIntervention_SRV.GetAllById(id).ToList();
        }
    }
}
