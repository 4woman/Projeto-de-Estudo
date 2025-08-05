using Microsoft.AspNetCore.Mvc;
using Zuplae.Aulas.Atv0012.Servics;

namespace Zuplae.Aulas.Atv0012.Web.Controllers
{
    public class EnderecoController : Controller
    {
        private readonly IEnderecoService _enderecoService;

        public EnderecoController(IEnderecoService enderecoService)
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
        public IActionResult Create(string logradouro, string numero, string bairro, string cidade, string estado, string cep)
        {
            var endereco = _enderecoService.Cadastrar(logradouro, numero, bairro, cidade, estado, cep);
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
        public IActionResult Edit(int id, string logradouro, string numero, string bairro, string cidade, string estado, string cep)
        {
            var result = _enderecoService.Editar(id, logradouro, numero, bairro, cidade, estado, cep);
            if (result)
            {
                return RedirectToAction("List");
            }
            return View();
        }


    }
}
