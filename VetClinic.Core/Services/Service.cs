namespace VetClinic.Core.Services
{
    using System;
    using VetClinic.Core.Services.Contracts;

    public class Service : IService
    {
        private decimal price;
        private readonly string name;
        private readonly string id;
        private static int count = 1;

        public Service(string name)
        {
            if (name == null || name.Length < 3 || name.Length > 13)
            {
                throw new ArgumentException("Service name must be more than 2 symbols and less than 14 symbols long!");
            }

            this.name = name;
            this.id = (count++).ToString();
        }

        public Service(string name, decimal price)
            : this(name)
        {
            if (price < 0.0m)
            {
                throw new ArgumentException("Price must be positive!");
            }

            this.price = price;
        }

        public string Id => this.id;

        public string Name => this.name;

        public decimal Price
        {
            get => this.price;
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Price must be positive!");
                }
                this.price = value;
            }
        }

        public string Print()
        {
            return $"{this.Id}. {this.Name} - Price: ${this.Price}".Trim();
        }
    }
}
