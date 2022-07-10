using e_shift.Connection;
using e_shift.Data;
using e_shift.Factory;
using e_shift.Util;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_shift.Service.Impl
{
    public class LoadServiceImpl : LoadService
    {
        private AppDBContext dbContext;
        private JobService jobService;
        private UserService userService;
        public LoadServiceImpl()
        {
            dbContext = AppDbConnection.getAppDBContext();
            jobService = ServiceFactory.getInstance().getFactory(ServiceFactory.Instance.JOB);
            userService = ServiceFactory.getInstance().getFactory(ServiceFactory.Instance.USER);
        }
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Load Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Load> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Save(List<Load> loadList, Job job)
        {
            try{
                Job response = jobService.Save(job);
                response.User = userService.Get(Convert.ToInt32(LoggedUserTemp.LoggedUserId));
                loadList.ForEach(l => {
                Load load = l;
                load.CreatedAt = DateTime.Now;
                load.Job = response;
                var result = dbContext.Loads.Add(load);
                dbContext.SaveChanges();
            });
            }catch(Exception e){
                throw new Exception("Failed To Save Loads"+e.Message);
            }
        }

        public void Update(Load load)
        {
            throw new NotImplementedException();
        }
    }
}
