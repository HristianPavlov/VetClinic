namespace VetClinic.Data.Repositories.Contracts
{
    public interface IAccountingRepository
    {
        decimal Balance { get; }

        void UpdateBalance(decimal amount);
    }
}
