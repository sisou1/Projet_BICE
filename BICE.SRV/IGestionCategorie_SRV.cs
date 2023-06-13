using BICE.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BICE.SRV
{
    public interface IGestionCategorie_SRV
    {
        public Categorie_DTO Insert(Categorie_DTO categorie);
        public void Delete(Categorie_DTO categorie);
        public IEnumerable<Categorie_DTO> GetAll();
        public Categorie_DTO Update(Categorie_DTO categorie);
    }
}
