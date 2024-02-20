using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebFormAPP.Startup))]
namespace WebFormAPP
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
