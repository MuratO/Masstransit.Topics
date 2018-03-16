using System;
using System.Configuration;

namespace Common.Helpers
{
    public class RabbitMqConstants
    {
        public static string Host => ConfigurationManager.AppSettings["RabbitMQHost"];
        public static int Port => Convert.ToInt32(ConfigurationManager.AppSettings["RabbitMQPort"]);
        public static string Username => ConfigurationManager.AppSettings["RabbitMQUsername"];
        public static string Password => ConfigurationManager.AppSettings["RabbitMQPassword"];
        public static UriBuilder Uri => new UriBuilder("rabbitmq", Host, Port);

        public static string MessageQueue => ConfigurationManager.AppSettings["RabbitMessageQueue"];
        public static UriBuilder MessageQueueUri => new UriBuilder("rabbitmq", Host, Port,ConfigurationManager.AppSettings["RabbitMessageQueue"]);


        public static string MessageExchange => ConfigurationManager.AppSettings["RabbitMessageExchange"];
        public static string EarthMessageQueue => ConfigurationManager.AppSettings["RabbitMessageQueueEarth"];
        public static string MarsMessageQueue => ConfigurationManager.AppSettings["RabbitMessageQueueMars"];
        public static string SaturnMessageQueue => ConfigurationManager.AppSettings["RabbitMessageQueueSaturn"];
        public static UriBuilder MessageExchangeUri => new UriBuilder("rabbitmq", Host, Port, ConfigurationManager.AppSettings["RabbitMessageExchange"]);


    }
}
