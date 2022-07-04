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
    public class CustomerServiceImpl : CustomerService
    {
        private AppDBContext dbContext;

        public CustomerServiceImpl()
        {
            dbContext = AppDbConnection.getAppDBContext();
        }
        public void Delete(int id)
        {
            try
            {
                Customer customer = dbContext.Customers.Find(id);
                customer.IsDeleted = true;
                customer.DeletedAt = DateTime.Now;
                dbContext.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception("Failed To Delete Customer. " + e.Message);
            }
        }

        public Customer Get(int id)
        {
            try
            {
                return dbContext.Customers.Find(id);
            }
            catch (Exception e)
            {
                throw new Exception("Failed To Find Customer " + e.Message);
            }
        }

        public List<Customer> GetAll()
        {
            try
            {
                return dbContext.Customers.Where(c => c.IsDeleted == false).ToList<Customer>();
            }
            catch (Exception)
            {
                throw new Exception("Failed To Find Customers");
            }
        }

        public void Save(Customer customer)
        {
            try
            {
                Customer res = dbContext.Customers.Where(u => u.NIC == customer.NIC).FirstOrDefault();
                if (res != null)
                {
                    throw new Exception("NIC Already Defined");
                }
                customer.CreatedAt = DateTime.Now;
                var result = dbContext.Customers.Add(customer);
                dbContext.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception("Failed To Save Customer. " + e.Message);
            }
        }

        public List<Customer> Search(string searchText)
        {
            throw new NotImplementedException();
        }

        public void Update(Customer customer)
        {
            try
            {
                var find = Get(customer.Id);
                find.ModifiedAt = DateTime.Now;
                find.FirstName = customer.FirstName;
                find.LastName = customer.LastName;
                find.Address = customer.Address;
                find.ContactNumber = customer.ContactNumber;
                find.NIC = customer.NIC;
                dbContext.Entry(find).State = EntityState.Modified;
                dbContext.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception("Failed To Update Customer. " + e.Message);
            }
        }
    }
}
