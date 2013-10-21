using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TicketingSystem.WebClient.Startup))]
namespace TicketingSystem.WebClient
{
    public partial class Startup 
    {
        public void Configuration(IAppBuilder app) 
        {
            ConfigureAuth(app);
        }
    }
}
