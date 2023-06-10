using BICE.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BICE.SRV
{
    public interface IGestionMateriel_VI_SRV
    {
        public Materiel_VI_DTO Insert(Materiel_VI_DTO Materiel_VI);
        public IEnumerable<Materiel_VI_DTO> GetAllById(int id);
    }
}
