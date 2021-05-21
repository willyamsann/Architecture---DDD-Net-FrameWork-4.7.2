using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Arquitetura.UI.Web.Startup))]
namespace Arquitetura.UI.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
