using Microsoft.AspNetCore.Mvc;
using Zuplae.Aulas.Atv0012.UserAccess;
using Zuplae.Aulas.Atv0012.Servics;
using Zuplae.Aulas.Atv0012.Web.Helper;

namespace Zuplae.Aulas.Atv0012.Web.Controllers
{
    public class LoginController : Controller
    {
        private readonly UsuarioService _usuarioService;
        private readonly ISessao _sessao;
        private readonly IEmail _email;

        public LoginController(UsuarioService usuarioService, ISessao sessao, IEmail email)
        {
            _usuarioService = usuarioService;
            _sessao = sessao;
            _email = email;
        }
        public IActionResult Index()
        {
            //se usuario estiver logado, redirecionar para a home
            if (_sessao.BuscarSessaoDoUsuario() != null) return RedirectToAction("Index", "Home");
            return View();
        }

        public IActionResult RedefinirSenha()
        {
            return View();
        }

        public IActionResult Sair()
        {
            _sessao.RemoverSessaoUsuario();
            return RedirectToAction("Index", "Login");
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

        [HttpPost]
        public IActionResult EnviarLinkParaRedefinirSenha(RedefinirSenha redefinirSenha)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Usuario usuario = _usuarioService.BuscarPorEmailELogin(redefinirSenha.Email, redefinirSenha.Login);
                    if (usuario != null)
                    {
                        string novaSenha = usuario.GerarNovaSenha();
                        
                        string mensagem = $"Sua nova senha é: {novaSenha}";
                        bool emailEnviado = _email.Enviar(usuario.Email, "Sistema Frota .NET - Nova Senha", mensagem);
                        if (emailEnviado) 
                        {
                            _usuarioService.Editar(usuario);
                            TempData["MensagemSucesso"] = $"Enviamos para seu email cadastrar uma nova senha.";
                        }
                        else
                        {
                            TempData["MensagemErro"] = $"Não conseguimos enviar e-mail. Por favor, tente novamente.";
                        }
                            return RedirectToAction("Index", "Login");
                    }

                    TempData["MensagemErro"] = $"Não conseguimos redefinir sua senha. Por favor, verifique os dados informados.";
                }
                return View("Index");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos redefinir sua senha, tente novamente, detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }

        }
    }
}




