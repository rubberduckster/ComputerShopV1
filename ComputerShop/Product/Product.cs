using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerShop.Product
{
    public class Product
    {
        public string Name { get; set; }
        public string Department { get; set; }
        public decimal Price { get; set; }

        public Product(string name, string department, decimal price)
        {
            Name = name;
            Department = department;
            Price = price;
        }
    }
}
