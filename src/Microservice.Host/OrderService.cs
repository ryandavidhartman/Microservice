using System.Collections.Generic;
using ServiceStack;

namespace Microservice.Host
{
    public class OrderService : Service
    {
        private List<Order> _orders;

        public OrderService()
        {
            _orders = new List<Order>();
        }

        public object Get(GetOrders request)
        {
            return new List<Order>();
        }

        public object Post(Order data)
        {
            var id = _orders.Count + 1;
            data.Id = id;
            _orders.Add(data);
            return data;
        }

        public object Put(Order data)
        {
            var index = _orders.FindIndex(i => i.Id == data.Id);
            _orders[index] = data;
            return data;
        }

        public object Delete(Order data)
        {
            var order = _orders.Find(i => i.Id == data.Id);
            _orders.Remove(order);
            return null;
        }

    }
}
