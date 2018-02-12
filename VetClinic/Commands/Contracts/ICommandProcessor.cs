namespace VetClinic.Commands.Contracts
{
    public interface ICommandProcessor
    {
        void ProcessCommand(string commandLine);
    }
}