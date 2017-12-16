namespace VetClinic.Data.Contracts
{
    public interface IIdentifiable
    {
        string ID { get; }

        string GenerateID();
    }
}
