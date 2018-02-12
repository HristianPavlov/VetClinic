using System;
using System.Linq;
using VetClinic.Commands.Contracts;
using VetClinic.Data.Contracts;
using VetClinic.Data.Repositories.Contracts;
using VetClinic.Factories.Contracts;
using VetClinic.Providers.Contracts;

namespace VetClinic.Core.Commands.Implementations.ServiceCommands
{
    public class CreateServiceCommand : AbstractCommand, ICommand
    {
        private readonly IServiceFactory serviceFactory;
        private readonly IServiceRepository services;
        private readonly IWriter writer;

        public CreateServiceCommand(IServiceFactory serviceFactory, IServiceRepository services, IWriter writer)
        {
            this.serviceFactory = serviceFactory ?? throw new ArgumentNullException("serviceFactory");
            this.services = services ?? throw new ArgumentNullException("serviceFactory");
            this.writer = writer ?? throw new ArgumentNullException("serviceFactory");
        }

        public override void Execute()
        {
            CreateService();
        }

        private void CreateService()
        {
            var parameters = this.Parameters;
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
    }
}
