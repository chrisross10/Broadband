using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Broadband.Startup))]
namespace Broadband
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
