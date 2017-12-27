using System;
using System.Collections.Generic;
using System.Text;
using VetClinic.Core.ClinicServices.Contracts;
using VetClinic.Core.ClinicServices.Implementations;

namespace VetClinic.Core.Services
{
    public class BuyProductService : Service, IService
    {
        private ICollection<IProduct> allProducts = new List<IProduct>
        {
            { new Product("Medicine", 11.80m)},
            { new Product("Vitamins", 11.80m)},
            { new Product("Food", 11.80m)}
        };

        public BuyProductService()
            : base("Buy products")
        {
            this.allProducts = new List<IProduct>();
        }

        public void SellProducts(IList<Purchase> purchases)
        {
            decimal total = 0m;

            foreach (var item in purchases)
            {
                total += item.Product.Price * item.Quantity;
            }

            base.Price = total;
        }

        public void PrintProducts()
        {
            var sb = new StringBuilder();

            foreach (var item in allProducts)
            {
                sb.AppendLine($"   {item.Name} - ${item.Price}");
            }

            Console.WriteLine(sb.ToString());
        }

        public override string Print()
        {
            return $"  {this.Id}. {this.Name}".Trim();
        }
    }
}

