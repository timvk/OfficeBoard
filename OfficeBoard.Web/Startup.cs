using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OfficeBoard.Web.Startup))]
namespace OfficeBoard.Web
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            app.MapSignalR();
            ConfigureAuth(app);
        }
    }
}
