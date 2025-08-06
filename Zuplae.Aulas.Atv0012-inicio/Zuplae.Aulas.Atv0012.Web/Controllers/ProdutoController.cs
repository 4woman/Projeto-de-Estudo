using Microsoft.AspNetCore.Mvc;
using Zuplae.Aulas.Atv0012.Models;
using Zuplae.Aulas.Atv0012.Servics;

namespace Zuplae.Aulas.Atv0012.Web.Controllers
{
    public class ProdutoController : BaseController<Produto>
    {
        public ProdutoController(IService<Produto> service) : base(service)
        {
        }


    }
}
