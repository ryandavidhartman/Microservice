using System;
using System.Collections.Generic;
using System.Linq;
using ServiceStack;
using ServiceStack.Caching;

namespace Microservice.Host
{
    public class OrderService : Service
    {
        private static List<Order> _orders;

        public OrderService()
        {
            if(_orders == null)
                _orders = new List<Order>();
        }

        public object Get(GetOrders request)
        {
            var cacheKey = request.SerializeToString();

            var result = base.Request.ToOptimizedResultUsingCache(base.Cache, cacheKey, () =>
            {

                if (request.Ids != null && request.Ids.Count > 0)
                {
                    var results = _orders.Where(i => request.Ids.Contains(i.Id)).ToList();
                    return results;
                }

                if (request.CusomterIds != null && request.CusomterIds.Count > 0)
                {
                    var results = _orders.Where(i => request.CusomterIds.Contains(i.CustomerId)).ToList();
                    return results;
                }

                if (request.ItemIds != null && request.ItemIds.Count > 0)
                {
                    var results = _orders.Where(i => request.ItemIds.Intersect(i.ItemIds).Any()).ToList();
                    return results;
                }

                if (request.OrderDate != null)
                {
                    var results = _orders.Where(i => ((DateTime) request.OrderDate).Date == i.OrderDate.Date).ToList();
                    return results;
                }

                if (request.ShipDate != null)
                {
                    var results = _orders.Where(i => i.ShipDate != null && ((DateTime) request.ShipDate).Date == ((DateTime) i.ShipDate).Date).ToList();
                    return results;
                }
                return _orders;
            });

            return result;
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
