﻿using e_shift.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_shift.Service
{
    public interface UserTypeService
    {
        void Save(UserType userType);
        void Delete(int id);
    }
}
