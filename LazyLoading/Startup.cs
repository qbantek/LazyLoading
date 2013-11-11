using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LazyLoading.Startup))]
namespace LazyLoading
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
