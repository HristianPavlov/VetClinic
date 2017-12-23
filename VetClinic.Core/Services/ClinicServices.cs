namespace VetClinic.Core.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using VetClinic.Core.Services.Contracts;

    public class ClinicServices: IClinicServices
    {
        private static ICollection<IService> services;
    
        public ClinicServices()
        {
            services = new List<IService>();

            services.Add(new Service("Healing", 19.90m));
            services.Add(new Service("Vaccination", 8.90m));
            services.Add(new Service("Anti parasite treatment", 6.50m));
            services.Add(new Service("Grooming", 25.00m));

            services.Add(new BuyProductService()); // implement buy products service !!!

        }

        //public ICollection<IService> Services => new List<IService>();

        public static ICollection<IService> Services { get;}

        public void AddServices(IService service)
        {
            services.Add(service);
        }

        public void RemoveServices(IService service)
        {

            if (!services.Any(s => s.Id == service.Id))
            {
                throw new Exception("No such service found!");
            }

            services.Remove(service);
        }

        public bool ContainsService(string id) // necessary ???
        {
            return services.Any(s => s.Id == id);
        }

        public void FindById(string id)
        {
            services.FirstOrDefault(s => s.Id == id);
        }

        public static string ListAllServices()
        {
            var sb = new StringBuilder();

            foreach (var service in services)
            {
                sb.AppendLine($"{service.Print()}");
            }

            return sb.ToString();
        }
    }
}
