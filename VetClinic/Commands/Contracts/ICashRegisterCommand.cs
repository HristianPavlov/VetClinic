namespace VetClinic.Commands.Contracts
{
    using System.Collections.Generic;
    using VetClinic.Data.Contracts;

    public interface ICashRegisterCommand
    {
        decimal Balance { get; }

        ICollection<IService> BookedServices { get; }

        void AddBookedService(IList<string> parameters);

        decimal UpdateBalance(IList<string> parameters);

        void PrintBalance();
    }
}
