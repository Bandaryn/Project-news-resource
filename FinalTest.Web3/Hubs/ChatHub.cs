using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace FinalTest.Web3.Hubs
{
    public class ChatHub : Hub
    {
        public void SendMessage(string name, string message)
        {

            Clients.All.sendMessageToClient(name, message);
        }

    }
}