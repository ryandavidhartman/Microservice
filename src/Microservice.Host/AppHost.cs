using ServiceStack;
using ServiceStack.Caching;

namespace Microservice.Host
{
    public class AppHost : AppSelfHostBase
    {
        public AppHost() : base("HttpListener Self-Host", typeof(OrderService).Assembly) { }

        public override void Configure(Funq.Container container)
        {
            container.Register<ICacheClient>(new MemoryCacheClient());
        }
    }
}
