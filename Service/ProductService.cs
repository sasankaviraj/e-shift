using e_shift.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_shift.Service
{
    public interface ProductService
    {
        void Save(Product product);
        void Update(Product product);
        void Delete(int id);
        Product Get(int id);
        Product Find(string product);
        List<Product> GetAll();
    }
}
