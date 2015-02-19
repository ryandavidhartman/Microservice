using ServiceStack;

namespace Microservice.Host
{
    public class AppHost : AppSelfHostBase
    {
        public AppHost() : base("HttpListener Self-Host", typeof(OrderService).Assembly) { }

        public override void Configure(Funq.Container container) { }
    }
}
