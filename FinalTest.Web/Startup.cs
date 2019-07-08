using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FinalTest.Web.Startup))]
namespace FinalTest.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
