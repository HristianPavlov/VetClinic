using System.Text;
using VetClinic.Data.Contracts;

namespace VetClinic.Data.Models
{
    public abstract class Staff : Human, IIdentifiable
    {
        private string id;

        public Staff(string firstName, string lastName, string phoneNumber) : base(firstName, lastName, phoneNumber)
        {
            this.ID = GenerateID();
        }

        public string ID { get => this.id; set => this.id = value; }

        static int staffCount = 0;
        public string GenerateID()
        {
            StringBuilder sb = new StringBuilder();

            staffCount++;
            sb.Append('S');
            sb.Append(staffCount);

            return sb.ToString();
        }
    }
}
