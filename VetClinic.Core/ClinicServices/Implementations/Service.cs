namespace VetClinic.Core.ClinicServices.Implementations
{
    using Bytes2you.Validation;
    using System;
    using VetClinic.Core.ClinicServices.Contracts;

    public class Service : IService
    {
        private decimal price;
        private readonly string name;
        private readonly string id;

        public Service(string name)
        {
            Guard.WhenArgument(name, "Service name cannot be null!").IsNullOrEmpty().Throw();
            Guard.WhenArgument(name.Length, "Service name must be more than 2 symbols and less than 14 symbols long!").IsLessThan(3).IsGreaterThan(13).Throw();
            this.id = Guid.NewGuid().ToString();
            this.name = name;
        }

        public Service(string name, decimal price)
            : this(name)
        {
            this.Price = price;
        }

        public string Id => this.id;

        public string Name => this.name;

        public decimal Price
        {
            get => this.price;
            protected set
            {
                Guard.WhenArgument(price, "Price must be positive!").IsLessThan(0.0m).Throw();
                this.price = value;
            }
        }

        public string Print()
        {
            return $"{this.Name} - Price: ${this.Price}".Trim();
        }
    }
}
