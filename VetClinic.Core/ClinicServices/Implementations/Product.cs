using System;
using System.Collections.Generic;
using System.Text;
using VetClinic.Core.ClinicServices.Contracts;

namespace VetClinic.Core.Services
{
    public class Product : IProduct
    {
        private readonly string name;
        private readonly decimal price;
        private ICollection<Product> allProducts = new List<Product>
        {
            { new Product("Medicine", 11.80m)},
            { new Product("Vitamins", 11.80m)},
            { new Product("Food", 11.80m)}
        };

        public Product(string name, decimal price)
        {
            this.name = name;
            this.price = price;
        }

        public string Name { get; }

        public decimal Price { get; protected set; }

        public void PrintProducts()
        {
            var sb = new StringBuilder();

            foreach (var item in allProducts)
            {
                sb.AppendLine($"   {item.Name} - ${item.Price}");
            }

            Console.WriteLine(sb.ToString());
        }
    }
}
