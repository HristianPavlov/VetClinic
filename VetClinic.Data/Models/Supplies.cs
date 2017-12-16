namespace VetClinic.Data.Models
{
    using Bytes2you.Validation;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;

    public abstract class Supplies : ISuppliable
    {
        private string name;
        private static ICollection<Supplies> listOfSupplies = new List<Supplies>();

        public Supplies(string name)
        {
            this.Name = name;
            if (!listOfSupplies.Any(product => product.Name == name))  // this.name ????
            {
                listOfSupplies.Add(this);
            }

        }

        public string Name
        {
            get => this.name; 
            set
            {
                Guard.WhenArgument(value, "Name is null or empty.").IsNullOrEmpty().Throw();
                Guard.WhenArgument(value.Length, "Ivalid name length.").IsLessThan(2).IsGreaterThan(15).Throw();
                this.name = value;
            }
        }

        public abstract int Quantity { get;}

        public virtual void PrintSupplies()
        {
            foreach (var item in listOfSupplies)
            {
                Console.WriteLine($"{item.Name} : {item.Quantity}");
            }
        }
    }
}
