namespace VetClinic.Data.Contracts
{
    public interface IService
    {
        string Id { get; }

        string Name { get; }

        decimal Price { get; }

        int TimeToExecute { get; }

        string PrintInfo();

        void Execute();
    }
}
