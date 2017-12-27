using System;
using System.Collections.Generic;
using VetClinic.Commands.Contracts;
using VetClinic.Data.Common.Enums;
using VetClinic.Data.Contracts;
using VetClinic.Data.Repositories;
using VetClinic.Factories.Contracts;

namespace VetClinic.Commands.Implementations
{
    public class AnimalCommand : IAnimalCommand
    {
        private readonly IAnimalFactory animalFactory;
        private readonly IAnimalRepository animalDb;

        public AnimalCommand(IAnimalFactory animalFactory, IAnimalRepository animalDb)
        {
            this.animalFactory = animalFactory;
            this.animalDb = animalDb;
        }

        public void CreateAnimal(IList<string> parameters)
        {
            IAnimal newAnimal;

            var userId = parameters[1];
            var animalType = parameters[2];
            var name = parameters[3];
            var gender = (AnimalGenderType)Enum.Parse(typeof(AnimalGenderType), parameters[4]);
            var breed = parameters[5];
            var age = int.Parse(parameters[6]);

            switch (animalType)
            {
                case "cat": newAnimal = this.animalFactory.CreateCat(name, gender, age); break;
                case "dog": newAnimal = this.animalFactory.CreateDog(name, gender, breed, age); break;
                case "hamster": newAnimal = this.animalFactory.CreateHammster(name, gender, age); break;
                default: throw new ArgumentException("No such animal can be serviced");
            }

            this.animalDb.AddAnimal(userId, newAnimal); // and to user

            Console.WriteLine($"{animalType} with name {name} successfully created");
        }

        public string ListAllPets()
        {
            throw new NotImplementedException();
        }

        public void RemoveAnimal(IList<string> parameters)
        {
            var animalId = parameters[1];

            var animal = this.animalDb.GetById(animalId);

            if (animal == null)
            {
                Console.WriteLine("Animal not found");
                return;
            }

            this.animalDb.RemoveAnimal(animalId);
            Console.WriteLine($"{animal.Type} with name {animal.Name} successfully removed from database");
        }
    }
}
