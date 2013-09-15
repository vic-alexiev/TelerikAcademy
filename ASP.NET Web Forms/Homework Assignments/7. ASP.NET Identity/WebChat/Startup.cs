using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebChat.Startup))]
namespace WebChat
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
