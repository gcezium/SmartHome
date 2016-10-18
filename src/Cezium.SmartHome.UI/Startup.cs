using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Cezium.SmartHome.UI.Startup))]
namespace Cezium.SmartHome.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
