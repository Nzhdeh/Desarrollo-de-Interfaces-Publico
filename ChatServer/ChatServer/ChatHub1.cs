using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace ChatServer
{
    public class ChatHub1 : Hub
    {
        public void Hello()
        {
            Clients.All.hello();
        }

        public void Send(string name, string message)
        {
            // Call the broadcastMessage method to update clients.
            Clients.All.broadcastMessage(name, message);
        }

        public void SendUWP(ClsMensage msg)
        {
            // Call the broadcastMessage method to update clients.
            Clients.All.broadcastMessage(msg);
        }
    }
}