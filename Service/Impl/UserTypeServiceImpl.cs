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
    public class UserTypeServiceImpl : UserTypeService
    {
        private AppDBContext dbContext;
        public UserTypeServiceImpl()
        {
            dbContext = AppDbConnection.getAppDBContext();
        }
        public void Delete(int id)
        {
            try
            {
                UserType userType = dbContext.UserTypes.Find(id);
                userType.IsDeleted = true;
                userType.DeletedAt = DateTime.Now;
                dbContext.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception("Failed To Delete User Type. " + e.Message);
            }
        }

        public UserType Find(string userType)
        {
            
            try
            {
                return dbContext.UserTypes.Where(ut => ut.Type == userType).FirstOrDefault();
            }
            catch (Exception)
            {
                throw new Exception("Failed To Find User Types");
            }
        }

        public UserType Get(int id)
        {
            try
            {
                return dbContext.UserTypes.Find(id);
            }
            catch (Exception)
            {
                throw new Exception("Failed To Find User Types");
            }
        }

        public List<UserType> GetAll()
        {
            try {
                return dbContext.UserTypes.Where(ut => ut.IsDeleted == false).ToList<UserType>();
            } catch (Exception) {
                throw new Exception("Failed To Find User Types");
            }
        }

        public void Save(UserType userType)
        {
            try
            {
                UserType res = dbContext.UserTypes.Where(ut => ut.Type == userType.Type).FirstOrDefault();
                if (res != null) {
                    throw new Exception("User Type Already Defined");
                }
                userType.CreatedAt = DateTime.Now;
                var result = dbContext.UserTypes.Add(userType);
                dbContext.SaveChanges();
            }
            catch (Exception e){
                throw new Exception("Failed To Save User Type. "+e.Message);
            }
        }

        public void Update(UserType userType)
        {
            try {
                UserType find = Get(userType.Id);
                find.ModifiedAt = DateTime.Now;
                find.Type = userType.Type;
                dbContext.Entry(find).State = EntityState.Modified;
                dbContext.SaveChanges();
            } catch (Exception e) {
                throw new Exception("Failed To Update User Type. " + e.Message);
            }
        }
    }
}
