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

        private ServiceFactory()
        {

        }

        public enum Instance
        {
            USER_TYPE,
            USER,
            CUSTOMER,
            PICKUP_LOCATION,
            DELIVERY_LOCATION,
            JOB,
            LOAD
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
                case Instance.CUSTOMER:
                    return new CustomerServiceImpl();
                case Instance.PICKUP_LOCATION:
                    return new PickupLocationServiceImpl();
                case Instance.DELIVERY_LOCATION:
                    return new DeliveryLocationServiceImpl();
                case Instance.JOB:
                    return new JobServiceImpl();
                case Instance.LOAD:
                    return new LoadServiceImpl();
                default: return null;
            }
        }
    }
}
