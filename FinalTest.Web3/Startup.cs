using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FinalTest.Web3.Startup))]
namespace FinalTest.Web3
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
            ConfigureAuth(app);
        }
    }
}
