using FsxWeb;
using Microsoft.Owin;

[assembly: OwinStartup(typeof(Startup))]

namespace FsxWeb
{
    using Owin;

    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // Configuration on Startup
        }
    }
}
