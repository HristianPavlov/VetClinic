namespace VetClinic.Factories.Contracts
{
    using VetClinic.Data.Contracts;
    using VetClinic.Data.Enums;

    public interface IPetFactory
    {
        IPet CreateDog(string name, AnimalGenderType gender, string breed, int age);

        IPet CreateCat(string name, AnimalGenderType gender, int age);

        IPet CreateHamster(string name, AnimalGenderType gender, int age);
    }
}
