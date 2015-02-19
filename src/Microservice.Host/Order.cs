using System;
using System.Collections.Generic;
using ServiceStack;

namespace Microservice.Host
{
    [Api("Insert update or delete an Order Record")]
    [Route("/Orders", "POST")]
    [Route("/Orders/{Id}", "PUT")]
    [Route("/Orders/{Id}", "DELETE")]
    public class Order
    {
        public long Id { get; set; }
        public string CustomerId { get; set; }
        public List<long> ItemIds { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime? ShipDate { get; set; }
    }
}
