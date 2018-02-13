using System;
using System.Collections.Generic;
using VetClinic.Commands.Contracts;

namespace VetClinic.Core.Commands.Implementations
{
    public abstract class AbstractCommand : ICommand
    {
        private IList<string> parameters;

        public AbstractCommand()
        {
            this.Parameters = new List<string>();
        }

        public IList<string> Parameters
        {
            get => this.parameters;
            set => this.parameters = value ?? throw new ArgumentNullException("parameters");
        }

        public abstract void Execute();

    }
}
