using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Interfaces;
using EasyConsole;
using MassTransit;

namespace Consumer
{
    public class RequestFaultConsumer :  IConsumer<Fault<ISampleRequest>>
    {
        public Task Consume(ConsumeContext<Fault<ISampleRequest>> context)
        {
            Console.WriteLine("");
            Output.WriteLine(ConsoleColor.Red, "ERROR");
            
            foreach (var exception in context.Message.Exceptions)
            {
                Output.WriteLine(ConsoleColor.Red, exception.Message);
            }

            return Task.CompletedTask;
        }
    }
}
