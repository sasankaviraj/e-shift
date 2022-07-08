using e_shift.Connection;
using e_shift.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_shift.Service.Impl
{
    public class JobServiceImpl : JobService
    {
        private AppDBContext dbContext;
        public JobServiceImpl()
        {
            dbContext = AppDbConnection.getAppDBContext();
        }
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Job Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Job> GetAll()
        {
            throw new NotImplementedException();
        }

        public Job Save(Job job)
        {
            try
            {
                job.CreatedAt = DateTime.Now;
                var result = dbContext.Jobs.Add(job);
                dbContext.Entry(job.Customer).State = EntityState.Unchanged;
                dbContext.Entry(job.DeliveryLocation).State = EntityState.Unchanged;
                dbContext.Entry(job.PickupLocation).State = EntityState.Unchanged;
                dbContext.Entry(job.User).State = EntityState.Unchanged;
                dbContext.SaveChanges();
                return job;
            }
            catch (Exception e)
            {
                throw new Exception("Failed To Save User. " + e.Message);
            }
        }

        public void Update(Job job)
        {
            throw new NotImplementedException();
        }
    }
}
