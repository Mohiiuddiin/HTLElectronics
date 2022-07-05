using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HTLElectronics.Startup))]
namespace HTLElectronics
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
