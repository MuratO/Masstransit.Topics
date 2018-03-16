﻿using Common.Helpers;
using Common.Interfaces;
using MassTransit;

namespace Producer
{
    public class BusInstance
    {
        public IBusControl CreateBus()
        {
            return Bus.Factory.CreateUsingRabbitMq(cfg =>
            {
                /*
                if you want publish message, use this configuration
                
                cfg.Host(RabbitMqConstants.Uri.Uri, hst =>
                {
                    hst.Username(RabbitMqConstants.Username);
                    hst.Password(RabbitMqConstants.Password);
                });

                */
                cfg.Send<ISampleRequest>(x => x.UseRoutingKeyFormatter(c => c.Message.RoutingKey));

                cfg.Host(RabbitMqConstants.Uri.Uri, hst =>
                {
                    hst.Username(RabbitMqConstants.Username);
                    hst.Password(RabbitMqConstants.Password);
                });
            });
        }
    }
}