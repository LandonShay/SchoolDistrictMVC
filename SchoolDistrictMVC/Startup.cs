using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SchoolDistrictMVC.Startup))]
namespace SchoolDistrictMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
