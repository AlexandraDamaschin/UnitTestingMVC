using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCUnitTesting.Models
{
    public class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        public decimal Price { get; set; }
    }
}