namespace SciHub.Web.Hubs
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using Microsoft.AspNet.SignalR;

    public class ChatHub : Hub
    {
        public void Hello()
        {
            Clients.All.hello();
        }

        public void BroadCastMessage(string name, string message)
        {
            Clients.All.broadcastMessage(name, message);
        }

        public void Send(string name, string message)
        {
            Clients.All.addNewMessageToPage(name, message);
        }
    }
}