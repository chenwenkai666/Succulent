using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SucculentWeb.Startup))]
namespace SucculentWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
