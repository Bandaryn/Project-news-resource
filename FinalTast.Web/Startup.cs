using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FinalTast.Web.Startup))]
namespace FinalTast.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
