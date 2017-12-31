namespace VetClinic
{
    using System;
    using VetClinic.Commands.Contracts;
    using VetClinic.Common.ConsoleServices.Contracts;

    public class Engine : IEngine
    {
        private readonly IWriter writer;
        private readonly IProcessorCommand processorCommand;

        public Engine(IWriter writer, IProcessorCommand processorCommand)
        {
            this.writer = writer;
            this.processorCommand = processorCommand;
        }

        public void Start()
        {
            this.writer.WriteLine("System running...");

            while (true)
            {
                var command = Console.ReadLine();

                this.processorCommand.ProcessCommand(command);

                this.writer.WriteLine("Waiting for command...");
            }
        }
    }
}
