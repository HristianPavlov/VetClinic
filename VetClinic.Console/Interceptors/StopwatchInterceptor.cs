using Castle.DynamicProxy;
using System;
using System.Diagnostics;
using VetClinic.Providers.Contracts;

namespace VetClinic.Console.Interceptors
{
    public class StopwatchInterceptor : IInterceptor
    {
        private readonly IWriter writer;

        public StopwatchInterceptor(IWriter writer)
        {
            this.writer = writer ?? throw new ArgumentNullException(nameof(writer));
        }

        public void Intercept(IInvocation invocation)
        {
            var stopWatch = new Stopwatch();

            stopWatch.Start();
            invocation.Proceed();
            stopWatch.Stop();

            this.writer.WriteLine($"{invocation.Method.Name} has worked for {stopWatch.ElapsedMilliseconds} miliseconds.");

        }
    }
}
