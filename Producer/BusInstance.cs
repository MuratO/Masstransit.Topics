using Common.Helpers;
using Common.Interfaces;
using MassTransit;
using RabbitMQ.Client;

namespace Producer
{
    public class BusInstance
    {
        public IBusControl CreateBus()
        {
            return Bus.Factory.CreateUsingRabbitMq(cfg =>
            {
                //cfg.Send<ISampleRequest>(x => x.UseRoutingKeyFormatter(c => c.Message.RoutingKey));
                cfg.Publish<ISampleRequest>(x =>
                {
                    x.ExchangeType = ExchangeType.Topic;
                    //  x.SetExchangeArgument("ExchangeName","message.queue");
                });
                
                cfg.Host(RabbitMqConstants.Uri.Uri, hst =>
                {
                    hst.Username(RabbitMqConstants.Username);
                    hst.Password(RabbitMqConstants.Password);
                });
            });
        }
    }
}
