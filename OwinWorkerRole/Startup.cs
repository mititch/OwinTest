using Owin;

namespace OwinWorkerRole
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseWelcomePage();
        }
    }
}
