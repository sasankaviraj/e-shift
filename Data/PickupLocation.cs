using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_shift.Data
{
    public class PickupLocation:BaseEntity
    {
        public int Id { get; set; }
        [Required]
        public string Location { get; set; }
    }
}
