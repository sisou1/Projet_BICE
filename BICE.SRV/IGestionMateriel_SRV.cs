using BICE.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BICE.SRV
{
    public class IGestionMateriel_SRV
    {
        public abstract Materiel_DTO GetById(int id);
        public abstract Materiel_DTO Insert(Materiel_DTO materiel);
        public abstract void Delete(Materiel_DTO materiel);
        public abstract List<Materiel_DTO> GetAll();
        public abstract Materiel_DTO Update(Materiel_DTO materiel);
    }
}
