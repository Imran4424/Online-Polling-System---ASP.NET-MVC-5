using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OnlinePollingSystem.Startup))]
namespace OnlinePollingSystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
