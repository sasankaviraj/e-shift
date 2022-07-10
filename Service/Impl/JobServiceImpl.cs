using e_shift.Connection;
using e_shift.Data;
using e_shift.Factory;
using e_shift.Model;
using e_shift.Util;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_shift.Service.Impl
{
    public class JobServiceImpl : JobService
    {
        private AppDBContext dbContext;
        private UserService userService;
        public JobServiceImpl()
        {
            dbContext = AppDbConnection.getAppDBContext();
            userService = ServiceFactory.getInstance().getFactory(ServiceFactory.Instance.USER);
        }
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Job Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<JobsTableModel> GetAll()
        {
            try
            {
                return dbContext.Jobs.Include(j => j.Transport).Include(j => j.PickupLocation).Include(j => j.DeliveryLocation)
                    .Include(j => j.User).Include(j => j.Loads).Where(u => u.IsDeleted == false).Select(res => new JobsTableModel()
                    {
                        Id = res.Id,
                        Transport = res.Transport.Vehicle,
                        Pickup = res.PickupLocation.Location,
                        Delivery = res.DeliveryLocation.Location,
                        ContactNumber = res.User.ContactNumber,
                        User = res.User.FirstName+" "+ res.User.LastName,
                        Approval = res.IsApproved,
                        IsDelivered = res.IsDelivered,
                        IsSuccess = res.IsSuccess,
                        CreatedDate = res.CreatedAt.ToString()
                    }).ToList<JobsTableModel>();
            }
            catch (Exception)
            {
                throw new Exception("Failed To Find Users");
            }
        }

        public Job Save(Job job)
        {
            try
            {
                job.CreatedAt = DateTime.Now;
                job.User = userService.Get(Convert.ToInt32(LoggedUserTemp.LoggedUserId));
                var result = dbContext.Jobs.Add(job);
                dbContext.Entry(job.Transport).State = EntityState.Unchanged;
                dbContext.Entry(job.DeliveryLocation).State = EntityState.Unchanged;
                dbContext.Entry(job.PickupLocation).State = EntityState.Unchanged;
                dbContext.Entry(job.User).State = EntityState.Unchanged;
                dbContext.SaveChanges();
                return job;
            }
            catch (Exception e)
            {
                throw new Exception("Failed To Save Job "+e.Message);
            }
        }

        public void Update(Job job)
        {
            throw new NotImplementedException();
        }
    }
}
