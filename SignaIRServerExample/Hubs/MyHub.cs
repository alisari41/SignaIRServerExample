using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace SignaIRServerExample.Hubs
{
    public class MyHub : Hub
    {
        private static List<string> clients = new List<string>();
        //public async Task SendMessageAsync(string message)
        //{//Client ları haberleştirmek için kullanılır gibi düşün

        //    //ekstra işlemler.....
        //    await Clients.All.SendAsync("receiveMessage", message);//subscrip olan herkese gönder. "receiveMessage" client larda olan fonksiyon adı
        //}

        //OnConnectedAsync = Hub’a herhangi bir client bağlantı kurduğunda tetiklenir.
        public override async Task OnConnectedAsync()
        {
            clients.Add(Context.ConnectionId);//bağlanan client'ları listelemek için
            await Clients.All.SendAsync("clients", clients);// listeleme işlemlerinden haberdar olsun
            await Clients.All.SendAsync("userJoined", Context.ConnectionId);
        }


        //OnDisconnectedAsync = Hub’dan var olan bağlantısı olan client koparsa tetiklenir
        public override async Task OnDisconnectedAsync(Exception exception)
        {
            clients.Remove(Context.ConnectionId);//bağlantısı kopan/çıkan client'ları listelemek için
            await Clients.All.SendAsync("clients", clients);// listeleme işlemlerinden haberdar olsun
            await Clients.All.SendAsync("userLeaved", Context.ConnectionId);
        }
    }
}
