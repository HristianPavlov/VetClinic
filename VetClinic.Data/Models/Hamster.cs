namespace VetClinic.Data.Models
{
    using VetClinic.Data.Common.Enums;

    public class Hamster : Animal
    {
        public Hamster(string name, GenderType gender) 
            : base(name, gender)
        {
            this.Type = AnimalType.Hamster;
        }


    }
}
