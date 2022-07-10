using e_shift.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_shift.Service
{
    public interface TransportService
    {
        void Save(Transport transport);
        void Delete(int id);
        void Update(Transport transport);
        List<Transport> GetAll();
        Transport Get(int id);
    }
}
