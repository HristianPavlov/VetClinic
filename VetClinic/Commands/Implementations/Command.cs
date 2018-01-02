using System.Collections.Generic;
using VetClinic.Common;

namespace VetClinic.Commands.Implementations
{
    public abstract class Command : VetClinicEventHandler
    {
        public abstract void Create(IList<string> parameters);

        public abstract void Delete(IList<string> parameters);
    }
}
