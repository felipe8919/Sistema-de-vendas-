using exemplo1.api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace exemplo1.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendaController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var vendaService = new VendaService();

            return Ok(vendaService.ObterVenda());
        }
    }
}
