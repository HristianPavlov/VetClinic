namespace VetClinic.Core.Services.Contracts
{
    public interface IService
    {
        string Id { get; }

        string Name { get; }

        decimal Price { get; }

        string Print();
    }
}
