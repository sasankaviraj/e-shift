using e_shift.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_shift.Service
{
    public interface JobService
    {
        void Save(Job job);
        Job Get(int id);
        void Delete(int id);
        void Update(Job job);
        List<Job> GetAll();
    }
}
