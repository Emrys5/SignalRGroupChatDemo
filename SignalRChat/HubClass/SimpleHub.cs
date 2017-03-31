using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;

namespace SignalRChat.HubClass
{
    [HubName("simpleHub")]
    public class SimpleHub : Hub
    {

        public override Task OnConnected()
        {
            return base.OnConnected();
        }

        public void SendMsg(string msg)
        {



            // 所有人
            Clients.All.msg("发送给客户端的消息");

            // 特定 cooectionId
            Clients.Client("connectionId").msg("发送给客户端的消息");

            // 特定 group
            Clients.Group("groupName").msg("发送给客户端的消息");

        }

    }
}