using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace Project.WEB.SignalR
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string user,string message)
        {
            await Clients.All.SendAsync("Test Message", user, message);
        }
    }
}
