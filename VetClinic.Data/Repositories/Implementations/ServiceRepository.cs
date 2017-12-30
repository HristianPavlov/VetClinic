namespace VetClinic.Data.Repositories.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using VetClinic.Data.Contracts;
    using VetClinic.Data.Repositories.Contracts;

    public class ServiceRepository : IServiceRepository
    {
        private readonly ICollection<IService> services;

        public ServiceRepository()
        {
            this.services = new List<IService>();
        }

        public ICollection<IService> Services => new List<IService>(this.services);

        public void CreateService(IService service)
        {
            var serviceExists = this.services.Any(s => s.Id == service.Id);

            if (serviceExists)
            {
                throw new Exception("This service already exists!");
            }

            this.services.Add(service);
        }

        public void DeleteService(string name)
        {
            var service = this.services.FirstOrDefault(s => s.Name == name);

            if (services == null)
            {
                throw new Exception("No such service found!");
            }

            this.services.Remove(service);
        }

        public bool ContainsService(string id) => this.services.Any(s => s.Id == id);

        public IService FindById(string id) => this.services.FirstOrDefault(s => s.Id == id);

        public IService GetByName(string name) => this.services.FirstOrDefault(s => s.Name == name);

        public string ListServices()
        {
            var sb = new StringBuilder();

            foreach (var service in services)
            {
                sb.AppendLine($"{service.PrintInfo()}");
            }

            return sb.ToString();
        }

    }
}
