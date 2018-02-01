namespace VetClinic.Data.Models
{
    using Bytes2you.Validation;
    using System;
    using System.Text;
    using System.Threading;
    using VetClinic.Data.Contracts;

    public class Service : IService
    {
        private static int count = 1;

        private readonly decimal price;
        private readonly string name;
        private readonly string id;
        private readonly int timeToExecute;

        public Service(string name, int timeToExecute = 1)
        {
            Guard.WhenArgument(name, "Service name cannot be null!").IsNullOrEmpty().Throw();
            Guard.WhenArgument(timeToExecute, "Time must be positive!").IsLessThan(0).Throw();
            this.id = (count++).ToString();
            this.name = name;
            this.timeToExecute = timeToExecute;
        }

        public Service(string name, decimal price, int timeToExecute)
            : this(name, timeToExecute)
        {
            Guard.WhenArgument(price, "Price must be positive!").IsLessThan(1).Throw();
            this.price = price;
        }

        public string Id => this.id;

        public string Name => this.name;

        public decimal Price
        {
            get => this.price;
        }

        public int TimeToExecute => this.timeToExecute;

        public virtual string PrintInfo()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"Name: {this.Name}");
            sb.AppendLine($"Id: {this.Id}");
            sb.AppendLine($"Price: {this.Price}");

            return sb.ToString();
        }

        public virtual void Execute()
        {
            Console.WriteLine($"Executing {this.Name} service. Please wait {this.TimeToExecute} seconds.");
            Thread.Sleep(this.TimeToExecute * 1000);
        }

    }
}
