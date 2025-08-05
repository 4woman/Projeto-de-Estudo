using Microsoft.AspNetCore.Mvc;
using Zuplae.Aulas.Atv0012.Models;
using Zuplae.Aulas.Atv0012.Servics;

namespace Zuplae.Aulas.Atv0012.Web.Controllers
{
    public class EnderecoController : Controller
    {
        private readonly EnderecoService _enderecoService;

        public EnderecoController(EnderecoService enderecoService)
        {
            _enderecoService = enderecoService;
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
        public IActionResult Create(Endereco model)
        {
            var endereco = _enderecoService.Cadastrar(model);
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
            var endereco = _enderecoService.ListarPorId(id);
            if (endereco == null)
            {
                return NotFound();
            }
            return View(endereco);
        }
        [HttpPost]
        public IActionResult Edit(Endereco model)
        {
            var result = _enderecoService.Editar(model);
            if (result)
            {
                return RedirectToAction("List");
            }
            return View();
        }


    }
}
