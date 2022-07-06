using e_shift.Data;
using e_shift.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_shift.Service
{
    public interface UserService
    {
        void Save(User user);
        void Delete(int id);
        void Update(User user);
        User Get(int id);
        bool Find(User user);
        List<UserTableModel> GetAll();
    }
}
