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

        public ICollection<IService> Services => this.services;//!!!!!

        public void CreateService(IService service)
        {
            if(service==null)
            {
                throw new ArgumentNullException();
            }
            var serviceExists = this.services.Any(s => s.Id == service.Id);

            if (serviceExists)
            {
                throw new Exception("This service already exists!");
            }

            this.Services.Add(service);
        }

        public void DeleteService(string name)
        {
            var service = this.services.SingleOrDefault(s => s.Name == name);

            if (services == null)
            {
                throw new Exception("No such service found!");
            }

            this.Services.Remove(service);
        }

        public bool ContainsService(string id) => this.Services.Any(s => s.Id == id);

        public IService FindById(string id) => this.Services.SingleOrDefault(s => s.Id == id);

        public IService GetByName(string name) => this.Services.SingleOrDefault(s => s.Name == name);

        public string ListServices()
        {
            var sb = new StringBuilder();

            foreach (var service in this.Services)
            {
                sb.AppendLine($"{service.PrintInfo()}");
            }

            return sb.ToString();
        }

    }
}
