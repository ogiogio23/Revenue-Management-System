using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RevenueManagementSystem.Startup))]
namespace RevenueManagementSystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
