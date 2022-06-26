using e_shift.Service.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_shift.Factory
{
    public class ServiceFactory
    {
        private static ServiceFactory factory;

        public enum Instance
        {
            USER_TYPE,
            USER
        }

        public static ServiceFactory getInstance()
        {
            if (factory == null)
            {
                return new ServiceFactory();
            }
            return factory;
        }

        public dynamic getFactory(Instance instance)
        {
            switch (instance)
            {
                case Instance.USER_TYPE:
                    return new UserTypeServiceImpl();
                case Instance.USER:
                    return new UserServiceimpl();
                default: return null;
            }
        }
    }
}
