using System.Collections.Generic;
using System.Threading.Tasks;

namespace SignalRServerExample.Interfaces
{
    public interface IMessageClient
    {
        //bunları artık Hub' vermem yeterli
        Task Clients(List<string> clients);
        Task UserJoined(string connectionId); 
        Task UserLeaved(string connectionId); 
    }
}
