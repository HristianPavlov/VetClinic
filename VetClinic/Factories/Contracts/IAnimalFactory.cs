namespace VetClinic.Factories.Contracts
{
    using VetClinic.Data.Common.Enums;
    using VetClinic.Data.Contracts;

    public interface IAnimalFactory
    {
        IAnimal CreateDog(string name, AnimalGenderType gender, string breed, int age);

        IAnimal CreateCat(string name, AnimalGenderType gender, int age);

        IAnimal CreateHammster(string name, AnimalGenderType gender, int age);
    }
}
