using System;
using System.Linq;
using VetClinic.Commands.Contracts;
using VetClinic.Data.Contracts;
using VetClinic.Data.Enums;
using VetClinic.Data.Repositories.Contracts;
using VetClinic.Factories.Contracts;
using VetClinic.Providers.Contracts;

namespace VetClinic.Core.Commands.Implementations.PetCommands
{
    public class CreatePetCommand : AbstractCommand, ICommand
    {
        private readonly IPetFactory animalFactory;
        private readonly IUserRepository users;
        private readonly IPetRepository pets;
        private readonly IWriter writer;

        public CreatePetCommand(IPetFactory animalFactory, IUserRepository users, IPetRepository pets, IWriter writer)
        {
            this.animalFactory = animalFactory ?? throw new ArgumentNullException("animalFactory");
            this.pets = pets ?? throw new ArgumentNullException("pets");
            this.users = users ?? throw new ArgumentNullException("users");
            this.writer = writer ?? throw new ArgumentNullException("pets");
        }

        public override void Execute()
        {
            var parameters = this.Parameters;
            IPet newAnimal;

            var userPhone = parameters[1];
            var animalType = parameters[2].ToLower();
            var name = parameters[3];
            var gender = (AnimalGenderType)Enum.Parse(typeof(AnimalGenderType), parameters[4].ToLower());
            var age = int.Parse(parameters[5]);

            var user = this.users.Users.SingleOrDefault(u => u.PhoneNumber == userPhone);
            if (user == null)
            {
                throw new ArgumentNullException("User was not found");
            }

            switch (animalType)
            {
                case "cat":
                    newAnimal = this.animalFactory.CreateCat(name, gender, age);
                    break;

                case "dog":
                    var breed = parameters[6];
                    newAnimal = this.animalFactory.CreateDog(name, gender, breed, age);
                    break;

                case "hamster":
                    newAnimal = this.animalFactory.CreateHamster(name, gender, age);
                    break;

                default:
                    this.writer.WriteLine(($"No pet of kind {animalType} can be serviced in this clinic"));
                    return;
            }

            newAnimal.OwnerPhoneNumber = userPhone;
            this.pets.CreatePet(userPhone, newAnimal);

            if (newAnimal == null)
            {
                throw new ArgumentNullException("Pet was not found");
            }
            user.AddPet(newAnimal);

            this.writer.WriteLine($"{animalType} with name {name} successfully created");
        }
    }
}
