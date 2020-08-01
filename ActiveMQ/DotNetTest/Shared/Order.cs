using System;
using Amqp.Serialization;

namespace Shared
{
    [AmqpContract]
    public class Order
    {
        [AmqpMember]
        public string ProductCode;

        [AmqpMember]
        public int Quantity;

        [AmqpMember]
        public DateTime Date;
    }
}