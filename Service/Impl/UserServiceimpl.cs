using e_shift.Connection;
using e_shift.Data;
using e_shift.Model;
using e_shift.Util;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
            try
            {
                User user = dbContext.Users.Find(id);
                user.IsDeleted = true;
                user.DeletedAt = DateTime.Now;
                dbContext.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception("Failed To Delete User. " + e.Message);
            }
        }

        public bool Find(User user)
        {
            try
            {
                User response = dbContext.Users.Include(ut => ut.UserType).Where(u => u.UserName == user.UserName).FirstOrDefault();
                Console.WriteLine("resp... "+response);
                if (response == null) {
                    throw new Exception("Invalid Username ");
                }
                string decryptedPassword = EncryptDecryptPassword.DecryptCipherTextToPlainText(response.Password);
                return decryptedPassword.Equals(user.Password) ? true : false;
            }
            catch (Exception e) {
                throw new Exception("Failed To Login " + e.Message);
            }
        }

        public User Get(int id)
        {  
            try
            {
                return dbContext.Users.Find(id);
            }
            catch (Exception e)
            {
                throw new Exception("Failed To Find User "+e.Message);
            }
        }

        public List<UserTableModel> GetAll()
        {
            try
            {
                return dbContext.Users.Include(ut => ut.UserType).Where(u => u.IsDeleted == false).Select(res=> new UserTableModel() {
                    Id = res.Id,
                    Address = res.Address,
                    Name = res.Name,
                    ContactNumber = res.ContactNumber,
                    UserType = res.UserType.Type
                }).ToList<UserTableModel>();
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
                dbContext.Entry(user.UserType).State = EntityState.Unchanged;
                dbContext.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception("Failed To Save User. "+e.Message);
            }
        }

        public void Update(User user)
        {
            try
            {
                var find = Get(user.Id);
                find.ModifiedAt = DateTime.Now;
                find.Name = user.Name;
                find.Address = user.Address;
                find.ContactNumber = user.ContactNumber;
                find.UserType = user.UserType;
                dbContext.Entry(find).State = EntityState.Modified;
                dbContext.Entry(find.UserType).State = EntityState.Unchanged;
                dbContext.SaveChanges();
            }catch   (Exception e) {
                throw new Exception("Failed To Update User. " + e.Message);
            }
        }
    }
}
