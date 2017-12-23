namespace VetClinic.Core.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using VetClinic.Core.Services.Contracts;

    public class ClinicServices: IClinicServices
    {
        private readonly ICollection<IService> services;
    
        public ClinicServices()
        {
            this.services = new List<IService>();

        }

        public ICollection<IService> Services => new List<IService>();

        public void AddServices(IService service)
        {
            if (service == null)
            {
                throw new Exception("No such service found");
            }

            this.services.Add(service);
        }

        public void RemoveServices(IService service)
        {
            if (service == null)
            {
                throw new Exception("No such service found");
            }

            this.services.Remove(service);
        }

        public bool ContainsService(string id)
        {
            return this.services.Any(s => s.Id == id);
        }

        public void FindById(string id)
        {
            this.services.FirstOrDefault(s => s.Id == id);
        }

        public string ListAllServices()
        {
            var sb = new StringBuilder();

            foreach (var service in this.services)
            {
                sb.AppendLine($"{service.Print()}");
            }

            return sb.ToString();
        }
    }
}
