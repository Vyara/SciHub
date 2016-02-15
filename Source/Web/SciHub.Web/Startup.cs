using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SciHub.Web.Startup))]
namespace SciHub.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
