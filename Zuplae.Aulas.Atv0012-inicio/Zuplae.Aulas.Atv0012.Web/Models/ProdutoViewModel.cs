using Microsoft.AspNetCore.Mvc.Rendering;
using Zuplae.Aulas.Atv0012.Models;

namespace Zuplae.Aulas.Atv0012.Web.Models
{
    public class ProdutoViewModel
    {
        public Produto Produto { get; set; }

        public List<SelectListItem> Fornecedores { get; set; }
    }
}
