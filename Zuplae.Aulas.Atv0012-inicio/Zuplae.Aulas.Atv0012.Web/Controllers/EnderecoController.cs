using Microsoft.AspNetCore.Mvc;
using Zuplae.Aulas.Atv0012.Models;
using Zuplae.Aulas.Atv0012.Servics;

namespace Zuplae.Aulas.Atv0012.Web.Controllers
{
    public class EnderecoController : Controller

    {
        private EnderecoService _enderecoService;

        public EnderecoController(EnderecoService service)
        {
            _enderecoService = service;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Create(Endereco model) // Auto Binding do Model
        {
            var id = _enderecoService.Cadastrar(model);
            return RedirectToAction("List");
        }
        [HttpGet]
        public IActionResult List()
        {
            var enderecos = _enderecoService.Listar();
            return View(enderecos);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Endereco model = _enderecoService.ListarPorId(id);
            return View(model);
        }

        public IActionResult Edit(Endereco model)
        {
            bool editado = _enderecoService.Editar(model);
            return RedirectToAction("List");

        }

        public IActionResult Delete(int id)
        {
            _enderecoService.Deletar(id);
            return RedirectToAction("List");
        }
    }
 
}
