using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NetBluSchool.Startup))]
namespace NetBluSchool
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

        }
    }
}
