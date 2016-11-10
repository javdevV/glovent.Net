using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(gloventApp.GUI.Startup))]
namespace gloventApp.GUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
