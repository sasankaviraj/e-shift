﻿using e_shift.Connection;
using e_shift.Data;
using e_shift.Factory;
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
        private UserTypeService typeService;
        public UserServiceimpl()
        {
            dbContext = AppDbConnection.getAppDBContext();
            typeService = ServiceFactory.getInstance().getFactory(ServiceFactory.Instance.USER_TYPE);
        }


        public void Save(User user)
        {
            try
            {
                User res = dbContext.Users.Where(u => u.UserName == user.UserName).FirstOrDefault();
                if (res != null)
                {
                    throw new Exception("Username Already Defined");
                }
                user.CreatedAt = DateTime.Now;
                var result = dbContext.Users.Add(user);
                dbContext.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception("Failed To Save User. " + e.Message);
            }
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

        public User Find(User user)
        {
            try
            {
                User response = dbContext.Users.Where(u => u.UserName == user.UserName).FirstOrDefault();
                Console.WriteLine("resp... "+response);
                if (response == null) {
                    throw new Exception("Invalid Username ");
                }
                string decryptedPassword = EncryptDecryptPassword.DecryptCipherTextToPlainText(response.Password);
                if (!decryptedPassword.Equals(user.Password))
                {
                    throw new Exception("Invalid Password ");
                }
                return response;
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
                    FirstName = res.FirstName,
                    LastName = res.FirstName,
                    NIC = res.NIC,
                    ContactNumber = res.ContactNumber,
                    UserType = res.UserType
                }).ToList<UserTableModel>();
            }
            catch (Exception)
            {
                throw new Exception("Failed To Find Users");
            }
        }

        public void Update(User user)
        {
            try
            {
                var find = Get(user.Id);
                find.ModifiedAt = DateTime.Now;
                find.FirstName = user.FirstName;
                find.LastName = user.LastName;
                find.NIC = user.NIC;
                find.Address = user.Address;
                find.ContactNumber = user.ContactNumber;
                find.UserType = user.UserType;
                dbContext.Entry(find).State = EntityState.Modified;
                dbContext.SaveChanges();
            }catch   (Exception e) {
                throw new Exception("Failed To Update User. " + e.Message);
            }
        }
    }
}
