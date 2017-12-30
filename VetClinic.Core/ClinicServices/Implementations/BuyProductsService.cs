using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VetClinic.Core.ClinicServices.Contracts;
using VetClinic.Data.Contracts;
using VetClinic.Data.Models;

namespace VetClinic.Core.Services // could be done in the same way as cashRegister
{
    public class BuyProductService : Service, IService
    {
        // replace with CRUD operations
        private static ICollection<IProduct> allProducts = new List<IProduct>()
        {
            { new Product("Medicine", 11.80m)},
            { new Product("Vitamins", 11.80m)},
            { new Product("Food", 11.80m)}
        };

        public BuyProductService()
            : base("Buy products")
        {
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

        //public override string PrintInfo)
        //{
        //    return $"  {this.Id}. {this.Name}".Trim();
        //}

        //public override void Execute()
        //{
        //    PrintProducts();

        //    decimal sum = 0m;
        //    while (true)
        //    {
        //        string line = Console.ReadLine();
        //        if (line == string.Empty)
        //        {
        //            break;
        //        }
        //        string[] arr = line.Split(' ');

        //        Guard.WhenArgument(arr[0], "Product name is null!").IsNullOrEmpty().Throw();
        //        Guard.WhenArgument(arr[0].Length, "Product name must be longer than 1 and shorter than 20 symbols").IsLessThan(2).IsGreaterThan(19).Throw();
        //        Guard.WhenArgument(int.Parse(arr[1]), "Quantity must be positive").IsLessThan(0).Throw();

        //        IProduct product = FindByName(arr[0]);
        //        int qunatity = int.Parse(arr[1]);
        //        sum += (product.Price * qunatity);
        //    }
        //    // TODO :
        //    BuyProductService serviceToAdd = new BuyProductService();
        //    serviceToAdd.Price = sum;
        //    // this.UsedServices.Add(serviceToAdd);
        //}
    }
}

