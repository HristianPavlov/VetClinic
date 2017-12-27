using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VetClinic.Commands.Implementations
{
    public abstract class AbstractCommand
    {
        public event EventHandler SomethingHappened;

        protected void onMessage(string message)
        {
            this.SomethingHappened?.Invoke(this, new CommandMessage(message));
        }
    }
}
