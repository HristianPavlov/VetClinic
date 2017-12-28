namespace VetClinic.Data.Models
{
    using Abstractions;
    using Bytes2you.Validation;
    using Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class User : Person, IUser
    {
        private decimal total;
        private readonly List<IAnimal> pets;
        //private readonly List<IService> usedServices;   // TODO fix using/reference

        public User(string firstName, string lastName, string phoneNumber, string email)
            : base(firstName, lastName, phoneNumber, email)
        {
            this.pets = new List<IAnimal>();
        }

        public ICollection<IAnimal> Pets => new List<IAnimal>(this.pets);

        public decimal Total
        {
            get => this.total;

            private set
            {
                Guard.WhenArgument(total, "total canno be less than zero").IsLessThan(0).Throw();
                this.total = value;
            }
        }

        // TODO

        //public IList<IService> UsedServices
        //{
        //    get => this.usedServices;

        //    private set
        //    {
        //        this.usedServices = value;
        //    }
        //}

        public void AddPet(IAnimal pet)
        {
            Guard.WhenArgument(pet, "Pet is null").IsNull().Throw();
            var petFound = this.pets.FirstOrDefault(p => p.Id == pet.Id);

            if (petFound != null)
            {
                Console.WriteLine(("this pet already exists in database"));
                return;
            }

            this.pets.Add(pet);
        }

        public void RemovePet(IAnimal pet)
        {
            Guard.WhenArgument(pet, "Pet is null").IsNull().Throw();
            var petFound = this.pets.FirstOrDefault(p => p.Id == pet.Id);
            Guard.WhenArgument(petFound, "PetFound").IsNull().Throw();

            if (petFound != null)
            {
                this.pets.Remove(petFound);
            }
        }

        public void PayForServices()
        {
            Guard.WhenArgument(this.Total, "Noting to pay for!").IsEqual(0).Throw();
            //  TODO :
            // CashRegister.Monay += total;
            // CashRegister.AddServicesToList(this.UsedServices);
            // this.UsedServices.Clear;
            this.total = 0m;
        }

        public string ListUserPets()
        {
            if (!this.pets.Any())
            {
                return $"Pets: {this.FirstName} {this.LastName} has no pets registered yet.";
            }

            var sb = new StringBuilder();

            foreach (var pet in this.pets) // TODO null
            {
                sb.AppendLine($"Name: {pet.Name}");
                sb.AppendLine($"Gender: {pet.Gender}");
                sb.AppendLine($"Age: {pet.Age}");
                sb.AppendLine($"Type: {pet.Type}");
                sb.AppendLine($"Owner: {pet.OwnerPhoneNumber}");
            }

           return sb.ToString();
        }

        public override string PrintInfo()
        {
            var sb = new StringBuilder();
            sb.Append(base.PrintInfo());
            sb.AppendLine(ListUserPets());
            return sb.ToString();
        }
    }
}



