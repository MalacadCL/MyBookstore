using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyBookstore_MalacadCL.Startup))]
namespace MyBookstore_MalacadCL
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
