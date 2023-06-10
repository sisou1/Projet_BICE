using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BICE.DTO;

namespace BICE.SRV
{
    public interface IGestionVIntervention_SRV
    {
        public VIntervention_DTO Insert(VIntervention_DTO VIntervention);
        public IEnumerable<VIntervention_DTO> GetAllById(int id);
    }
}
