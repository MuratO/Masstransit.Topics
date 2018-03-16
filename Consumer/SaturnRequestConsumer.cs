using System;
using System.Threading.Tasks;
using Common.Interfaces;
using MassTransit;

namespace Consumer
{
    public class SaturnRequestConsumer : IConsumer<ISampleRequest>
    {
        public Task Consume(ConsumeContext<ISampleRequest> context)
        {
            Console.WriteLine("----- SATURN -----");
            Console.WriteLine("     REQUEST: " + context.Message.Request);
            Console.WriteLine("     SENT: " + context.Message.Timestamp);
            Console.WriteLine("     PROCESSED: " + DateTime.Now);
            Console.WriteLine("     THREAD-ID: " + System.Threading.Thread.CurrentThread.ManagedThreadId + "");
            Console.WriteLine("------------------------------------------------------------------------------------");

            return Task.CompletedTask;
        }
    }
}