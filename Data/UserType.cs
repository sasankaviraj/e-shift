using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_shift.Data
{
    public class UserType: BaseEntity
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
