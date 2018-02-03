namespace VetClinic.Commands.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using VetClinic.Commands.Contracts;
    using VetClinic.Data.Contracts;
    using VetClinic.Data.Repositories.Contracts;
    using VetClinic.Providers.Contracts;

    public class CashRegisterCommand : ICashRegisterCommand
    {
        private decimal balance;
        private readonly IServiceRepository services;
        private readonly IWriter writer;

        private readonly ICollection<IService> bookedServices;

        public CashRegisterCommand(IServiceRepository services, IWriter writer, decimal balance = 0.00m)
        {
            this.balance = balance;
            this.services = services;
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

            var service = this.services.Services.SingleOrDefault(s => s.Name == serviceName);

            if (service == null)
            {
                throw new ArgumentNullException($"Service {serviceName} does not exists yet. Please create service {serviceName} first");
            }

            this.bookedServices.Add(service);
            this.writer.WriteLine($"Service {serviceName} successfully booked!");
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

