namespace VetClinic.Data.Contracts
{
    public interface IDog: IAnimal
    {
        string Breed { get; }
    }
}
