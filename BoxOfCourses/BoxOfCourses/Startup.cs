using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BoxOfCourses.Startup))]
namespace BoxOfCourses
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
