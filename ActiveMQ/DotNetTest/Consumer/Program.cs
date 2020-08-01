using System;
using System.Threading;
using Amqp;

namespace Consumer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Consumer started...");

            var addr = new Address("amqp://localhost:5672");

            var con = new Connection(addr);
            var session = new Session(con);

            var receiverLink = new ReceiverLink(session, "test-receiver", "q1");


            while (true)
            {
                var msg = receiverLink.Receive(TimeSpan.MaxValue);

                Console.WriteLine("Received: {0}", msg.GetBody<string>());

                receiverLink.Accept(msg);
                
                Thread.Sleep(1000);
            }
        }
    }
}
