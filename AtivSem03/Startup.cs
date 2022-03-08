using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AtivSem03.Startup))]
namespace AtivSem03
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
