﻿namespace VetClinic.Commands.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using VetClinic.Commands.Contracts;
    using VetClinic.Data.Contracts;
    using VetClinic.Data.Repositories.Contracts;
    using VetClinic.Factories.Contracts;
    using VetClinic.Providers.Contracts;

    public class ServiceCommand : IServiceCommand
    {
        private readonly IServiceFactory serviceFactory;
        private readonly IServiceRepository services;
        private readonly IUserRepository users;
        private readonly IWriter writer;

        public ServiceCommand(IServiceFactory serviceFactory, IServiceRepository services, IUserRepository users, IWriter writer)
        {
            this.serviceFactory = serviceFactory;
            this.services = services;
            this.users = users;
            this.writer = writer;
        }

        public void CreateService(IList<string> parameters)
        {
            var name = parameters[1];

            var service = this.services.Services.SingleOrDefault(p => p.Name == name);
            if (service != default(IService))
            {
                throw new ArgumentException("This service already exists!");
            }

            var newService = this.serviceFactory.CreateService(name, decimal.Parse(parameters[2]));

            this.services.CreateService(newService);

            this.writer.WriteLine($"Service {name} successfully created");
        }

        public void DeleteService(IList<string> parameters)
        {
            var name = parameters[1];

            var service = this.services.Services.SingleOrDefault(p => p.Name == name);

            if (service == null)
            {
                throw new ArgumentNullException("Service not found");
            }

            this.services.DeleteService(name);
            this.writer.WriteLine($"Service {name} successfully deleted");
        }

        public void ListServices(IList<string> parameters)
        {
            if (this.services.Services.Count == 0)
            {
                throw new ArgumentException("No users registered");
            }

            var sb = new StringBuilder();

            sb.AppendLine("All services:");

            foreach (var service in this.services.Services)
            {
                sb.AppendLine(service.PrintInfo());
            }

            this.writer.WriteLine(sb.ToString());
        }

        public void PerformService(IList<string> parameters)
        {
            var serviceName = parameters[1];
            var userPhone = parameters[2];
            var animalName = parameters[3];

            var service = this.services.Services.SingleOrDefault(s => s.Name == serviceName);

            if (service == null)
            {
                throw new ArgumentNullException($"{serviceName} is not found.");
            }

            var user = this.users.Users.SingleOrDefault(u => u.PhoneNumber == userPhone);

            if (user == null)
            {
                throw new ArgumentNullException($"{user.FirstName} {user.LastName} does not exists");
            }

            IPet pet = user.Pets.SingleOrDefault((p => p.Name == animalName));

            if (pet == null)
            {
                throw new ArgumentNullException($"{user.FirstName} {user.LastName} does not have an pet with name: {animalName} registered. Please register {animalName} for customer {user.FirstName} {user.LastName} first");
            }

            pet.AddServices(service);
            user.Bill += service.Price;

            service.Execute();
            this.writer.WriteLine($"Service {service.Name} completed!");
        }

        public decimal CloseAccount(IList<string> parameters)
        {
            var userPhone = parameters[1];
            var user = this.users.Users.SingleOrDefault(u => u.PhoneNumber == userPhone);

            decimal amount = user.Bill;
            user.Bill = 0;

            return amount;
        }


        public void BookService(IList<string> parameters)
        {
            var name = parameters[1];

            var service = this.services.Services.SingleOrDefault(p => p.Name == name);

            if (service == null)
            {
                throw new ArgumentNullException("Service not found");
            }
            this.writer.WriteLine($"Service {service.Name} completed!");
        }
    }
}
