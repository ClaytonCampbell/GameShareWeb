using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GameShare.WebMVC.Startup))]
namespace GameShare.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
