namespace VetClinic.Data.Models
{
    using Abstractions;
    using Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class User : Person, IUser
    {
        private readonly List<IPet> pets;
        private decimal bill;

        public User(string firstName, string lastName, string phoneNumber, string email)
            : base(firstName, lastName, phoneNumber, email)
        {
            this.pets = new List<IPet>();
        }

        public ICollection<IPet> Pets => new List<IPet>(this.pets);

        public decimal Bill { get => bill; set => bill = value; }

        public void AddPet(IPet pet)
        {
            var petFound = this.pets.SingleOrDefault(p => p.Id == pet.Id);

            if (petFound != null)
            {
                throw new ArgumentNullException($"this {pet.Name} already exists in database");
            }

            this.pets.Add(pet);
        }

        public void RemovePet(IPet pet)
        {
            var petFound = this.pets.SingleOrDefault(p => p.Id == pet.Id);

            if (petFound != null)
            {
                this.pets.Remove(petFound);
            }
        }

        public string ListUserPets()
        {
            if (!this.pets.Any())
            {
                return $"Pets: {this.FirstName} {this.LastName} has no pets registered yet.";
            }

            var sb = new StringBuilder();

            foreach (var pet in this.pets)
            {
                sb.AppendLine(pet.PrintInfo().Trim());
            }

            return sb.ToString();
        }

        public override string PrintInfo()
        {
            var sb = new StringBuilder();
            sb.AppendLine(base.PrintInfo().Trim());
            sb.AppendLine(ListUserPets().Trim());
            return sb.ToString();
        }
    }
}



