using Owin;

namespace HelloOwin
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseErrorPage();
            //app.UseWelcomePage("/");

            app.Run((context =>
            {
                context.Response.ContentType = "text/plain";
                return context.Response.WriteAsync("Hello, world.");
            }));
        }
    }

}
