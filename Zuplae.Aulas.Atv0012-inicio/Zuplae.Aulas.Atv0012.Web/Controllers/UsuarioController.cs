using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Zuplae.Aulas.Atv0012.Models;
using Zuplae.Aulas.Atv0012.Servics;
using Zuplae.Aulas.Atv0012.Web.Filters;
using Zuplae.Aulas.Atv0012.Web.Models;

namespace Zuplae.Aulas.Atv0012.Web.Controllers
{
    [PaginaRestritaSomenteAdmin]
    public class UsuarioController : Controller
    {
        private UsuarioService _usuarioService;
       

        public UsuarioController(UsuarioService service)
        {
            _usuarioService = service;
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
        public IActionResult Create(Usuario model) // Auto Binding do Model
        {
            var id = _usuarioService.Cadastrar(model);
            return RedirectToAction("List");
        }
        [HttpGet]
        public IActionResult List()
        {
            var usuarios = _usuarioService.Listar();
            return View(usuarios);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var usuario = _usuarioService.ListarPorId(id);
            if (usuario == null)
                return NotFound();

            // converte para UsuarioSemSenhaModel
            var model = new UsuarioSemSenhaModel
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                Login = usuario.Login,
                Email = usuario.Email,
                Perfil = usuario.Perfil
            };

            return View(model); // envia o ViewModel correto
        }

        [HttpPost]
        public IActionResult Edit(UsuarioSemSenhaModel model)
        {
            if (ModelState.IsValid)
            {
                var usuarioOriginal = _usuarioService.ListarPorId(model.Id);
                if (usuarioOriginal == null)
                    return NotFound();

                // Atualiza apenas os campos editáveis
                usuarioOriginal.Nome = model.Nome;
                usuarioOriginal.Login = model.Login;
                usuarioOriginal.Email = model.Email;
                usuarioOriginal.Perfil = model.Perfil;

                _usuarioService.Editar(usuarioOriginal);

                return RedirectToAction("List");
            }

            return View(model);
        }



        public IActionResult Delete(int id)
        {
            _usuarioService.Deletar(id);
            return RedirectToAction("List");
        }
    }
}

