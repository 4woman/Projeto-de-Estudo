using Microsoft.AspNetCore.Mvc;
using Zuplae.Aulas.Atv0012.Web.Filters;

namespace Zuplae.Aulas.Atv0012.Web.Controllers
{
    [PaginaParaUsuarioLogado]
    public class RestritoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
