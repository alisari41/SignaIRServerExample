using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace SignaIRServerExample.Hubs
{
    public class MyHub : Hub
    {
        public async Task SendMessageAsync(string message)
        {//Client ları haberleştirmek için kullanılır gibi düşün

            //ekstra işlemler.....
           await Clients.All.SendAsync("receiveMessage",message);//subscrip olan herkese gönder. "receiveMessage" client larda olan fonksiyon adı
        }
    }
}
