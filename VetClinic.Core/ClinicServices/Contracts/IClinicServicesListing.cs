namespace VetClinic.Core.ClinicServices.Contracts
{
    using System.Collections.Generic;
    using VetClinic.Data.Contracts;

    public interface IClinicServicesListing
    {
        ICollection<IService> Services { get; }

        string ListAllServices();

        // TODO remove irrelevent methods

        //void AddServices(IService service);

        //void RemoveServices(IService service);

        IService FindById(string id);

        //bool ContainsService(string id);
    }
}
