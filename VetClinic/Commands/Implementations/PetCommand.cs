namespace VetClinic.Commands.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using VetClinic.Commands.Contracts;
    using VetClinic.Common.ConsoleServices.Contracts;
    using VetClinic.Data.Contracts;
    using VetClinic.Data.Enums;
    using VetClinic.Data.Repositories.Contracts;
    using VetClinic.Factories.Contracts;

    public class PetCommand : Command, IPetCommand
    {
        private readonly IPetFactory animalFactory;
        private readonly IPetRepository animalDb;
        private readonly IWriter writer;

        public PetCommand(IPetFactory animalFactory, IPetRepository animalDb, IWriter writer)
        {
            this.animalFactory = animalFactory;
            this.animalDb = animalDb;
            this.writer = writer;
        }

        public void CreatePet(IList<string> parameters)
        {
            IPet newAnimal;

            var userPhone = parameters[1];
            var animalType = parameters[2].ToLower();
            var name = parameters[3];
            var gender = (AnimalGenderType)Enum.Parse(typeof(AnimalGenderType), parameters[4].ToLower());
            var age = int.Parse(parameters[5]);

            switch (animalType)
            {
                case "cat": newAnimal = this.animalFactory.CreateCat(name, gender, age); break;
                case "dog": var breed = parameters[6]; newAnimal = this.animalFactory.CreateDog(name, gender, breed, age); break;
                case "hamster": newAnimal = this.animalFactory.CreateHammster(name, gender, age); break;
                default: this.writer.WriteLine(($"No pet of kind {animalType} can be serviced in this clinic")); return;
            }

            newAnimal.OwnerPhoneNumber = userPhone;
            this.animalDb.CreatePet(userPhone, newAnimal);

            this.OnMessage($"{animalType} with name {name} successfully created");
        }

        public void DeletePet(IList<string> parameters)
        {
            var userPhone = parameters[1];
            var animalId = parameters[2];

            var pet = this.animalDb.GetById(animalId);
            
            if (pet == null)
            {
                throw new ArgumentException("Pet not found");
            }

            this.animalDb.DetelePet(userPhone, pet);
            this.OnMessage($"{pet.Type} with name {pet.Name} successfully removed from database");
        }

        public void ListPets()
        {
            var sb = new StringBuilder();

            foreach (var pet in animalDb.Pets)
            {
                sb.Append(pet.PrintInfo());
                sb.AppendLine($"Owner phone: {pet.OwnerPhoneNumber}");
                sb.AppendLine(" ========== ");
            }

            this.writer.WriteLine(sb.ToString());
        }

        public override void Create(IList<string> parameters)
        {
            CreatePet(parameters);
        }

        public override void Delete(IList<string> parameters)
        {
            DeletePet(parameters);
        }
    }
}
