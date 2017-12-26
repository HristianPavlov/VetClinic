namespace VetClinic.Factories.Implemetations
{
    using System;
    using System.Linq;
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

        public IAnimal CreateAnimal(string name, AnimalGenderType gender, string breed, int age)
        {
            var animalTypes = Enum.GetValues(typeof(AnimalType)).Cast<AnimalType>().ToList();
            switch (animalTypes.ToString())
            {
                case "Dog": return new Dog(name, gender, breed, age);
                case "Cat": return new Cat(name, gender, age);
                case "Hamster": return new Hamster(name, gender, age);
                default: throw new ArgumentException("no such type of animal can be services");
            }
        }
    }
}
