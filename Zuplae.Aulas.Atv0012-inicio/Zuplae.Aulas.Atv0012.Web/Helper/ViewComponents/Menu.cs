using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Zuplae.Aulas.Atv0012.Models;

namespace Zuplae.Aulas.Atv0012.Web.Helper.ViewComponents
{
    public class Menu : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            string sessaoUsuario = HttpContext.Session.GetString("sessaoUsuarioLogado");
            if (string.IsNullOrEmpty(sessaoUsuario)) return null;

            Usuario usuario = JsonConvert.DeserializeObject<Usuario>(sessaoUsuario);
            return View(usuario);
        }
    }
}
