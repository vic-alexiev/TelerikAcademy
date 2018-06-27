using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OnlineDatingSystem.Startup))]
namespace OnlineDatingSystem
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
