using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using SignaIRServerExample.Hubs;

namespace SignaIRServerExample.Business
{
    public class MyBusiness
    {//MyHub'a bağlı Client'lere ileti göndermek için bu yola başvuruldu
        readonly IHubContext<MyHub> _hubContext;//dolaylı yoldan MyHub üzerinden wepsokcet işlemlerini gerçekleştiricem

        public MyBusiness(IHubContext<MyHub> hubContext)
        {
            _hubContext = hubContext;
        }
        public async Task SendMessageAsync(string message)
        {//Client ları haberleştirmek için kullanılır gibi düşün

            //ekstra işlemler.....
            await _hubContext.Clients.All.SendAsync("receiveMessage", message);//subscrip olan herkese gönder. "receiveMessage" client larda olan fonksiyon adı
        }
    }
}
