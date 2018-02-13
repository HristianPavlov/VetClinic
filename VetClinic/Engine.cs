namespace VetClinic
{
    using System;
    using VetClinic.Commands.Contracts;
    using VetClinic.Providers.Contracts;

    public class Engine : IEngine
    {
        private readonly ICommandProcessor commandProcessor;
        private readonly IReader reader;
        private readonly IWriter writer;

        public Engine(ICommandProcessor commandProcessor, IReader reader, IWriter writer)
        {
            this.commandProcessor = commandProcessor ?? throw new ArgumentNullException("commandProcessor");
            this.reader = reader ?? throw new ArgumentNullException("reader");
            this.writer = writer ?? throw new ArgumentNullException("writer");
        }

        public void Start()
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

                this.commandProcessor.ProcessCommand(commandLine);

                this.writer.WriteLine(" Waiting for command...");
            }
        }
    }
}
