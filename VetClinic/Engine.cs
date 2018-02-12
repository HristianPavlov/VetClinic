namespace VetClinic
{
    using VetClinic.Commands.Contracts;
    using VetClinic.Providers.Contracts;

    public class Engine : IEngine
    {
        private readonly ICommandProcessor CommandProcessor;
        private readonly IReader reader;
        private readonly IWriter writer;

        public Engine(ICommandProcessor CommandProcessor, IReader reader, IWriter writer)
        {
            this.CommandProcessor = CommandProcessor;
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            this.writer.WriteLine(" System running...");

            while (true)
            {
                var commandLine = this.reader.ReadLine();

                if (commandLine.Trim().ToLower() == "finish")
                {
                    this.writer.WriteLine(" Goodbye!");
                    break;
                }

                this.CommandProcessor.ProcessCommand(commandLine);

                this.writer.WriteLine(" Waiting for command...");
            }
        }
    }
}
