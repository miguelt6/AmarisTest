using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Amaris.Startup))]
namespace Amaris
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
