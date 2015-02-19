
using System;
using System.Collections.Generic;
using ServiceStack;

namespace Microservice.Host
{
    class Program
    {
        static void Main(string[] args)
        {
            var listeningOn = args.Length == 0 ? "http://*:1337/" : args[0];

            var appHost = new AppHost()
            .Init()
            .Start(listeningOn);

            Console.WriteLine("AppHost Created at {0}, listening on {1}", DateTime.Now, listeningOn);
            AddFakeData(listeningOn.Replace("*", "localhost"));

            Console.ReadKey();
        }

        static void AddFakeData(string listeningOn)
        {
            var jsonClient = new JsonServiceClient(listeningOn);
            var order1 = new Order
            {
                CustomerId = "1",
                ItemIds = new List<long> {1, 2, 3},
                OrderDate = DateTime.Now.AddDays(-5),
                ShipDate = DateTime.Now.AddDays(-4)
            };

            jsonClient.Post(order1);

            var order2 = new Order
            {
                CustomerId = "3",
                ItemIds = new List<long> { 3,4,5 },
                OrderDate = DateTime.Now.AddDays(-4),
                ShipDate = DateTime.Now.AddDays(-3)
            };

            jsonClient.Post(order2);

            var order3 = new Order
            {
                CustomerId = "5",
                ItemIds = new List<long> { 5, 6, 7 },
                OrderDate = DateTime.Now.AddDays(-3),
                ShipDate = DateTime.Now.AddDays(-2)
            };

            jsonClient.Post(order3);

        }
    }
}
