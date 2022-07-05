using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_shift.Data
{
    public class Job: BaseEntity
    {
        public int Id { get; set; }
        [Required]
        public User User { get; set; }
        [Required]
        public Customer Customer { get; set; }
        [Required]
        public string FromAddress { get; set; }
        [Required]
        public string ToAddress { get; set; }
        [Required]
        public PickupLocation PickupLocation { get; set; }
        [Required]
        public DeliveryLocation DeliveryLocation { get; set; }
        public ICollection<Load> Loads { get; set; }
        public bool IsDelivered { get; set; }
        public bool IsSuccess { get; set; }
    }
}
