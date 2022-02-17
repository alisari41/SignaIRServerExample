using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using SignaIRServerExample.Business;
using SignaIRServerExample.Hubs;

namespace SignaIRServerExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly MyBusiness _myBusiness;
        private readonly IHubContext<MyHub> _hubContext;

        public HomeController(MyBusiness business, IHubContext<MyHub> hubContext)
        {
            _myBusiness = business;
            _hubContext = hubContext;
        }

        [HttpGet("{message}")]//bunu belirtmek lazım
        public async Task<IActionResult> Index(string message)
        {
            await _hubContext.Clients.All.SendAsync("receiveMessage", message);
            return Ok();
        }
    }
}
