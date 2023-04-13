using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BICE.DAL
{
    public class Intervention_DAL
    {
        public int Id { get; set; }
        public string Denomination { get; set; }
        public DateTime Date { get; set; }
        public string? Description { get; set; }
        

        public Intervention_DAL(string denomination) => (Denomination) = (denomination);
        public Intervention_DAL(string denomination, DateTime date) : this(denomination) => (Date) = (date);
        public Intervention_DAL(string denomination, DateTime date, string description) : this(denomination,date) => (Description) = (description);
    }
}
