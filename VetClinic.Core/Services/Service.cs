namespace VetClinic.Core.Services
{
    using System;
    using VetClinic.Core.Services.Contracts;

    public class Service : IService
    {
        private readonly decimal price;
        private readonly string name;
        private readonly string id;

        public Service(string name, decimal price)
        {
            this.id = Guid.NewGuid().ToString();
            this.name = name;
            this.price = price;
        }

        public string Id => this.id;

        public string Name => this.name;

        public decimal Price => this.price;

        public string Print()
        {
            return $"{this.Name} - Price: ${this.Price}".Trim();
        }
    }
}
