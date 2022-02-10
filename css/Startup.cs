using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IntegramsaUltimate.Startup))]
namespace IntegramsaUltimate
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
