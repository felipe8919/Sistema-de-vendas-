using exemplo2.api.Services;
using Microsoft.AspNetCore.Mvc;

namespace exemplo2.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendaController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var vendaService = new VendaService();

            return Ok(vendaService.ObterVendas());
        }
    }
}
