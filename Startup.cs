using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(New11.Web.Startup))]
namespace New11.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
