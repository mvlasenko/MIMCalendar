using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MIMCalendar.Startup))]
namespace MIMCalendar
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
