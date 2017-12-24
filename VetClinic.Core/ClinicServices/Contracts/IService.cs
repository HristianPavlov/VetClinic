namespace VetClinic.Core.ClinicServices.Contracts
{
    public interface IService
    {
        string Id { get; }

        string Name { get; }

        decimal Price { get; }

        string Print();
    }
}
