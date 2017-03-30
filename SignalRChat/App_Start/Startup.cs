using Microsoft.Owin;
using Owin;

namespace SignalRChat.App_Start
{ 
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}