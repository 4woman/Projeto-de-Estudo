using Microsoft.AspNetCore.Mvc;
using Zuplae.Aulas.Atv0012.Models;
using Zuplae.Aulas.Atv0012.Servics;
using Zuplae.Aulas.Atv0012.Web.Helper;

namespace Zuplae.Aulas.Atv0012.Web.Controllers
{
    public class LoginController : Controller
    {
        private readonly UsuarioService _usuarioService;
        private readonly ISessao _sessao;

        public LoginController(UsuarioService usuarioService, ISessao sessao)
        {
            _usuarioService = usuarioService;
            _sessao = sessao;
        }
        public IActionResult Index()
        {
            //se usuario estiver logado, redirecionar para a home
            if (_sessao.BuscarSessaoDoUsuario() != null) return RedirectToAction("Index", "Home");
            return View();
        }

        

        [HttpPost]
        public IActionResult Entrar(LoginUsuario loginModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Usuario usuario = _usuarioService.BuscarPorLogin(loginModel.Login);
                    if (usuario != null)
                    {
                        if (usuario.SenhaValida(loginModel.Senha))
                        {
                            _sessao.CriarSessaoDoUsuario(usuario);
                            return RedirectToAction("Index", "Home");

                        }

                        TempData["MensagemErro"] = $"Usuário e/ou senha inválida. Tente novamente.";
                    }
                    TempData["MensagemErro"] = $"Usuário e/ou senha inválida. Tente novamente.";
                
                }
                return View("Index");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos realizar seu login, tente novamente, detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
