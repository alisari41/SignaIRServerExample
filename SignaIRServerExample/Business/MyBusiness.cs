using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using SignalRServerExample.Hubs;

namespace SignalRServerExample.Business
{
    public class MyBusiness
    {//MyHub'a bağlı Client'lere ileti göndermek için bu yola başvuruldu
      public  readonly IHubContext<MyHub> _hubContext;//dolaylı yoldan MyHub üzerinden wepsokcet işlemlerini gerçekleştiricem

        public MyBusiness(IHubContext<MyHub> hubContext)
        {
            _hubContext = hubContext;
        }
        public async Task SendMessageAsync(string message)
        {
            await _hubContext.Clients.All.SendAsync("receiveMessage", message);
        }
    }
}
