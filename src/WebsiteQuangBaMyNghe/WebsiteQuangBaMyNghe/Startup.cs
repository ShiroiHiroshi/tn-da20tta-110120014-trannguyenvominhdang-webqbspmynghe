using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebsiteQuangBaMyNghe.Startup))]
namespace WebsiteQuangBaMyNghe
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
