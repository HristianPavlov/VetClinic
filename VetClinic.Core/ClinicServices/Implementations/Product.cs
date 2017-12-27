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

        public Product(string name, decimal price)
        {
            this.name = name;
            this.price = price;
        }

        public string Name { get; }

        public decimal Price { get; protected set; }
    }
}
