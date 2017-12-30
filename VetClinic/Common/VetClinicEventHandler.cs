namespace VetClinic.Common
{
    using System;

    public abstract class VetClinicEventHandler
    {
        public event EventHandler ImportantEventHappened;

        protected void OnMessage(string message)
            => this.ImportantEventHappened?.Invoke(this, new CustomMessage(message));
    }
}
