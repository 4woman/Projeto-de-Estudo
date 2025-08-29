using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zuplae.Aulas.Atv0012.Data;
using Zuplae.Aulas.Atv0012.Models;

namespace Zuplae.Aulas.Atv0012.Servics
{
    public class EnderecoService : BaseService<Endereco>
    {
        public EnderecoService(OrganizerContext context) : base(context)
        {}
    }
}
