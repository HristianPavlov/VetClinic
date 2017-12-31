namespace VetClinic.Commands.Contracts
{
    public interface IProcessorCommand
    {
        void ProcessCommand(string commandLine);
    }
}