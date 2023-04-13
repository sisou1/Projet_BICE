using BICE.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BICE.SRV
{
    public interface IVehicule_SRV<Type_DTO>
        where Type_DTO : Vehicule_DTO
    {
        Type_DTO GetById(int id);
        IEnumerable<Type_DTO> GetAll();
        Type_DTO Ajouter(Type_DTO vehicule);
        Type_DTO modifier(Type_DTO vehicule);
        void Supprimer(Type_DTO vehicule);
    }
}
