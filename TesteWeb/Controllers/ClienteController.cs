using exemplo2.api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;

namespace TesteWeb.Controllers
{
    public class ClienteController : Controller

    {
        private readonly HttpClient httpClient;
        public ClienteController(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        // GET: ClienteController
        public ActionResult Index()
        {
            return View();
        }

// GET: ClienteController
        public async Task<ActionResult> Listar()
{
            httpClient.BaseAddress = new Uri("https://localhost:7184/api/");
            var resultado = await httpClient.GetAsync("cliente");
            var result = resultado.Content.ReadAsStringAsync();
            var clientes = JsonConvert.DeserializeObject<List<Cliente>>(result.Result);

            return View(clientes);
        }

        // GET: ClienteController/Details/5
        public ActionResult Detalhes(int id)
        {
            return View();
        }

        // GET: ClienteController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClienteController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {

                return RedirectToAction(nameof(Listar));
            }
            catch
            {
                return View();
            }
        }

        // GET: ClienteController/Edit/5
        public async Task<ActionResult> Editar(int id)
        {
            httpClient.BaseAddress = new Uri("https://localhost:7184/api/");
            var resultado = await httpClient.GetAsync("cliente/" + id);
            var result = resultado.Content.ReadAsStringAsync();
            var cliente = JsonConvert.DeserializeObject<Cliente>(result.Result);

            return View(cliente);
        }

        // POST: ClienteController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ClienteController/Delete/5
        public ActionResult Deletar(int id)
        {
            return View();
        }

        // POST: ClienteController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Deletar(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Listar));
            }
            catch
            {
                return View();
            }
        }
    }
}
