namespace VetClinic.Common
{
    using System;
    using Bytes2you.Validation;

    public class CustomMessage : EventArgs
    {
        private string message;

        public CustomMessage(string message)
        {
            Guard.WhenArgument(message, "Message is null!").IsNullOrEmpty().Throw();
            Guard.WhenArgument(message.Length, "Message length must be greater than 0!").IsLessThan(1).Throw();
            this.message = message;
        }

        public string Message => this.message;

        public override string ToString()
        {
            return this.Message.ToString();
        }
    }
}
