using e_shift.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_shift.Service
{
    public interface PaymentService
    {
        void Save(Payment payment);
        Payment Get(int id);
        List<Payment> GetAll();
    }
}
