using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_shift.Data
{
    public class Product:BaseEntity
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public decimal Charges { get; set; }
        public ICollection<Load> Users { get; set; }
    }
}
