using System.Linq.Expressions;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace ComputerShop
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

            // a. Lambda expression for products above 5000 kr.
            Func<Product, bool> expensiveProduct = product => product.Price > 5000m;

            // b. Filter products using the lambda expression
            var expensiveProducts = products.Where(expensiveProduct);

            Console.WriteLine("Expensive Products and screens: ");
            foreach (Product product in expensiveProducts)
            {
                Console.WriteLine(product.Name);
            }

            // c. Products above 10000 kr. OR in the "Skærm" department
            Func<Product, bool> expensiveOrScreen =product => product.Price > 10000m || product.Department == "Skærm";

            var expensiveOrScreenProducts = products.Where(expensiveOrScreen);

            Console.WriteLine("\nProducts above 10000 kr. or screens:");
            foreach (Product product in expensiveOrScreenProducts)
            {
                Console.WriteLine($"{product.Name} - {product.Price} kr.");
            }

            // d. Products between 1000 and 10000 kr. that are not accessories
            Func<Product, bool> midRangeProduct = product => product.Price >= 1000m && product.Price <= 10000m && product.Department != "Tilbehør";

            // e. Filter and sort from highest to lowest price
            var sortedProducts = products.Where(midRangeProduct).OrderByDescending(product => product.Price);

            Console.WriteLine("\nProducts ranging the 1000-10.000 price, excluding accessories:");
            foreach (Product product in sortedProducts)
            {
                Console.WriteLine(product.Name);
            }

            // 3 Anonymous Types

            // a. Selects the name, department and price using an anonymous type.
            var productInfo = products.Select(product => new
            {
                product.Name,
                product.Department,
                product.Price
            });

            // 4 Query Operators

            // Find all computers
            var allComputers = products.Where(product => product.Department == "Computer");

            Console.WriteLine("Computers");
            foreach (Product product in allComputers)
            {
                Console.WriteLine($"{product.Name} - {product.Price} kr.");
            }

            // Find all products above 1000 kr.
            var priceyProducts = products.Where(product => product.Price > 1000m);

            Console.WriteLine("\nProducts above 1000 kr.");
            foreach (Product product in priceyProducts)
            {
                Console.WriteLine($"{product.Name} - {product.Price} kr.");
            }

            // Sort products by price
            var priceOrder = products.OrderBy(product => product.Price);

            Console.WriteLine("\nProducts sorted by price");
            foreach (Product product in priceOrder)
            {
                Console.WriteLine($"{product.Name} - {product.Price} kr.");
            }

            // Find the most expensive product
            Product? mostExpensiveProduct = products.MaxBy(product => product.Price);

            Console.WriteLine("\nMost expensive product");
            if (mostExpensiveProduct != null)
            {
                Console.WriteLine($"{mostExpensiveProduct.Name} - {mostExpensiveProduct.Price} kr.");
            }

            // Count all products
            int productCount = products.Count();

            Console.WriteLine("\nProduct count");
            Console.WriteLine($"Number of products: {productCount}");

            // 5 Query Expressions

            // Sort products by price using query syntax
            var priceSortedProducts =
                from product in products
                orderby product.Price
                select product;

            Console.WriteLine("\nProducts sorted by price:");
            foreach (Product product in priceSortedProducts)
            {
                Console.WriteLine($"{product.Name}: {product.Price} kr.");
            }

            // 6 Expression Tree

            // Stores the lambda as an expression tree that can be inspected
            Expression<Func<Product, bool>> expensiveProductExpression = product => product.Price > 5000;
        }
    }
}