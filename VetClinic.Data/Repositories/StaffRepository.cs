namespace VetClinic.Data.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using VetClinic.Data.Contracts;

    public class StaffRepository : IStaffRepository
    {
        public readonly ICollection<IStaffPerson> staff;

        public StaffRepository()
        {
            this.staff = new List<IStaffPerson>();
        }

        public ICollection<IStaffPerson> Staff => new List<IStaffPerson>(this.staff);

        public void AddStaffPerson(IStaffPerson person)
        {
            var personExist = this.staff.Any(p => p.Id == person.Id);

            if (personExist)
            {
                throw new ArgumentException("This user already exists in database");
            }
            this.staff.Add(person);
        }

        public void RemoveStaffPerson(string id)
        {
            var staffPerson = this.staff.FirstOrDefault(p => p.Id == id);

            if (staffPerson == null)
            {
                throw new ArgumentException("This user does not exists in database");
            }
            this.staff.Remove(staffPerson);
        }
    }
}
