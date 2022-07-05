using e_shift.Connection;
using e_shift.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_shift.Service.Impl
{
    public class PickupLocationServiceImpl : PickupLocationService
    {
        private AppDBContext dbContext;

        public PickupLocationServiceImpl()
        {
            dbContext = AppDbConnection.getAppDBContext();
        }
        public void Delete(int id)
        {
            try
            {
                PickupLocation pickupLocation = dbContext.PickupLocations.Find(id);
                pickupLocation.IsDeleted = true;
                pickupLocation.DeletedAt = DateTime.Now;
                dbContext.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception("Failed To Delete Pickup Location. " + e.Message);
            }
        }

        public PickupLocation Get(int id)
        {
            try
            {
                return dbContext.PickupLocations.Find(id);
            }
            catch (Exception e)
            {
                throw new Exception("Failed To Find Pickup Location " + e.Message);
            }
        }

        public List<PickupLocation> GetAll()
        {
            try
            {
                return dbContext.PickupLocations.Where(p => p.IsDeleted == false).ToList<PickupLocation>();
            }
            catch (Exception)
            {
                throw new Exception("Failed To Find Pickup Locations");
            }
        }

        public void Save(PickupLocation pickupLocation)
        {
            try
            {
                PickupLocation res = dbContext.PickupLocations.Where(p => p.Location == pickupLocation.Location).FirstOrDefault();
                if (res != null)
                {
                    throw new Exception("Location Already Defined");
                }
                pickupLocation.CreatedAt = DateTime.Now;
                var result = dbContext.PickupLocations.Add(pickupLocation);
                dbContext.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception("Failed To Save Pickup Location. " + e.Message);
            }
        }
    }
}
