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
        private ICollection<IDiagnosis> diagnosises;  // ???????? To do
                                                      // private int age;
        private string id;
        private AnimalType type;

        public Animal(string name, GenderType gender, AnimalType type)//, int age, Owner owner
        {
            Guard.WhenArgument(name, "Invalid name").IsNull().Throw();
            Guard.WhenArgument(name.Length, "Invalid name length").IsLessThan(2).IsGreaterThan(15).Throw();
            // Guard.WhenArgument(age, "Age less than zero").IsLessThan(0).Throw();

            this.Name = name;
            //  this.Owner = owner;
            this.Gender = gender;
            this.diagnosises = new List<IDiagnosis>();
            // this.Age = age;
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

        //public int Age
        //{
        //    get => this.age;
        //    set => this.age = value;
        //}

        public bool NewClient { get; set; } // not implemented

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
    }
}
