namespace VetClinic.Commands.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using VetClinic.Commands.Contracts;
    using VetClinic.Common;
    using VetClinic.Common.ConsoleServices.Contracts;
    using VetClinic.Data.Contracts;
    using VetClinic.Data.Repositories.Contracts;

    public class CashRegisterCommand : Command, ICashRegisterCommand
    {
        private decimal balance;
        private readonly IServiceRepository serviceDb;
        private readonly IWriter writer;

        private readonly ICollection<IService> bookedServices;

        public CashRegisterCommand(IServiceRepository serviceDb, IWriter writer, decimal balance = 0.00m)
        {
            this.balance = balance;
            this.serviceDb = serviceDb;
            this.writer = writer;
            bookedServices = new List<IService>();
        }

        public decimal Balance { get; private set; }

        public ICollection<IService> BookedServices => new List<IService>(this.bookedServices);

        public void UpdateBalance(decimal amount)
        {
            this.Balance += amount;
        }

        public void AddBookedService(IList<string> parameters)
        {
            var serviceName = parameters[1];

            var service = this.serviceDb.Services.FirstOrDefault(s => s.Name == serviceName);

            if (service == null)
            {
                throw new ArgumentException($"Service {serviceName} does not exists yet. Please create service {serviceName} first");
            }

            this.bookedServices.Add(service);
            this.OnMessage($"Service {serviceName} successfully booked!");
        }


        public void PrintBookedServices()
        {
            this.writer.WriteLine(("History for booked service:"));

            foreach (var service in bookedServices)
            {
                this.writer.WriteLine($"{service.Name} - ${service.Price}");
            }
        }

        public void PrintBalance()
        {
            this.writer.WriteLine(string.Format("{0:F2}", this.Balance));
        }
    }
}

