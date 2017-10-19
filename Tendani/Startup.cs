using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Tendani.Startup))]
namespace Tendani
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
