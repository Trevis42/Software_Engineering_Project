using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Contact_Billing_XamarinService.Startup))]

namespace Contact_Billing_XamarinService
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureMobileApp(app);
        }
    }
}