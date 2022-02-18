using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using SignalRServerExample.Business;
using SignalRServerExample.Interfaces;

namespace SignalRServerExample.Hubs
{
    public class MyHub : Hub<IMessageClient>
    {
        private static List<string> clients = new List<string>();
        readonly MyBusiness _myBusiness;

        public MyHub(MyBusiness myBusiness)
        {
            _myBusiness = myBusiness;
        }

        public async Task SendMessageAsync(string message)
        {//Client ları haberleştirmek için kullanılır gibi düşün

            //ekstra işlemler.....
            //await Clients.All.SendAsync("receiveMessage", message);//subscrip olan herkese gönder. "receiveMessage" client larda olan fonksiyon adı
            await _myBusiness.SendMessageAsync(message);
        }

        //OnConnectedAsync = Hub’a herhangi bir client bağlantı kurduğunda tetiklenir.
        public override async Task OnConnectedAsync()
        {
            clients.Add(Context.ConnectionId);//bağlanan client'ları listelemek için
            //await Clients.All.SendAsync("clients", clients);// listeleme işlemlerinden haberdar olsun
            //await Clients.All.SendAsync("userJoined", Context.ConnectionId);
            await Clients.All.Clients(clients);
            await Clients.All.UserJoined(Context.ConnectionId);
        }


        //OnDisconnectedAsync = Hub’dan var olan bağlantısı olan client koparsa tetiklenir
        public override async Task OnDisconnectedAsync(Exception exception)
        {
            clients.Remove(Context.ConnectionId);//bağlantısı kopan/çıkan client'ları listelemek için
            await Clients.All.Clients(clients);
            await Clients.All.UserLeaved(Context.ConnectionId);

        }
    }
}
