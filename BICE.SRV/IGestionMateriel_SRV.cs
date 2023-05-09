using BICE.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BICE.SRV
{
    public interface IGestionMateriel_SRV
    {
        public  Materiel_DTO GetById(int id);
        public  Materiel_DTO Insert(Materiel_DTO materiel);
        public  void Delete(Materiel_DTO materiel);
        public IEnumerable<Materiel_DTO> GetAll();
        public  Materiel_DTO Update(Materiel_DTO materiel);
    }
}
