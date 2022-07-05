using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_shift.Data
{
    public class Load:BaseEntity
    {
        public int Id { get; set; }
        [Required]
        public string Product { get; set; }
        [Required]
        public decimal Weight { get; set; }
        [Required]
        public Job Job { get; set; }
    }
}
