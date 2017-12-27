namespace VetClinic.Core.ClinicServices.Contracts
{
    public interface IService
    {
        string Id { get; }

        string Name { get; }

        decimal Price { get; }

        int TimeToExecute { get; }

        string Print();

        void Execute();
    }
}
