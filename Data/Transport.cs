using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_shift.Data
{
    public class Transport:BaseEntity
    {
        public int Id { get; set; }
        public string Vehicle { get; set; }
        public string RegNo { get; set; }
        public string Driver { get; set; }
        public decimal ChargesPerKm { get; set; }
    }
}
