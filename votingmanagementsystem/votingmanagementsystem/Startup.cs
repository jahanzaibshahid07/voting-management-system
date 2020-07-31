using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(votingmanagementsystem.Startup))]
namespace votingmanagementsystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
