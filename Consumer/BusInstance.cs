using System;
using System.Threading.Tasks;
using Common.Helpers;
using Common.Interfaces;
using MassTransit;
using RabbitMQ.Client;

namespace Consumer
{
    public class BusInstance
    {
        public IBusControl CreateBus()
        {
            return Bus.Factory.CreateUsingRabbitMq(cfg =>
            {
                var host = cfg.Host(RabbitMqConstants.Uri.Uri, settings =>
                {
                    settings.Username(RabbitMqConstants.Username);
                    settings.Password(RabbitMqConstants.Password);
                });

                
                cfg.ReceiveEndpoint(host, RabbitMqConstants.MessageQueue, conf =>
                {
                    conf.Consumer<SampleRequestConsumer>();
                });
                

                cfg.ReceiveEndpoint(host, RabbitMqConstants.EarthMessageQueue, x =>
                {
                    x.BindMessageExchanges = false;

                    x.Consumer<EarthRequestConsumer>();

                    x.Bind(RabbitMqConstants.MessageExchange, s =>
                    {
                        s.RoutingKey = "EARTH.*";
                        s.ExchangeType = ExchangeType.Topic;
                    });
                });

                cfg.ReceiveEndpoint(host, RabbitMqConstants.MarsMessageQueue, x =>
                {
                    x.BindMessageExchanges = false;

                    x.Consumer<MarsRequestConsumer>();

                    x.Bind(RabbitMqConstants.MessageExchange, s =>
                    {
                        s.RoutingKey = "*.MARS";
                        s.ExchangeType = ExchangeType.Topic;
                    });
                });

                cfg.ReceiveEndpoint(host, RabbitMqConstants.SaturnMessageQueue, x =>
                {
                    x.BindMessageExchanges = false;

                    x.Consumer<SaturnRequestConsumer>();

                    x.Bind(RabbitMqConstants.MessageExchange, s =>
                    {
                        s.RoutingKey = "*.SATURN";
                        s.ExchangeType = ExchangeType.Topic;
                    });
                });
            });
        }
    }

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

    public class MarsRequestConsumer : IConsumer<ISampleRequest>
    {
        public Task Consume(ConsumeContext<ISampleRequest> context)
        {
            Console.WriteLine("----- MARS -----");
            Console.WriteLine("     REQUEST: " + context.Message.Request);
            Console.WriteLine("     SENT: " + context.Message.Timestamp);
            Console.WriteLine("     PROCESSED: " + DateTime.Now);
            Console.WriteLine("     THREAD-ID: " + System.Threading.Thread.CurrentThread.ManagedThreadId + "");
            Console.WriteLine("------------------------------------------------------------------------------------");

            return Task.CompletedTask;
        }
    }

    public class EarthRequestConsumer : IConsumer<ISampleRequest>
    {
        public Task Consume(ConsumeContext<ISampleRequest> context)
        {
            Console.WriteLine("----- EARTH -----");
            Console.WriteLine("     REQUEST: " + context.Message.Request);
            Console.WriteLine("     SENT: " + context.Message.Timestamp);
            Console.WriteLine("     PROCESSED: " + DateTime.Now);
            Console.WriteLine("     THREAD-ID: " + System.Threading.Thread.CurrentThread.ManagedThreadId + "");
            Console.WriteLine("------------------------------------------------------------------------------------");

            return Task.CompletedTask;
        }
    }
}
