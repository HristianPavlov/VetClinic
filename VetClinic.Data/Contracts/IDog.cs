namespace VetClinic.Data.Contracts
{
    public interface IDog: IPet
    {
        string Breed { get; }
    }
}
