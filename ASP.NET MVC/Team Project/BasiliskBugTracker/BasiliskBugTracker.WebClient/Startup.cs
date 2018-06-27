using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BasiliskBugTracker.WebClient.Startup))]
namespace BasiliskBugTracker.WebClient
{
    public partial class Startup 
    {
        public void Configuration(IAppBuilder app) 
        {
            ConfigureAuth(app);
        }
    }
}
