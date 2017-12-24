namespace VetClinic.Core.ClinicServices.Contracts
{
    using System.Collections.Generic;

    public interface IClinicServicesListing
    {
        ICollection<IService> Services { get; }

        string ListAllServices();

        void AddServices(IService service);

        void RemoveServices(IService service);

        void FindById(string id);

        bool ContainsService(string id);
    }
}
