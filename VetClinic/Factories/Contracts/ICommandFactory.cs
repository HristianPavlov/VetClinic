using VetClinic.Commands.Contracts;

namespace VetClinic.Factories.Contracts
{
    public interface ICommandFactory
    {
        // TODO
        IUserCommand GetCommandClass(string commandAsString);
    }
}
