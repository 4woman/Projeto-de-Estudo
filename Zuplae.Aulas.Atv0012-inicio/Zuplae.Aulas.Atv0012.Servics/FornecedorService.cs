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
    public class FornecedorService : BaseService<Fornecedor>
    {
        private readonly OrganizerContext _context;

        public FornecedorService(OrganizerContext context) : base(context)
        {
            _context = context;
        }


        public override List<Fornecedor> Listar()
        {
            return _context.Fornecedores.Include(f => f.Endereco).ToList();
        }
    }
}
