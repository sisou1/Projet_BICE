using BICE.DAL;
using BICE.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BICE.SRV
{
    public class GestionVehicule_SRV : IGestionVehicule_SRV
    {
        protected IDepot_DAL<Vehicule_DAL> depot_vehicule;
        public GestionVehicule_SRV(IDepot_DAL<Vehicule_DAL> depot)
        {
            this.depot_vehicule = depot;
        }
        public GestionVehicule_SRV() : this(new Vehicule_Depot_DAL()) { }

        public Vehicule_DTO Insert(Vehicule_DTO vehicule)
        {
            var vehicule_DAL = new Vehicule_DAL(
                vehicule.Id,
                vehicule.Immatriculation,
                vehicule.Denomination,
                vehicule.Numero,
                vehicule.EstActive
                );
            depot_vehicule.Insert(vehicule_DAL);

            return vehicule;
        }

        public Vehicule_DTO GetById(int id)
        {
            var Vehicule_DAL = depot_vehicule.GetById(id);

            return new Vehicule_DTO()
            {
                Id = Vehicule_DAL.Id,
                Immatriculation = Vehicule_DAL.Immatriculation,
                Denomination = Vehicule_DAL.Denomination,
                Numero = Vehicule_DAL.Numero,
                EstActive = Vehicule_DAL.EstActive
            };
        }

        public Vehicule_DTO Update(Vehicule_DTO vehicule)
        {
            var vehicule_DAL = new Vehicule_DAL(
            vehicule.Id,
                vehicule.Immatriculation,
                vehicule.Denomination,
                vehicule.Numero,
                vehicule.EstActive
                );
            depot_vehicule.Update(vehicule_DAL);

            return vehicule;
        }

        public IEnumerable<Vehicule_DTO> GetAll()
        {
            //retourne une liste de vehicule DTO
            return depot_vehicule.GetAll().Select(Vehicule_DAL => new Vehicule_DTO()
            {
                Id = Vehicule_DAL.Id,
                Immatriculation = Vehicule_DAL.Immatriculation,
                Denomination = Vehicule_DAL.Denomination,
                Numero = Vehicule_DAL.Numero,
                EstActive = Vehicule_DAL.EstActive

            });
        }
        public void Delete(Vehicule_DTO vehicule)
        {
            var vehicule_DAL = new Vehicule_DAL(
            vehicule.Id,
                vehicule.Immatriculation,
                vehicule.Denomination,
                vehicule.Numero,
                vehicule.EstActive
                );
            depot_vehicule.Delete(vehicule_DAL);
        }
    }
}
