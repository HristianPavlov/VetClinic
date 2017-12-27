using System.Collections.Generic;

namespace VetClinic.Commands.Contracts
{
    public interface IStaffCommand
    {
        void CreateStaffPerson(IList<string> parameters);

        void RemoveStaffPerson(IList<string> parameters);
      
        void ListStaff();
    }
}
