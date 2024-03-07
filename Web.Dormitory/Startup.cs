using Microsoft.Owin;
using Owin;
using Web.Dormitory.Utils;

[assembly: OwinStartupAttribute(typeof(Web.Dormitory.Startup))]
namespace Web.Dormitory
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            AccountInit.initAccountsAndRoles();
        }
    }
}
