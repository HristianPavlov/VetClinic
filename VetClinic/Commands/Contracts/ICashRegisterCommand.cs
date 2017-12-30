namespace VetClinic.Commands.Contracts
{
    using System.Collections.Generic;
    using VetClinic.Data.Contracts;

    public interface ICashRegisterCommand
    {
        decimal Balance { get; }

        ICollection<IService> BookedServices { get; }

        void AddBookedService(IList<string> parameters);

        void UpdateBalance(decimal amount);

        void PrintBalance();

        void PrintBookedServices();
    }
}
