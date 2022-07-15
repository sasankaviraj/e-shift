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
        private PaymentService paymentService;
        public JobServiceImpl()
        {
            dbContext = AppDbConnection.getAppDBContext();
            userService = ServiceFactory.getInstance().getFactory(ServiceFactory.Instance.USER);
            paymentService = ServiceFactory.getInstance().getFactory(ServiceFactory.Instance.PAYMENT);
        }
        public void Delete(int id)
        {
            try
            {
                Job job = dbContext.Jobs.Find(id);
                job.IsDeleted = true;
                job.DeletedAt = DateTime.Now;
                dbContext.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception("Failed To Delete Job. " + e.Message);
            }
        }

        public Job Get(int id)
        {
            try
            {
                return dbContext.Jobs.Find(id);
            }
             catch (Exception e)
            {
                throw new Exception("Failed To Find Job " + e.Message);
            }
        }

        public List<JobsTableModel> GetAll()
        {
            try
            {
                List<JobsTableModel> jobsTableModels =  dbContext.Jobs.Include(j => j.Transport).Include(j => j.PickupLocation).Include(j => j.DeliveryLocation)
                    .Include(j => j.User).Include(j => j.Loads).Where(u => u.IsDeleted == false).Where(j => j.IsApproved == false).Select(res => new JobsTableModel()
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
                        CreatedDate = res.CreatedAt.ToString(),
                    }).ToList<JobsTableModel>();

                jobsTableModels.ForEach(job => {
                    Payment payment = paymentService.Get(job.Id);
                    if (payment != null)
                    {
                        job.DeliveryCharges = payment.DeliveryCharges;
                    }
                });

                return jobsTableModels;
            }
            catch (Exception)
            {
                throw new Exception("Failed To Find Users");
            }
        }

        public List<JobsTableModel> GetByUserId(int id)
        {
            try
            {
                List<JobsTableModel> jobsTableModels =  dbContext.Jobs.Where(j=> j.User.Id == id).Select(res=> new JobsTableModel()
                {
                    Id = res.Id,
                    Transport = res.Transport.Vehicle,
                    Pickup = res.PickupLocation.Location,
                    Delivery = res.DeliveryLocation.Location,
                    ContactNumber = res.User.ContactNumber,
                    User = res.User.FirstName + " " + res.User.LastName,
                    Approval = res.IsApproved,
                    IsDelivered = res.IsDelivered,
                    IsSuccess = res.IsSuccess,
                    CreatedDate = res.CreatedAt.ToString()
                }).ToList<JobsTableModel>();

                jobsTableModels.ForEach(job => {
                    Payment payment = paymentService.Get(job.Id);
                    if (payment!=null) {
                        job.DeliveryCharges = payment.DeliveryCharges;
                    }
                });

                return jobsTableModels;
            }
            catch (Exception e)
            {
                throw new Exception("Failed To Find Job " + e.Message);
            }
        }

        public Job Save(Job job)
        {
            try
            {
                job.CreatedAt = DateTime.Now;
                job.User = userService.Get(LoggedUserTemp.LoggedUser.Id);
                var result = dbContext.Jobs.Add(job);
                dbContext.Entry(job.Transport).State = EntityState.Unchanged;
                dbContext.Entry(job.DeliveryLocation).State = EntityState.Unchanged;
                dbContext.Entry(job.PickupLocation).State = EntityState.Unchanged;
                dbContext.Entry(job.User).State = EntityState.Unchanged;
                
                dbContext.Entry(job).State = EntityState.Added;
                dbContext.SaveChanges();
                return job;
            }
            catch (Exception e)
            {
                throw new Exception("Failed To Save Job "+e.Message);
            }
        }

        public List<JobsTableModel> Search(string search)
        {
            try
            {
                List<JobsTableModel> jobsTableModels = dbContext.Jobs.Include(j => j.Transport).Include(j => j.PickupLocation).Include(j => j.DeliveryLocation)
                    .Include(j => j.User).Include(j => j.Loads).Where(u => u.IsDeleted == false).Where(j => j.Id.ToString().Contains(search) || j.User.FirstName.Contains(search))
                    .Select(res => new JobsTableModel()
                    {
                        Id = res.Id,
                        Transport = res.Transport.Vehicle,
                        Pickup = res.PickupLocation.Location,
                        Delivery = res.DeliveryLocation.Location,
                        ContactNumber = res.User.ContactNumber,
                        User = res.User.FirstName + " " + res.User.LastName,
                        Approval = res.IsApproved,
                        IsDelivered = res.IsDelivered,
                        IsSuccess = res.IsSuccess,
                        CreatedDate = res.CreatedAt.ToString(),
                    }).ToList<JobsTableModel>();

                jobsTableModels.ForEach(job => {
                    Payment payment = paymentService.Get(job.Id);
                    if (payment != null)
                    {
                        job.DeliveryCharges = payment.DeliveryCharges;
                    }
                });

                return jobsTableModels;
            }
            catch (Exception)
            {
                throw new Exception("Failed To Find Users");
            }
        }

        public void Update(int id)
        {
            try
            {
                Job job = dbContext.Jobs.Find(id);
                job.IsApproved = true;
                job.ModifiedAt = DateTime.Now;
                dbContext.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception("Failed To Approve Job. " + e.Message);
            }
        }
    }
}
