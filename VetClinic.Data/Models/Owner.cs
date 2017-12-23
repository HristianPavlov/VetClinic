namespace VetClinic.Data.Models
{
    using Bytes2you.Validation;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Contracts;
    using Abstractions;

    public class Owner : Human, IIdentifiable
    {
        private string id;
        private ICollection<Animal> pets;
        static int ownersCount = 0;


        public Owner(string firstName, string lastName, string phoneNumber)
            : base(firstName, lastName, phoneNumber)
        {
            this.pets = new List<Animal>();
            this.ID = GenerateID();
        }

        public ICollection<Animal> Pets { get => this.pets; }  // List copy To Do ! 

        public string ID { get => this.id; private set => this.id = value; }

        public string GenerateID()
        {
            StringBuilder sb = new StringBuilder();

            ownersCount++;
            sb.Append('O');
            sb.Append(ownersCount);

            return sb.ToString();
        }


        public void PayForServices()
        {
            throw new NotImplementedException(); // To Do
        }


        public void AddPet(Animal pet)
        {
            // check if animal is already created
            // if not, create new animal
            Guard.WhenArgument(pet, "Pet is null").IsNull().Throw();
            this.pets.Add(pet);
        }

        public void RemovePet(IAnimal pet)
        {
            Guard.WhenArgument(pet, "Pet is null").IsNull().Throw();
            Animal petFound = this.pets.FirstOrDefault(x => x.ID == pet.ID);
            Guard.WhenArgument(petFound, "PetFound").IsNull().Throw();

            if (petFound != null)
            {
                this.pets.Remove(petFound);
            }
        }

        public void RemovePet(string iD)
        {
            Guard.WhenArgument(iD, "ID is null").IsNull().Throw();
            Animal petFound = this.pets.FirstOrDefault(x => x.ID == iD);
            Guard.WhenArgument(petFound, "PetFound").IsNull().Throw();

            if (petFound != null)
            {
                this.pets.Remove(petFound);
            }
        }


        public void PrintPets()
        {
            if (!this.pets.Any())
            {
                Console.WriteLine("This client has no pets.");
                return;
            }

            StringBuilder strBuilder = new StringBuilder();
            strBuilder.AppendLine($"#Owner: {this.FirstName} {this.LastName}, ID: {this.ID}");

            foreach (var pet in this.Pets)
            {
                strBuilder.Append(pet.PrintInfo());
                strBuilder.AppendLine("=====");
            }

            Console.WriteLine(strBuilder.ToString().TrimEnd());
        }
        //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
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



