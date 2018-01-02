namespace VetClinic.Commands.Contracts
{
    using System.Collections.Generic;

    public interface IServiceCommand
    {
        void CreateService(IList<string> parameters);

        void DeleteService(IList<string> parameters);

        void ListServices(IList<string> parameters);

        void PerformService(IList<string> parameters);

        void BookService(IList<string> parameters);
        
        decimal CloseAccount(IList<string> parameters);
    }
}
