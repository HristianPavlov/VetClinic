namespace VetClinic.Data.Models.Abstractions
{
    using Bytes2you.Validation;
    using Common.Enums;
    using Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public abstract class Animal : IIdentifiable,IAnimal
    {
        private string name;
        // private Owner owner;
        private GenderType gender;        
        private string id;
        private AnimalType type;

        private ICollection<IDiagnosis> diagnosises;  // ===== TO DO

        public Animal(string name, GenderType gender, AnimalType type)
        {
            Guard.WhenArgument(name, "Invalid name").IsNull().Throw();
            Guard.WhenArgument(name.Length, "Invalid name length").IsLessThan(2).IsGreaterThan(15).Throw();

            this.Name = name;
            //  this.Owner = owner;
            this.Gender = gender;
            this.diagnosises = new List<IDiagnosis>();
            this.id = GenerateID();
            this.Type = type;
        }

        public AnimalType Type
        {
            get => this.type;
            protected set
            {
                // Validation ?
                this.type = value;
            }
        }

        public string Name
        {
            get => this.name;
            set => this.name = value;
        }

        //public Owner Owner
        //{
        //    get => this.owner;
        //    set { this.owner = value; }
        //}

        public GenderType Gender
        {
            get => this.gender;
            set
            {
                if (!Enum.IsDefined(typeof(GenderType), value))
                {
                    throw new ArgumentException("Invalid gender");
                }
                this.gender = value;
            }
        }

        public string ID { get => this.id; }

        static int animalsCount = 0;
        public string GenerateID()
        {
            StringBuilder sb = new StringBuilder();

            animalsCount++;
            sb.Append('A');
            sb.Append(animalsCount);

            return sb.ToString();
        }

        public virtual string PrintInfo()
        {
            StringBuilder str = new StringBuilder();

            str.AppendLine($"Pet Type: {this.Type}");
            str.AppendLine($"Name: {this.Name}");
            str.AppendLine($"Gender: {this.Gender}");
            str.AppendLine($"ID: {this.ID}");

            return str.ToString();
        }

        public virtual void FillInfo()
        {

        }
    }
}
