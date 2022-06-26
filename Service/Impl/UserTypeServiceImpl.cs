using e_shift.Connection;
using e_shift.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_shift.Service.Impl
{
    public class UserTypeServiceImpl : UserTypeService
    {
        AppDBContext dbContext;
        public UserTypeServiceImpl()
        {
            dbContext = AppDbConnection.getAppDBContext();
        }
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Save(UserType userType)
        {
            try
            {
                userType.CreatedAt = DateTime.Now;
                var result = dbContext.UserTypes.Add(userType);
                dbContext.SaveChanges();
            }
            catch (Exception){
                throw new Exception("Failed To Save User");
            }
        }
    }
}
