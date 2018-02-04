using Castle.DynamicProxy;
using System.Diagnostics;
using VetClinic.Providers.Contracts;

namespace VetClinic.Console.Interceptors
{
    public class StopwatchInterceptor : IInterceptor
    {
        private readonly IWriter writer;

        public StopwatchInterceptor(IWriter writer)
        {
            this.writer = writer;
        }

        public void Intercept(IInvocation invocation)
        {
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();
            invocation.Proceed();
            stopwatch.Stop();

            this.writer.WriteLine($"Executed {invocation.Method.Name} for {stopwatch.ElapsedTicks} ticks.");
        }
    }
}
