namespace VetClinic.Data.Contracts
{
    public interface IPerson
    {
        string Id { get; }

        string FirstName { get; }

        string LastName { get; }

        string PhoneNumber { get; }

        string Email { get; }
    }
}
