namespace VetClinic.Factories.Contracts
{
    using VetClinic.Data.Common.Enums;
    using VetClinic.Data.Contracts;

    public interface IPetFactory
    {
        IPet CreateDog(string name, AnimalGenderType gender, string breed, int age);

        IPet CreateCat(string name, AnimalGenderType gender, int age);

        IPet CreateHammster(string name, AnimalGenderType gender, int age);
    }
}
