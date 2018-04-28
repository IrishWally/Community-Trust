using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Community_Trust.Startup))]
namespace Community_Trust
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
