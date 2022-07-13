using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_shift.Model
{
    public class JobsTableModel
    {
        public int Id { get; set; }
        public string Transport { get; set; }
        public string Name { get; set; }
        public string NIC { get; set; }
        public string Pickup { get; set; }
        public string Delivery { get; set; }
        public string ContactNumber { get; set; }
        public decimal DeliveryCharges { get; set; }
        public string User { get; set; }
        public string CreatedDate { get; set; }
        public bool Approval { get; set; }
        public bool IsDelivered { get; set; }
        public bool IsSuccess { get; set; }
    }
}
