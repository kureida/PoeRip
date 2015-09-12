using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PoeApp.Startup))]
namespace PoeApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
