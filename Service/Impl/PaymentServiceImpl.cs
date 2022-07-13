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
    public class PaymentServiceImpl : PaymentService
    {
        private AppDBContext dbContext;

        public PaymentServiceImpl()
        {
            dbContext = AppDbConnection.getAppDBContext();
        }
        public Payment Get(int id)
        {
            try
            {
                Payment payment = dbContext.Payments.Where(p=> p.JobId == id).FirstOrDefault();
                return payment;
            }
            catch (Exception e)
            {
                throw new Exception("Failed To Find Payments. " + e.Message);
            }
        }

        public List<Payment> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Save(Payment payment)
        {
            try
            {
                payment.CreatedAt = DateTime.Now;
                var result = dbContext.Payments.Add(payment);
                
                dbContext.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception("Failed To Save User. " + e.Message);
            }
        }
    }
}
