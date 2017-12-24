namespace VetClinic.Data.Models
{
    using System.Text;
    using Contracts;
    using Abstractions;

    public abstract class PersonStaff : Human, IIdentifiable
    {
        private string id;

        public PersonStaff(string firstName, string lastName, string phoneNumber) : base(firstName, lastName, phoneNumber)
        {
            this.id = GenerateId();
        }

        public string Id { get => this.id; set => this.id = value; }

        static int staffCount = 0;
        public string GenerateId()
        {
            StringBuilder sb = new StringBuilder();

            staffCount++;
            sb.Append('S');
            sb.Append(staffCount);

            return sb.ToString();
        }
    }
}
