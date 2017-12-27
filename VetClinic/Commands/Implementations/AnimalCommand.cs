namespace VetClinic.Commands.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using VetClinic.Commands.Contracts;
    using VetClinic.Data.Common.Enums;
    using VetClinic.Data.Contracts;
    using VetClinic.Data.Repositories;
    using VetClinic.Factories.Contracts;

    public class AnimalCommand : AbstractCommand, IAnimalCommand
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

            var userPhone = parameters[1];
            var animalType = parameters[2];
            var name = parameters[3];
            var gender = (AnimalGenderType)Enum.Parse(typeof(AnimalGenderType), parameters[4]);
            var age = int.Parse(parameters[5]);

            switch (animalType)
            {
                case "cat": newAnimal = this.animalFactory.CreateCat(name, gender, age); break;
                case "dog": var breed = parameters[6]; newAnimal = this.animalFactory.CreateDog(name, gender, breed, age); break;
                case "hamster": newAnimal = this.animalFactory.CreateHammster(name, gender, age); break;
                default: Console.WriteLine(($"No animal of kind {animalType} can be serviced in this clinic")); return;
            }

            newAnimal.OwnerPhoneNumber = userPhone;
            this.animalDb.CreateAnimal(userPhone, newAnimal);

            this.onMessage($"{animalType} with name {name} successfully created");
        }

        public void ListPets()
        {
            var sb = new StringBuilder();

            foreach (var pet in animalDb.Animals)
            {
                sb.Append(pet.PrintInfo());
                sb.AppendLine($"Owner: {pet.OwnerPhoneNumber}");
            }

            Console.WriteLine(sb.ToString());
        }

        public void DeleteAnimal(IList<string> parameters)
        {
            var userPhoneNumber = parameters[1];
            var animalId = parameters[2];

            var animal = this.animalDb.GetById(animalId);
            
            if (animal == null)
            {
                Console.WriteLine("Animal not found");
                return;
            }

            this.animalDb.DeteleAnimal(animal, userPhoneNumber);
            this.onMessage($"{animal.Type} with name {animal.Name} successfully removed from database");
        }
    }
}
