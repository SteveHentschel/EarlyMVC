using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MiniContoso.Startup))]
namespace MiniContoso
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
