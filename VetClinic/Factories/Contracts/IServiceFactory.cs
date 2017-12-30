namespace VetClinic.Factories.Contracts
{
    using VetClinic.Data.Contracts;

    public interface IServiceFactory
    {
        IService CreateService(string name, decimal price);
    }
}
