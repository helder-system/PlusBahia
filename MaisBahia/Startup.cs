using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MaisBahia.Startup))]
namespace MaisBahia
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
