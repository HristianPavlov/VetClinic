using System.Collections.Generic;

namespace VetClinic.Commands.Contracts
{
    public interface IEmployeeCommand
    {
        void CreateEmployee(IList<string> parameters);

        void RemoveEmployee(IList<string> parameters);
      
        void ListEmployees();

        void SearchByPhone(IList<string> parameters);
    }
}
