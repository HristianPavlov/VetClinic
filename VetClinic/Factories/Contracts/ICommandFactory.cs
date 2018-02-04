namespace VetClinic.Factories.Contracts
{
    public interface ICommandFactory
    {
        // TODO
        object GetCommandClass(string commandAsString);
    }
}
