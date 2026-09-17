using ComputerShop.Product;
using System.Linq.Expressions;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace YourProjectName
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // List of Product
            List<Product> products = new List<Product>
            {
                new Product("Gaming Laptop", "Computer", 12500m),
                new Product("Office Laptop", "Computer", 7500m),
                new Product("Gaming Mus", "Tilbehør", 650m),
                new Product("Keyboard", "Tilbehør", 1100m),
                new Product("4K Skærm", "Skærm", 4500m)
            };

            // 1 Lambda Expression

            // Func<Product, bool> is a generic delegate:
            // takes a Product as input and returns a bool (true/false).
            // The lambda is the condition stored inside the delegate.
            Func<Product, bool> expensiveProduct = product => product.Price > 10000 || product.Department == "Skærm";

            // Where uses the delegate on each Product.
            // Products where it returns true are kept.
            var expensiveProducts = products.Where(expensiveProduct);

            Console.WriteLine("Expensive Products and screens: ");
            foreach (Product product in expensiveProducts)
            {
                Console.WriteLine(product.Name);
            }

            // Another Func<Product, bool> delegate containing a different condition.
            Func<Product, bool> midRangeProduct = product => product.Price >= 1000 && product.Price <= 10000m && product.Department != "Tilbehør";

            // Where filters using the delegate.
            // OrderByDescending then sorts the remaining products from highest to lowest price.
            var sortedProducts = products.Where(midRangeProduct).OrderByDescending(product => product.Price);

            Console.WriteLine("\nProducts ranging the 1000-10.000 price, minus accessory products:");
            foreach (Product product in sortedProducts)
            {
                Console.WriteLine(product.Name);
            }

            // 3 Anonymous Types

            // Select chooses which data we want from each Product.
            // new { } creates an anonymous type - a temporary object without a named class.
            var productInfo = products.Select(product => new
            {
                product.Name,
                product.Department,
                product.Price
            });

            // 4 Query Operators

            // Where filters the collection using a condition.
            var allComputers = products.Where(product => product.Department == "Computer");

            var priceyProducts = products.Where(product => product.Price > 1000m);

            // OrderBy sorts from lowest to highest.
            var priceOrder = products.OrderBy(product => product.Price);

            // MaxBy returns the Product with the highest Price.
            // ? because MaxBy can return null if the collection is empty.
            Product? mostExpensiveProduct = products.MaxBy(product => product.Price);

            // Count returns how many products are in the collection.
            int productCount = products.Count();

            // We ain't printing all that

            // 5 Query Expressions

            // Query Expression - another syntax for writing LINQ queries.
            // This does basically the same thing as:
            // products.OrderBy(product => product.Price)
            var priceSortedProducts =
                from product in products
                orderby product.Price
                select product;

            Console.WriteLine("\nProducts sorted by price:");
            foreach (Product product in priceSortedProducts)
            {
                Console.WriteLine($"{product.Name}: {product.Price} kr.");
            }

            // 6
            // Expression Tree:
            // Unlike a normal Func delegate, this represents the lambda as data/code structure
            // that can be inspected. Technologies like EF Core can use expression trees
            // to understand and translate expressions, for example into SQL.
            Expression<Func<Product, bool>> expensiveProductExpression = product => product.Price > 5000;
        }
    }
}