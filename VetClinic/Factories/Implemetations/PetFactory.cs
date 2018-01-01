namespace VetClinic.Factories.Implemetations
{
    using VetClinic.Data.Contracts;
    using VetClinic.Data.Enums;
    using VetClinic.Data.Models;
    using VetClinic.Factories.Contracts;

    public class PetFactory : Factory, IPetFactory
    {
        public IPet CreateDog(string name, AnimalGenderType gender, string breed, int age)
            => new Dog(name, gender, breed, age);

        public IPet CreateCat(string name, AnimalGenderType gender, int age)
            => new Cat(name, gender, age);

        public IPet CreateHammster(string name, AnimalGenderType gender, int age)
            => new Hamster(name, gender, age);
    }
}
