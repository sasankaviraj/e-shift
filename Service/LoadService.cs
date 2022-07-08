using e_shift.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_shift.Service
{
    public interface LoadService
    {
        void Save(List<Load> loadList,Job job);
        Load Get(int id);
        void Delete(int id);
        void Update(Load load);
        List<Load> GetAll();
    }
}
