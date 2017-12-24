namespace VetClinic.Data.Models
{
    using Bytes2you.Validation;
    using Contracts;
    using System;
    using System.Collections.Generic;

    public abstract class Supply : ISupply, ISuppliable
    {
        private readonly string name;
        private readonly int quantity;
        private readonly ICollection<ISupply> supplies;

        public Supply(string name, int quantity)
        {
            Guard.WhenArgument(name, "Name is null or empty.").IsNullOrEmpty().Throw();
            Guard.WhenArgument(name.Length, "Ivalid name length.").IsLessThan(2).IsGreaterThan(15).Throw();
            Guard.WhenArgument(quantity, "Ivalid quantity.").IsLessThan(0).Throw();

            this.name = name;
            this.quantity = quantity;
            this.supplies = new List<ISupply>();

        }

        public string Name => this.name;

        public int Quantity => this.quantity;

        public virtual void PrintSupplies()
        {
            foreach (var item in supplies)
            {
                Console.WriteLine($"{item.Name} : {item.Quantity}");
            }
        }
    }
}
