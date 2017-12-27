namespace VetClinic.Core.ClinicServices.Implementations
{
    using Bytes2you.Validation;
    using System;
    using System.Threading;
    using VetClinic.Core.ClinicServices.Contracts;

    public class Service : IService
    {
        private static int count = 1;

        private decimal price;
        private readonly string name;
        private readonly string id;
        private readonly int timeToExecute;

        public Service(string name, int timeToExecute = 1)
        {
            Guard.WhenArgument(name, "Service name cannot be null!").IsNullOrEmpty().Throw();
            //Guard.WhenArgument(name.Length, "Service name must be more than 2 symbols and less than 14 symbols long!").IsLessThan(3).IsGreaterThan(13).Throw();
            Guard.WhenArgument(timeToExecute, "Time must be positive!").IsLessThan(0).Throw();
            //this.id = Guid.NewGuid().ToString();
            this.id = (count++).ToString();
            this.name = name;
            this.timeToExecute = timeToExecute;
        }

        public Service(string name, decimal price, int timeToExecute)
            : this(name, timeToExecute)
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

        public int TimeToExecute => this.timeToExecute;

        public virtual string Print()
        {
            return $"  {this.Id}. {this.Name} - Price: ${this.Price}".Trim();
        }

        public virtual void Execute()
        {
            Console.WriteLine($"Executing {this.Name} service. Please wait {this.TimeToExecute} seconds.");
            Thread.Sleep(this.TimeToExecute * 1000);
            Console.WriteLine($"Service {this.Name} is executed!");
        }
    }
}
