namespace VetClinic
{
    using VetClinic.Commands.Contracts;
    using VetClinic.Common.ConsoleServices.Contracts;

    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly IProcessorCommand processorCommand;

        public Engine(IProcessorCommand processorCommand, IReader reader, IWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
            this.processorCommand = processorCommand;
        }

        public void Start()
        {
            this.writer.WriteLine("System running...");

            while (true)
            {
                var commandLine = this.reader.ReadLine();

                this.processorCommand.ProcessCommand(commandLine);

                this.writer.WriteLine("Waiting for command...");
            }
        }
    }
}
