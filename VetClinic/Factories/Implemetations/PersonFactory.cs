﻿namespace VetClinic.Factories.Implemetations
{
    using VetClinic.Data.Common.Enums;
    using VetClinic.Data.Contracts;
    using VetClinic.Data.Models;
    using VetClinic.Factories.Contracts;

    public class PersonFactory : IPersonFactory
    {
        public IUser CreateUser(string firstName, string lastName, string phoneNumber, string email) => new User(firstName, lastName, phoneNumber, email);

        public IStaffPerson CreateStaffPerson(string firstName, string lastName, string phoneNumber, string email, RoleType role)
            => new StaffPerson(firstName, lastName, phoneNumber, email, role);
    }
}
