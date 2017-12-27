namespace VetClinic.Core.ClinicServices.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using VetClinic.Core.ClinicServices.Contracts;

    public class ClinicServicesListing: IClinicServicesListing
    {
        private static readonly ICollection<IService> services = new List<IService>
        {
            { new Service("Healing", 19.90m, 5) },
            { new Service("Vaccination", 8.90m, 4) },
            { new Service("Anti parasite treatment", 6.50m, 3) },
            { new Service("Grooming", 25.00m, 6) },
            // TODO - implement Buy Products service ( 1 second )
        };

        public ICollection<IService> Services => services;

        // TODO remove irrelevent methods

        //public void AddServices(IService service)
        //{
        //    if (service == null)
        //    {
        //        throw new Exception("No such service found");
        //    }

        //    if (services.Any(s => s.Id == service.Id) == true)
        //    {
        //        throw new Exception("This servoce already exists!");
        //    }

        //    this.services.Add(service);
        //}

        //public void RemoveServices(IService service)
        //{
        //    if (services.Any(s => s.Id == service.Id) == false)
        //    {
        //        throw new Exception("No such service found!");
        //    }

        //    this.services.Remove(service);
        //}

        //public bool ContainsService(string id)
        //{
        //    return services.Any(s => s.Id == id);
        //}

        //public void FindById(string id)
        //{
        //    services.FirstOrDefault(s => s.Id == id);
        //}

        public string ListAllServices()
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
