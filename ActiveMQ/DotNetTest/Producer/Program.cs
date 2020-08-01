using System;
using Amqp;

namespace Producer
{
    class Program
    {
        static void Main(string[] args)
        {
            var addr = new Address("amqp://admin:admin@localhost:5672");

            var con = new Connection(addr);
            var session = new Session(con);

            var senderLink = new SenderLink(session, "test-sender", "q1");

            Console.WriteLine("Producer started. Enter message text or 'exit' to quit.");

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "exit") break;

                var msg = new Message($"Test message: {input}");
                senderLink.Send(msg);

                Console.WriteLine("Message sent. Enter next message text or 'exit' to quit.");
            }

            senderLink.Close();
            session.Close();
            con.Close();
        }
    }
}
