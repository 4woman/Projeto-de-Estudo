using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zuplae.Aulas.Atv0012.Data;
using Zuplae.Aulas.Atv0012.Models;

namespace Zuplae.Aulas.Atv0012.Servics
{
    public class UsuarioService : BaseService<Usuario>
    {
        public UsuarioService(OrganizerContext context) : base(context)
        {
        }

        public override int Cadastrar(Usuario model)
        {
            model.DataCadastro = DateTime.Now;
            return base.Cadastrar(model);
        }
    }
}
