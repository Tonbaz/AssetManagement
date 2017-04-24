using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AssetManagementWeb.Startup))]
namespace AssetManagementWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
