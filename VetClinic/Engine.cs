namespace VetClinic
{
    using VetClinic.Commands.Contracts;
    using VetClinic.Common.ConsoleServices.Contracts;

    public class Engine : IEngine
    {
        private readonly IProcessorCommand processorCommand;
        private readonly IReader reader;
        private readonly IWriter writer;

        public Engine(IProcessorCommand processorCommand, IReader reader, IWriter writer)
        {
            this.processorCommand = processorCommand;
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
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
