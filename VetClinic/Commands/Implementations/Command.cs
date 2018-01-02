namespace VetClinic.Commands.Implementations
{
    using System.Collections.Generic;
    using VetClinic.Common;

    public abstract class Command : VetClinicEventHandler
    {
        public abstract void Create(IList<string> parameters);

        public abstract void Delete(IList<string> parameters);
    }
}
