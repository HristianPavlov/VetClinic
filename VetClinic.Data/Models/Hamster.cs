using VetClinic.Common.Enums;

namespace VetClinic.Data.Models
{
    public class Hamster : Animal
    {
        public Hamster(string name, GenderType gender) : base(name, gender)
        {
            this.Type = AnimalType.Hamster;
        }


    }
}
