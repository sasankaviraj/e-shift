using e_shift.Connection;
using e_shift.Data;
using e_shift.Factory;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_shift.Service.Impl
{
    public class LoadServiceImpl : LoadService
    {
        private AppDBContext dbContext;
        private JobService jobService;
        public LoadServiceImpl()
        {
            dbContext = AppDbConnection.getAppDBContext();
            jobService = ServiceFactory.getInstance().getFactory(ServiceFactory.Instance.JOB);
        }
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Load Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Load> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Save(List<Load> loadList, Job job)
        {
            Job response = jobService.Save(job);
            loadList.ForEach(load => {
                load.CreatedAt = DateTime.Now;
                load.Job = response;
                var result = dbContext.Loads.Add(load);
                dbContext.Entry(load.Job).State = EntityState.Unchanged;
                dbContext.SaveChanges();
            });
        }

        public void Update(Load load)
        {
            throw new NotImplementedException();
        }
    }
}
