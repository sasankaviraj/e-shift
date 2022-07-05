using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_shift.Data
{
    public class Load:BaseEntity
    {
        public int Id { get; set; }
        public string Product { get; set; }
        public decimal Weight { get; set; }
        public Customer Customer { get; set; }
    }
}
