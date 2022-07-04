using e_shift.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_shift.Service
{
    public interface CustomerService
    {
        void Save(Customer customer);
        void Delete(int id);
        void Update(Customer customer);
        List<Customer> GetAll();
        Customer Get(int id);
        List<Customer> Search(string searchText);
    }
}
