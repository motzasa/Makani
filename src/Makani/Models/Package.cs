﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Makani.Models
{
    public class Package
    {
        public int PackageId { get; set; }
        public string CommercialName { get; set; }
        public string Continent { get; set; }
        public string Country { get; set; }
        public string Rate { get; set; }
        public string DurationCategory { get; set; }
        public string DurationDays { get; set; }
        public string Cities { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string TTD { get; set; }
        public string TTDDescription { get; set; }
        public decimal TotalPrice { get; set; }
        public string Code { get; set; }
        public string Photos { get; set; }
        public DateTime Created { get; set; }
        public string Creator { get; set; }
    }
}
