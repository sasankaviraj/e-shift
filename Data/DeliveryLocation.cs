﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_shift.Data
{
    public class DeliveryLocation:BaseEntity
    {
        public int Id { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public int UnitsFromColombo { get; set; }
    }
}
