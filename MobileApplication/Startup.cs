using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MobileApplication.Startup))]
namespace MobileApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
