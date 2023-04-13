using BICE.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BICE.SRV
{
    internal interface IIntervention_SRV<Type_DTO>
        where Type_DTO : Intervention_DTO
    {
        Type_DTO GetById(int id);
        IEnumerable<Type_DTO> GetAll();
        Type_DTO Ajouter(Type_DTO Intervention);
        Type_DTO modifier(Type_DTO Intervention);
        void Supprimer(Type_DTO Intervention);
    }
}
