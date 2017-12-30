namespace VetClinic.Commands.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using VetClinic.Commands.Contracts;
    using VetClinic.Common;
    using VetClinic.Data.Contracts;
    using VetClinic.Data.Repositories.Contracts;
    using VetClinic.Factories.Contracts;

    public class ServiceCommand : VetClinicEventHandler, IServiceCommand
    {
        private readonly IServiceFactory serviceFactory;
        private readonly IServiceRepository serviceDb;
        private readonly IUserRepository userDb;

        public ServiceCommand(IServiceFactory serviceFactory, IServiceRepository serviceDb, IUserRepository userDb)
        {
            this.serviceFactory = serviceFactory;
            this.serviceDb = serviceDb;
            this.userDb = userDb;
        }

        public void CreateService(IList<string> parameters)
        {
            var name = parameters[1];
            var price = Decimal.Parse(parameters[2]);

            var newService = this.serviceFactory.CreateService(name, price);

            this.serviceDb.CreateService(newService);
            this.OnMessage($"Service {name} successfully created");
        }

        public void DeleteService(IList<string> parameters)
        {
            var name = parameters[1];

            var service = this.serviceDb.Services.FirstOrDefault(p => p.Name == name);

            if (service == null)
            {
                throw new ArgumentException("Service not found");
            }

            this.serviceDb.DeleteService(name);
            this.OnMessage($"Service {name} successfully deleted");
        }

        public void ListServices(IList<string> parameters)
        {
            if (this.serviceDb.Services.Count == 0)
            {
                throw new ArgumentException("No users registered");
            }

            var sb = new StringBuilder();

            sb.AppendLine("All services:");

            foreach (var service in this.serviceDb.Services)
            {
                sb.AppendLine(service.PrintInfo());
            }

            Console.WriteLine(sb.ToString());
        }

        public void PerformService(IList<string> parameters)
        {
            var serviceName = parameters[1];
            var userPhone = parameters[2];
            var animalName = parameters[3];

            var service = this.serviceDb.Services.FirstOrDefault(s => s.Name == serviceName);

            if (service == null)
            {
                throw new ArgumentException($"{serviceName} is not found.");
            }

            var user = this.userDb.Users.FirstOrDefault(u => u.PhoneNumber == userPhone);

            if (user == null)
            {
                throw new ArgumentException($"{user.FirstName} {user.LastName} does not exists");
            }

            IAnimal animal = user.Pets.FirstOrDefault((p => p.Name == animalName));

            if (animal == null)
            {
                throw new ArgumentException($"{user.FirstName} {user.LastName} does not have an animal with name: {animalName} registered. Please register {animalName} for customer {user.FirstName} {user.LastName} first");
            }

            animal.addServices(service);
            user.Bill += service.Price;

            service.Execute();
            this.OnMessage($"Service {service.Name} is executed!");
        }

        public decimal closeAccount(IList<string> parameters)
        {
            var userPhone = parameters[1];
           var user = this.userDb.Users.FirstOrDefault(u => u.PhoneNumber == userPhone);

            decimal amount = user.Bill;
            user.Bill = 0;

            return amount;
        }


        public void BookService(IList<string> parameters)
        {
            var name = parameters[1];

            var service = this.serviceDb.Services.FirstOrDefault(p => p.Name == name);

            if (service == null)
            {
                throw new CustomException("Service not found");
            }
            this.OnMessage($"Service {service.Name} is executed!");
        }
    }
}
