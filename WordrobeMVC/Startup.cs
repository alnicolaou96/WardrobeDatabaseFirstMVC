using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WordrobeMVC.Startup))]
namespace WordrobeMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
