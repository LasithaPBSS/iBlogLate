using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(iBlog.Startup))]
namespace iBlog
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
