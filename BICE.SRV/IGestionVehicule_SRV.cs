using BICE.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BICE.SRV
{
    public interface IGestionVehicule_SRV
    {
        public Vehicule_DTO GetById(int id);
        public Vehicule_DTO Insert(Vehicule_DTO vehicule);
        public void Delete(Vehicule_DTO vehicule);
        public IEnumerable<Vehicule_DTO> GetAll();
        public Vehicule_DTO Update(Vehicule_DTO vehicule);
    }
}
