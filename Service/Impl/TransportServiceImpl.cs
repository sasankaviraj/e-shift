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
    public class TransportServiceImpl : TransportService
    {
        private AppDBContext dbContext;

        public TransportServiceImpl()
        {
            dbContext = AppDbConnection.getAppDBContext();
        }
        public void Delete(int id)
        {
            try
            {
                Transport transport = dbContext.Transports.Find(id);
                transport.IsDeleted = true;
                transport.DeletedAt = DateTime.Now;
                dbContext.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception("Failed To Delete Transport. " + e.Message);
            }
        }

        public Transport Get(int id)
        {
            try
            {
                return dbContext.Transports.Find(id);
            }
            catch (Exception e)
            {
                throw new Exception("Failed To Find Transport " + e.Message);
            }
        }

        public List<Transport> GetAll()
        {
            try
            {
                return dbContext.Transports.Where(t => t.IsDeleted == false).ToList<Transport>();
            }
            catch (Exception)
            {
                throw new Exception("Failed To Find Transports");
            }
        }

        public void Save(Transport transport)
        {
            try
            {
                Transport res = dbContext.Transports.Where(t => t.RegNo == transport.RegNo).FirstOrDefault();
                if (res != null)
                {
                    throw new Exception("Registration Number Already Defined");
                }
                transport.CreatedAt = DateTime.Now;
                var result = dbContext.Transports.Add(transport);
                dbContext.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception("Failed To Save Transport. " + e.Message);
            }
        }

        public void Update(Transport transport)
        {
            try
            {
                var find = Get(transport.Id);
                find.ModifiedAt = DateTime.Now;
                find.Vehicle = transport.Vehicle;
                find.RegNo = transport.RegNo;
                find.Driver = transport.Driver;
                find.ChargesPerKm = transport.ChargesPerKm;
                dbContext.Entry(find).State = EntityState.Modified;
                dbContext.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception("Failed To Update Transport. " + e.Message);
            }
        }
    }
}
