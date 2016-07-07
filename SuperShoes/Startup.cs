using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SuperShoes.Startup))]
namespace SuperShoes
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
