using Bytes2you.Validation;
using VetClinic.Core.ClinicServices.Contracts;

namespace VetClinic.Core.Services
{
    public class Product : IProduct
    {
        private readonly string name;
        private readonly decimal price;

        public Product(string name, decimal price)
        {
            Guard.WhenArgument(name, "Name is null!").IsNullOrEmpty().Throw();
            Guard.WhenArgument(name.Length, "Name must be between 3 and 20 symbols long!").IsLessThan(3).IsGreaterThan(20).Throw();
            Guard.WhenArgument(price, "Price must be positive").IsLessThan(0).Throw();
            this.name = name;
            this.price = price;
        }

        public string Name { get; }

        public decimal Price { get; }
    }
}
