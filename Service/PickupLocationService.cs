using e_shift.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_shift.Service
{
    public interface PickupLocationService
    {
        void Save(PickupLocation pickupLocation);
        void Delete(int id);
        List<PickupLocation> GetAll();
        PickupLocation Get(int id);
    }
}
