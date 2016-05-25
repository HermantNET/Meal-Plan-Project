using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MealPlanApplication.Startup))]
namespace MealPlanApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
