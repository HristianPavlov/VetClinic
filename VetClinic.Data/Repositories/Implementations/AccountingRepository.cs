using VetClinic.Data.Repositories.Contracts;

namespace VetClinic.Data.Repositories.Implementations
{
    public class AccountingRepository : IAccountingRepository
    {
        private decimal balance;

        public decimal Balance
        {
            get
            {
                return this.balance;
            }
            private set
            {
                this.balance = value;
            }
        }

        public void UpdateBalance(decimal amount)
        {
            this.Balance += amount;
        }
    }
}
