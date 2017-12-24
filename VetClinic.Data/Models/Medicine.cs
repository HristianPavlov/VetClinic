namespace VetClinic.Data.Models
{
    using Contracts;

    public class Medicine : Supply, ISuppliable, IMedicine
    {
        public Medicine(string name, int quantity) : base(name, quantity)
        {
        }
    }
}
