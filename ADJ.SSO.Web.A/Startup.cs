using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ADJ.SSO.Web.A.Startup))]
namespace ADJ.SSO.Web.A
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
