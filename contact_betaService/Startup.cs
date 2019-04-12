using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(contact_betaService.Startup))]

namespace contact_betaService
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureMobileApp(app);
        }
    }
}