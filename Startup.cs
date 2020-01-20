using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(StreamDream.Startup))]
namespace StreamDream
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
