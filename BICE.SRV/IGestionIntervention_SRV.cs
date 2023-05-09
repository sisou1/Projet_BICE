using BICE.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BICE.SRV
{
    public interface IGestionIntervention_SRV
    {
        public Intervention_DTO Insert(Intervention_DTO intervention);
    }
}
