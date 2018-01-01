namespace VetClinic.Commands.Implementations
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using VetClinic.Commands.Contracts;

    public class CommandGetter : ICommandGetter
    {
        public List<string> GetAllCommands()
        {
            var allCommands = new List<string>();

            var allMethods = Assembly
                        .GetAssembly(typeof(ICommandGetter))
                        .GetTypes()
                        .Where(t => t.IsInterface)
                        .Select(t => new
                        {
                            Commands = t.GetMethods()
                                            .Where(m => m.ReturnType == typeof(void)).ToList()
                        })
                        .ToList();

            foreach (var methodList in allMethods.Skip(1))
            {
                foreach (var command in methodList.Commands)
                {
                    if (allCommands.Contains(command.Name))
                    {
                        continue;
                    }
                    else
                    {
                        allCommands.Add(command.Name);
                    }
                }
            }

            return allCommands;
        }
    }
}
