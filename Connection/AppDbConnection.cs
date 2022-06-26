using e_shift.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_shift.Connection
{
    public class AppDbConnection
    {
        static AppDBContext appDBContext;

        public static AppDBContext getAppDBContext()
        {
            if (appDBContext == null)
            {
                return new AppDBContext();
            }
            return appDBContext;
        }
    }
}
