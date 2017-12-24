namespace VetClinic.Data.Contracts
{
    public interface IIdentifiable
    {
        string Id { get; }

        string GenerateId();
    }
}
