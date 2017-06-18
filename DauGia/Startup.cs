using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DauGia.Startup))]
namespace DauGia
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
