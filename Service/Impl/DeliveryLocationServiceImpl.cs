using e_shift.Connection;
using e_shift.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_shift.Service.Impl
{
    public class DeliveryLocationServiceImpl : DeliveryLocationService
    {
        private AppDBContext dbContext;

        public DeliveryLocationServiceImpl()
        {
            dbContext = AppDbConnection.getAppDBContext();
        }
        public void Delete(int id)
        {
            try
            {
                DeliveryLocation deliveryLocation = dbContext.DeliveryLocations.Find(id);
                deliveryLocation.IsDeleted = true;
                deliveryLocation.DeletedAt = DateTime.Now;
                dbContext.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception("Failed To Delete Delivery Location. " + e.Message);
            }
        }

        public DeliveryLocation Get(int id)
        {
            try
            {
                return dbContext.DeliveryLocations.Find(id);
            }
            catch (Exception e)
            {
                throw new Exception("Failed To Find Delivery Location " + e.Message);
            }
        }

        public List<DeliveryLocation> GetAll()
        {
            try
            {
                return dbContext.DeliveryLocations.Where(d => d.IsDeleted == false).ToList<DeliveryLocation>();
            }
            catch (Exception)
            {
                throw new Exception("Failed To Find Delivery Locations");
            }
        }

        public void Save(DeliveryLocation deliveryLocation)
        {
            try
            {
                DeliveryLocation res = dbContext.DeliveryLocations.Where(d => d.Location == deliveryLocation.Location).FirstOrDefault();
                if (res != null)
                {
                    throw new Exception("Location Already Defined");
                }
                deliveryLocation.CreatedAt = DateTime.Now;
                var result = dbContext.DeliveryLocations.Add(deliveryLocation);
                dbContext.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception("Failed To Save Delivery Location. " + e.Message);
            }
        }
    }
}
