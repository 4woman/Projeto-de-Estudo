using Microsoft.AspNetCore.Mvc;
using Zuplae.Aulas.Atv0012.Models;
using Zuplae.Aulas.Atv0012.Servics;

namespace Zuplae.Aulas.Atv0012.Web.Controllers
{
    public class FornecedorController : BaseController<Fornecedor>
    {
        public FornecedorController(IService<Fornecedor> service) : base(service)
        {
        }
            
    
      


    }
}
