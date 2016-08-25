using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DungeonHub.Startup))]
namespace DungeonHub
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
