using System;
using Common.Models;

namespace Producer
{
    class Program
    {
        private static Publisher publisher = new Publisher();

        static void Main()
        {

            while (true)
            {
                Console.WriteLine("Press select message type...");

                var menu = new EasyConsole.Menu()
                    .Add("Send Message Earth and Mars", MarsMessage)
                    .Add("Send Message Earth and Saturn", SaturnMessage)
                    //.Add("Publish Simple Message", SimpleMessage)
                    ;

                menu.Display();
                

                Console.WriteLine("message send...");
            }
        }
       
        private static void MarsMessage()
        {
            var message =  new SampleRequest()
            {
                Request = "Hello From World !",
                RoutingKey = "EARTH.MARS",
                Timestamp = DateTime.Now
            };

            publisher.Publish(message);
        }

        private static void SaturnMessage()
        {
            var message =  new SampleRequest()
            {
                Request = "Hello From World !",
                RoutingKey = "EARTH.SATURN",
                Timestamp = DateTime.Now
            };

            publisher.Publish(message);
        }


        private static void SimpleMessage()
        {
            var message = new SampleRequest()
            {
                Request = "Hello From World !",
                Timestamp = DateTime.Now
            };

            publisher.Publish(message);
        }
    }
}
