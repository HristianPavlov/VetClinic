using System;
using System.Linq;
using VetClinic.Commands.Contracts;
using VetClinic.Data.Repositories.Contracts;
using VetClinic.Providers.Contracts;

namespace VetClinic.Core.Commands.Implementations.PetCommands
{
    public class DeletePetCommand : AbstractCommand, ICommand
    {
        private readonly IPetRepository pets;
        private readonly IUserRepository users;
        private readonly IWriter writer;

        public DeletePetCommand(IPetRepository pets, IUserRepository users, IWriter writer)
        {
            this.pets = pets ?? throw new ArgumentNullException("pets");
            this.users = users ?? throw new ArgumentNullException("users");
            this.writer = writer ?? throw new ArgumentNullException("writer");
        }

        public override void Execute()
        {
            DeletePet();
        }

        public void DeletePet()
        {
            var parameters = this.Parameters;
            var userPhone = parameters[1];

            var user = this.users.Users.SingleOrDefault(u => u.PhoneNumber == userPhone);
            if (user == null)
            {
                throw new ArgumentNullException("User not found");
            }

            var pet = this.pets.Pets.SingleOrDefault(a => a.Name == parameters[2]);
            if (pet == null)
            {
                throw new ArgumentNullException("Pet not found");
            }

            this.pets.DeletePet(userPhone, pet);
            user.RemovePet(pet);
            this.writer.WriteLine($"{pet.Type} with name {pet.Name} successfully removed from database");
        }
    }
}
