using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FRC_Scouting.Web.Startup))]
namespace FRC_Scouting.Web
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
