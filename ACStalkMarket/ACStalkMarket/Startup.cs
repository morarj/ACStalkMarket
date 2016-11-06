using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ACStalkMarket.Startup))]
namespace ACStalkMarket
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
