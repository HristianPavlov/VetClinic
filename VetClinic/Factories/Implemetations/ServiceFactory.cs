namespace VetClinic.Factories.Implemetations
{
    using VetClinic.Data.Contracts;
    using VetClinic.Data.Models;
    using VetClinic.Factories.Contracts;

    public class ServiceFactory: Factory, IServiceFactory
    {
        public IService CreateService(string name, decimal price) => new Service(name, price, 5);
    }
}
