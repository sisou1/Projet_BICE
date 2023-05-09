using BICE.DTO;
using BICE.SRV;
using Microsoft.AspNetCore.Mvc;

namespace Projet_BICE.API.Controllers
{
    [ApiController]
    public class GestionVehiculeControllers
    {
        private readonly GestionVehicule_SRV _gestionVehicule_SRV;

        public GestionVehiculeControllers(GestionVehicule_SRV gestionVehicule_SRV)
        {
            _gestionVehicule_SRV = gestionVehicule_SRV;
        }

        [HttpPost]
        [Route("/VehiculeAjouter")]
        public Vehicule_DTO Insert(Vehicule_DTO vehicule)
        {
            return _gestionVehicule_SRV.Insert(vehicule);
        }
        [HttpPost]
        [Route("/VehiculeModifier")]
        public Vehicule_DTO Update(Vehicule_DTO vehicule)
        {
            return _gestionVehicule_SRV.Update(vehicule);
        }
        [HttpPost]
        [Route("/VehiculeGetById")]
        public Vehicule_DTO GetById(int id)
        {
            return _gestionVehicule_SRV.GetById(id);
        }
        [HttpPost]
        [Route("/VehiculeGetAll")]
        public List<Vehicule_DTO> GetAll()
        {
            return (List<Vehicule_DTO>)_gestionVehicule_SRV.GetAll();
        }
        [HttpPost]
        [Route("/VehiculeDelete")]
        public void Delete(Vehicule_DTO vehicule)
        {
            _gestionVehicule_SRV.Delete(vehicule);
        }
    }
}
