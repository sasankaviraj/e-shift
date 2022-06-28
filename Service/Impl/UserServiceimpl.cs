using e_shift.Connection;
using e_shift.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_shift.Service.Impl
{
    public class UserServiceimpl : UserService
    {
        private AppDBContext dbContext;

        public UserServiceimpl()
        {
            dbContext = AppDbConnection.getAppDBContext();
        }
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public User Get(int id)
        {  
            try
            {
                return dbContext.Users.Find(id);
            }
            catch (Exception)
            {
                throw new Exception("Failed To Find User");
            }
        }

        public List<User> GetAll()
        {
            try
            {
                return dbContext.Users.ToList<User>();
            }
            catch (Exception)
            {
                throw new Exception("Failed To Find Users");
            }
        }

        public void Save(User user)
        {
            try
            {
                User res = dbContext.Users.Where(u => u.UserName == user.UserName).FirstOrDefault();
                if (res!=null) {
                    throw new Exception("Username Already Defined");
                }
                user.CreatedAt = DateTime.Now;
                var result = dbContext.Users.Add(user);
                dbContext.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception("Failed To Save User. "+e.Message);
            }
        }

        public void Update(User user, int id)
        {
            throw new NotImplementedException();
        }
    }
}
