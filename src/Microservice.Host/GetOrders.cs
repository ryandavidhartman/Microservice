
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using ServiceStack;

namespace Microservice.Host
{
    [Api("Return a List of Orders")]
    [Route("/Orders", "GET")]
    [Route("/Orders/{Ids}")]
    [Route("/Orders/CusomterId/{CustomerIds}")]
    [Route("/Orders/ItemId/{ItemIds}")]
    [Route("/Orders/OrderDate/{OrderDate}")]
    [Route("/Orders/ShipDate/{ShipDate}")]
    public class GetOrders : IReturn<List<Order>>
    {
        public List<long> Ids { get; set; }
        public List<string> CusomterIds { get; set; }
        public List<long> ItemIds { get; set; } 
        public DateTime? OrderDate { get; set; }
        public DateTime? ShipDate { get; set; }
    }
}
