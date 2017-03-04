using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SaraZarubica_LB_M151_V232.Startup))]
namespace SaraZarubica_LB_M151_V232
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
