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
    public class ProductServiceImpl : ProductService
    {
        private AppDBContext dbContext;
        public ProductServiceImpl()
        {
            dbContext = AppDbConnection.getAppDBContext();
        }
        public void Delete(int id)
        {
            try
            {
                Product product = dbContext.Products.Find(id);
                product.IsDeleted = true;
                product.DeletedAt = DateTime.Now;
                dbContext.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception("Failed To Delete Product. " + e.Message);
            }
        }

        public Product Find(string product)
        {
            try
            {
                return dbContext.Products.Where(p => p.Type == product).FirstOrDefault();
            }
            catch (Exception)
            {
                throw new Exception("Failed To Find Product");
            }
        }

        public Product Get(int id)
        {
            try
            {
                return dbContext.Products.Find(id);
            }
            catch (Exception)
            {
                throw new Exception("Failed To Find Product");
            }
        }

        public List<Product> GetAll()
        {
            try
            {
                return dbContext.Products.Where(p => p.IsDeleted == false).ToList<Product>();
            }
            catch (Exception)
            {
                throw new Exception("Failed To Find Products");
            }
        }

        public void Save(Product product)
        {
            try
            {
                Product res = dbContext.Products.Where(p => p.Type == product.Type).FirstOrDefault();
                if (res != null)
                {
                    throw new Exception("Product Already Defined");
                }
                product.CreatedAt = DateTime.Now;
                var result = dbContext.Products.Add(product);
                dbContext.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception("Failed To Save Product. " + e.Message);
            }
        }

        public void Update(Product product)
        {
            try
            {
                Product find = Get(product.Id);
                find.ModifiedAt = DateTime.Now;
                find.Type = product.Type;
                find.Charges = product.Charges;
                dbContext.Entry(find).State = EntityState.Modified;
                dbContext.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception("Failed To Update Product. " + e.Message);
            }
        }
    }
}
