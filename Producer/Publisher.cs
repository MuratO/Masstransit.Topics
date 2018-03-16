using System;
using System.Threading.Tasks;
using Common.Helpers;
using Common.Interfaces;
using EasyConsole;
using MassTransit;

namespace Producer
{
    public class Publisher
    {
        private ISendEndpoint _endpoint;
        private static IBusControl _busControl;

        public Publisher()
        {
            _busControl = new BusInstance().CreateBus();
        }

        public async Task Send(ISampleRequest message)
        {
            try
            {
                _endpoint = await _busControl.GetSendEndpoint(RabbitMqConstants.MessageExchangeUri.Uri);
                await _endpoint.Send<ISampleRequest>(message);
            }
            catch (Exception e)
            {
                Console.WriteLine("");
                Output.WriteLine(ConsoleColor.Red, "ERROR");
                Output.WriteLine(ConsoleColor.Red, e.Message);
                Output.WriteLine(ConsoleColor.Red, e.InnerException.Message);
            }
        }

        public void Publish(ISampleRequest message)
        {
            try
            {
                _busControl.Publish<ISampleRequest>(message);
            }
            catch (Exception e)
            {
                Console.WriteLine("");
                Output.WriteLine(ConsoleColor.Red, "ERROR");
                Output.WriteLine(ConsoleColor.Red, e.Message);
                Output.WriteLine(ConsoleColor.Red, e.InnerException.Message);
            }
        }
    }
}
