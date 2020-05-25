using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(ServiceStation.Areas.Identity.IdentityHostingStartup))]
namespace ServiceStation.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}