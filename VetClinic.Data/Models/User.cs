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
        static int ownersCount = 0;

        private decimal wallet;
        private readonly List<IAnimal> pets;

        public User(string firstName, string lastName, string phoneNumber, string email)
            : base(firstName, lastName, phoneNumber, email)
        {
            this.pets = new List<IAnimal>();
        }

        public ICollection<IAnimal> Pets => new List<IAnimal>(this.pets);

        public decimal Wallet
        {
            get => this.wallet;

            private set
            {
                Guard.WhenArgument(wallet, "Wallet canno be less than zero").IsLessThan(0).Throw();
                this.wallet = value;
            }
        }

        public void AddPet(IAnimal pet)
        {
            Guard.WhenArgument(pet, "Pet is null").IsNull().Throw();
            var petFound = this.pets.FirstOrDefault(x => x.Id == pet.Id);

            if (pet == null)
            {
                throw new ArgumentException("this pet already exists in database");
            }

            this.pets.Add(petFound);
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

        public void PayForServices(decimal cost)
        {
            Guard.WhenArgument(wallet, "Not enough money").IsLessThan(cost).Throw();
            this.wallet -= cost;
        }

        public void BuyMedicine(decimal cost)
        {
            Guard.WhenArgument(wallet, "Not enough money").IsLessThan(cost).Throw();
            this.wallet -= cost;
        }

        public void ListAllPets()
        {
            if (!this.pets.Any())
            {
                Console.WriteLine("This client has no pets.");
                return;
            }

            var sb = new StringBuilder();

            foreach (var pet in this.Pets)
            {
                sb.AppendLine($"Name: {pet.Name}");
                sb.AppendLine($"Gender: {pet.Gender}");
                sb.AppendLine($"Age: {pet.Age}");
                sb.AppendLine($"Type: {pet.Type}");
                sb.AppendLine($"Onwer: {pet.Owner}");
            }

            Console.WriteLine(sb.ToString());
        }

        public override string PrintInfo() => base.PrintInfo();


        // -------------- Obsolete ----------------
        public string GenerateId()
        {
            StringBuilder sb = new StringBuilder();

            ownersCount++;
            sb.Append('O');
            sb.Append(ownersCount);

            return sb.ToString();
        }

        public static int gettingStaticID()
        {
            //StringBuilder sb = new StringBuilder();

            //ownersCount++;
            // sb.Append('O');
            // sb.Append(ownersCount+1);

            return ownersCount;
        }
    }
}



