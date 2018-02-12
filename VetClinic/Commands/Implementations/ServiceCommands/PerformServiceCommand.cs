using System;
using System.Linq;
using VetClinic.Commands.Contracts;
using VetClinic.Data.Contracts;
using VetClinic.Data.Repositories.Contracts;
using VetClinic.Providers.Contracts;

namespace VetClinic.Core.Commands.Implementations.ServiceCommands
{
    public class PerformServiceCommand : AbstractCommand, ICommand
    {
        private readonly IServiceRepository services;
        private readonly IUserRepository users;
        private readonly IWriter writer;

        public PerformServiceCommand(IServiceRepository services, IUserRepository users, IWriter writer)
        {
            this.services = services ?? throw new ArgumentNullException("serviceFactory");
            this.users = users ?? throw new ArgumentNullException("serviceFactory");
            this.writer = writer ?? throw new ArgumentNullException("serviceFactory");
        }

        public override void Execute()
        {
            PerformService();
        }

        private void PerformService()
        {
            var parameters = this.Parameters;
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
    }
}
