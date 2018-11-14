using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(chatapp.Startup))]
namespace chatapp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            app.MapSignalR();
        }
    }
}
