using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SignaIRServerExample.Business;

namespace SignaIRServerExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly MyBusiness _myBusiness;

        public HomeController(MyBusiness business)
        {
            _myBusiness = business;
        }

        [HttpGet("{message}")]//bunu belirtmek lazım
        public async Task<IActionResult> Index(string message)
        {
            await _myBusiness.SendMessageAsync(message);
            return Ok();
        }
    }
}
