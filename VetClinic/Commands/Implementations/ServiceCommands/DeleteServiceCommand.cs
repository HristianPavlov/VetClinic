using System;
using System.Linq;
using VetClinic.Commands.Contracts;
using VetClinic.Data.Repositories.Contracts;
using VetClinic.Providers.Contracts;

namespace VetClinic.Core.Commands.Implementations.ServiceCommands
{
    public class DeleteServiceCommand : AbstractCommand, ICommand
    {
        private readonly IServiceRepository services;
        private readonly IWriter writer;

        public DeleteServiceCommand(IServiceRepository services, IWriter writer)
        {
            this.services = services ?? throw new ArgumentNullException("serviceFactory");
            this.writer = writer ?? throw new ArgumentNullException("serviceFactory");
        }

        public override void Execute()
        {
            DeleteService();
        }

        private void DeleteService()
        {
            var parameters = this.Parameters;
            var name = parameters[1];
            var service = this.services.Services.SingleOrDefault(p => p.Name == name);

            if (service == null)
            {
                throw new ArgumentNullException("Service not found");
            }

            this.services.DeleteService(name);
            this.writer.WriteLine($"Service {name} successfully deleted");
        }
    }
}
