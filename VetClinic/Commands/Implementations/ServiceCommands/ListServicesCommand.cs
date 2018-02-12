using System;
using System.Text;
using VetClinic.Commands.Contracts;
using VetClinic.Data.Repositories.Contracts;
using VetClinic.Providers.Contracts;

namespace VetClinic.Core.Commands.Implementations.ServiceCommands
{
    public class ListServicesCommand : AbstractCommand, ICommand
    {
        private readonly IServiceRepository services;
        private readonly IWriter writer;

        public ListServicesCommand(IServiceRepository services, IWriter writer)
        {
            this.services = services ?? throw new ArgumentNullException("serviceFactory");
            this.writer = writer ?? throw new ArgumentNullException("serviceFactory");
        }

        public override void Execute()
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
    }
}
