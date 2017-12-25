namespace VetClinic.Commands.Contracts
{
    public interface ICommand
    {
        string Name { get; }

        //string Execute(IList<string> parameters);
    }
}