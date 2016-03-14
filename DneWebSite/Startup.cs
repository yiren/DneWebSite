using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DneWebSite.Startup))]
namespace DneWebSite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
