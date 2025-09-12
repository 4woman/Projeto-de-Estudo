using Microsoft.AspNetCore.Mvc.Rendering;
using Zuplae.Aulas.Atv0012.Models;

namespace Zuplae.Aulas.Atv0012.Web.Models
{
    public class FornecedorViewModel
    {
        public Fornecedor Fornecedor { get; set; }
        
        public List<SelectListItem> Enderecos { get; set; }
    }
}
