using e_shift.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_shift.Service
{
    public interface DeliveryLocationService
    {
        void Save(DeliveryLocation deliveryLocation);
        void Delete(int id);
        List<DeliveryLocation> GetAll();
        DeliveryLocation Get(int id);
    }
}
