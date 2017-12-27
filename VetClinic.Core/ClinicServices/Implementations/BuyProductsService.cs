using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using VetClinic.Core.ClinicServices.Contracts;
using VetClinic.Core.ClinicServices.Implementations;
using Bytes2you.Validation;

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

        public IProduct FindByName(string name)
        {
            return allProducts.FirstOrDefault(s => s.Name == name);
        }

        public override string Print()
        {
            return $"  {this.Id}. {this.Name}".Trim();
        }

        public override void Execute()
        {
            this.PrintProducts();

            while (true)
            {
                string line = Console.ReadLine();
                if (line == string.Empty)
                {
                    break;
                }
                string[] arr = line.Split(' ');

                Guard.WhenArgument(arr[0], "Product name is null!").IsNullOrEmpty().Throw();
                Guard.WhenArgument(arr[0].Length, "Product name must be longer than 1 and shorter than 20 symbols").IsLessThan(2).IsGreaterThan(19).Throw();
                Guard.WhenArgument(int.Parse(arr[1]), "Quantity must be positive").IsLessThan(0).Throw();

                IProduct product = FindByName(arr[0]);
                int qunatity = int.Parse(arr[1]);

                // TODO add to user wallet and serviceList;

            }
           
        }
    }
}

