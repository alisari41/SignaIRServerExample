using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SignalRServerExample.Business;
using SignalRServerExample.Hubs;

namespace SignalRServerExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        readonly MyBusiness _myBusiness;
        readonly IHubContext<MyHub> _hubContext;

        public HomeController(MyBusiness business, IHubContext<MyHub> hubContext)
        {
            _myBusiness = business;
            _hubContext = hubContext;
        }

        [HttpGet("{message}")]//bunu belirtmek lazım
        public async Task<IActionResult> Index(string message)
        {
            //await _hubContext.Clients.All.SendAsync("receiveMessage", message);
            await _myBusiness.SendMessageAsync(message);
            return Ok();
        }
    }
}
