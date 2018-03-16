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
                
                cfg.ReceiveEndpoint(host, RabbitMqConstants.EarthMessageQueue, x =>
                {
                    x.BindMessageExchanges = false;

                    x.Consumer<EarthRequestConsumer>();
                    x.Consumer<RequestFaultConsumer>();

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
                    x.Consumer<RequestFaultConsumer>();

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
                    x.Consumer<RequestFaultConsumer>();

                    x.Bind(RabbitMqConstants.MessageExchange, s =>
                    {
                        s.RoutingKey = "*.SATURN";
                        s.ExchangeType = ExchangeType.Topic;
                    });
                });
            });
        }
    }
}
