using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerShop.Product
{
    public static class ProductExtension
    {
        // 2 Extension Methods
        public static Product? ExpensiveProduct(this Product product)
        {
            if (product.Price < 5000m)
            {
                return product;
            }

            return null;
        }
    }
}
