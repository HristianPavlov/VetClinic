using System;
using System.Text;
using VetClinic.Commands.Contracts;
using VetClinic.Data.Repositories.Contracts;
using VetClinic.Providers.Contracts;

namespace VetClinic.Core.Commands.Implementations.PetCommands
{
    public class ListPetsCommand : AbstractCommand, ICommand
    {
        private readonly IPetRepository pets;
        private readonly IWriter writer;

        public ListPetsCommand(IPetRepository pets, IWriter writer)
        {
            this.pets = pets ?? throw new ArgumentNullException("pets");
            this.writer = writer ?? throw new ArgumentNullException("pets");
        }

        public override void Execute()
        {
            var sb = new StringBuilder();

            foreach (var pet in pets.Pets)
            {
                sb.Append(pet.PrintInfo());
                sb.AppendLine($"Owner phone: {pet.OwnerPhoneNumber}");
                sb.AppendLine(" ========== ");
            }

            this.writer.WriteLine(sb.ToString());
        }
    }
}
