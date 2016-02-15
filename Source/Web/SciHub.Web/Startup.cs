using Microsoft.Owin;
using Owin;
using SciHub.Web;

[assembly: OwinStartup(typeof(Startup))]

namespace SciHub.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            this.ConfigureAuth(app);
        }
    }
}