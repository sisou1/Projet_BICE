using BICE.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BICE.SRV
{
    internal interface IMateriel_SRV<Type_DTO>
        where Type_DTO : Materiel_DTO
    {
        Type_DTO GetById(int id);
        IEnumerable<Type_DTO> GetAll();
        Type_DTO Ajouter(Type_DTO Materiel);
        Type_DTO modifier(Type_DTO Materiel);
        void Supprimer(Type_DTO Materiel);
    }
}
