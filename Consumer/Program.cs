using System;
using System.Web.Caching;
using EasyConsole;
using MassTransit;

namespace Consumer
{
        class Program
        {
            static void Main()
            {
                var busControl = new BusInstance().CreateBus();
            
                busControl.Start();

                Output.WriteLine(ConsoleColor.Green, "Bus started.");

        }

    }
 }

