namespace VetClinic.Factories.Implemetations
{
    using VetClinic.Data.Common.Enums;
    using VetClinic.Data.Contracts;
    using VetClinic.Data.Models;
    using VetClinic.Factories.Contracts;

    public class AnimalFactory : IAnimalFactory
    {
        public IAnimal CreateDog(string name, AnimalGenderType gender, string breed, int age)
            => new Dog(name, gender, breed, age);

        public IAnimal CreateCat(string name, AnimalGenderType gender, int age)
            => new Cat(name, gender, age);

        public IAnimal CreateHammster(string name, AnimalGenderType gender, int age)
            => new Hamster(name, gender, age);
    }
}
