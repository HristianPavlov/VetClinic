namespace VetClinic.Data.Repositories.Contracts
{
    using System.Collections.Generic;
    using VetClinic.Data.Contracts;

    public interface IServiceRepository
    {
        ICollection<IService> Services { get; }

        IService GetByName(string name);

        void CreateService(IService service);

        void DeleteService(string name);

        string ListServices();
    }
}
