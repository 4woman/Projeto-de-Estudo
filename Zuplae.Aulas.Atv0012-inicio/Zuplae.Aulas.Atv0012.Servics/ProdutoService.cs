using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Zuplae.Aulas.Atv0012.Data;
using Zuplae.Aulas.Atv0012.Models;

namespace Zuplae.Aulas.Atv0012.Servics
{
    public class ProdutoService : BaseService<Produto>
    {
        private readonly OrganizerContext _context;

        public ProdutoService(OrganizerContext context) : base(context)
        {
            _context = context;
        }


        public override List<Produto> Listar()
        {
            return _context.Produtos.Include(p => p.Fornecedor).ToList();
        }
    }
}
