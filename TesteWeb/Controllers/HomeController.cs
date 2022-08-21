using exemplo2.api.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using TesteWeb.Models;

namespace TesteWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly HttpClient httpClient;

        public HomeController(ILogger<HomeController> logger, HttpClient httpClient)
        {
            _logger = logger;
            this.httpClient = httpClient;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(int id)
        {
            httpClient.BaseAddress = new Uri("https://localhost:7184/api/");
            var resultado = await httpClient.GetAsync("cliente/" + id);
            var result = resultado.Content.ReadAsStringAsync();
            var clientes = JsonConvert.DeserializeObject<List<Cliente>>(result.Result);

            return View(clientes);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConsultarTodos()
        {
            httpClient.BaseAddress = new Uri("https://localhost:7184/api/");
            var resultado = await httpClient.GetAsync("cliente");
            var result = resultado.Content.ReadAsStringAsync();
            var clientes = JsonConvert.DeserializeObject<List<Cliente>>(result.Result);

            return View(clientes);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}