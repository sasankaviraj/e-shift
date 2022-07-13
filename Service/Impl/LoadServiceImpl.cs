using e_shift.Connection;
using e_shift.Data;
using e_shift.Factory;
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
    public class LoadServiceImpl : LoadService
    {
        private AppDBContext dbContext;
        private JobService jobService;
        private UserService userService;
        private PaymentService paymentService;
        public LoadServiceImpl()
        {
            dbContext = AppDbConnection.getAppDBContext();
            jobService = ServiceFactory.getInstance().getFactory(ServiceFactory.Instance.JOB);
            userService = ServiceFactory.getInstance().getFactory(ServiceFactory.Instance.USER);
            paymentService = ServiceFactory.getInstance().getFactory(ServiceFactory.Instance.PAYMENT);
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
            decimal vehicleCharge = 0;
            decimal carryingCharge = 0;
            try
            {
                Job response = jobService.Save(job);
                response.User = userService.Get(Convert.ToInt32(LoggedUserTemp.LoggedUser.Id));
                loadList.ForEach(l => {
                Load load = l;
                load.CreatedAt = DateTime.Now;
                load.Job = response;
                var result = dbContext.Loads.Add(load);
                    dbContext.Entry(load.ProductType).State = EntityState.Unchanged;
                    dbContext.Entry(load.Job.User).State = EntityState.Unchanged;
                    dbContext.Entry(load.Job.Transport).State = EntityState.Unchanged;
                    dbContext.Entry(load.Job.PickupLocation).State = EntityState.Unchanged;
                    dbContext.Entry(load.Job.DeliveryLocation).State = EntityState.Unchanged;
                    dbContext.SaveChanges();
                    carryingCharge = carryingCharge + load.ProductType.Charges;
            });
                vehicleCharge = response.Transport.ChargesPerKm;
                decimal deliveryCharges = (response.DeliveryLocation.UnitsFromColombo * vehicleCharge) +carryingCharge;

                Payment payment = new Payment();
                payment.DeliveryCharges = deliveryCharges;
                payment.JobId = response.Id;
                paymentService.Save(payment);
            }
            catch(Exception e){
                throw new Exception("Failed To Save Loads"+e.Message);
            }
        }

        public void Update(Load load)
        {
            throw new NotImplementedException();
        }
    }
}
