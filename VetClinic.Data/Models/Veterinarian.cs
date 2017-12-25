using VetClinic.Data.Common.Enums;

namespace VetClinic.Data.Models
{
    public class Veterinarian : StaffPerson
    {
        public Veterinarian(string firstName, string lastName, string phoneNumber, string email, RoleType role)
            : base(firstName, lastName, phoneNumber, email, RoleType.Veterinarian)
        {
        }
    }
}
