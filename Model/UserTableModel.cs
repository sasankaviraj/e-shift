using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_shift.Model
{
    public class UserTableModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NIC { get; set; }
        public string Address { get; set; }
        public string ContactNumber { get; set; }
        public string UserType { get; set; }
    }
}
