namespace VetClinic.Data.Models
{
    using System;
    using System.Text;
    using VetClinic.Data.Contracts;

    public class EngineCommand : IEngineCommand
    {
        private readonly string id;
        private readonly string name;

        public EngineCommand(string name)
        {
            this.id = Guid.NewGuid().ToString();
            this.name = name;
        }

        public string Id => this.id;

        public string Name => this.name;

        public string PrintInfo()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"Name: {this.Name}");
            sb.AppendLine($"Id: {this.Id}");

            return sb.ToString();
        }
    }
}
