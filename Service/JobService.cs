using e_shift.Data;
using e_shift.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_shift.Service
{
    public interface JobService
    {
        Job Save(Job job);
        Job Get(int id);

        List<JobsTableModel> Search(string search);
        List<JobsTableModel> GetByUserId(int id);
        void Delete(int id);
        void Update(int id);
        List<JobsTableModel> GetAll();
    }
}
