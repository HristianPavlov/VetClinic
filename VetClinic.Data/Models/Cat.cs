namespace VetClinic.Data.Models
{
    using Abstractions;
    using Bytes2you.Validation;
    using Common.Enums;
    using System.Text;

  public  class Cat : Animal
    {
        private int age;

        public Cat(string name, GenderType gender, int age) 
            : base(name, gender, AnimalType.Cat)
        {
            //this.Breed = breed;
            this.Age = age;
            //this.Type = AnimalType.Cat;
        }

        public int Age
        {
            get => this.age;
            private set
            {
                Guard.WhenArgument(value, "Age less than zero").IsLessThan(0).Throw();
                this.age = value;
            }

        }

        public override string PrintInfo()
        {
            StringBuilder str = new StringBuilder();

            str.AppendLine($"Pet Type: {this.Type}");
            str.AppendLine($"Name: {this.Name}");
            str.AppendLine($"Gender: {this.Gender}");
            str.AppendLine($"Age: {this.Age}");
            str.AppendLine($"ID: {this.ID}");

            return str.ToString();

        }

    }
}
