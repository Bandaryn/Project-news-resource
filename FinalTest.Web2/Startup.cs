using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FinalTest.Web2.Startup))]
namespace FinalTest.Web2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
