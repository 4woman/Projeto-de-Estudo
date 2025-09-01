using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zuplae.Aulas.Atv0012.Models
{
    public class Usuario : BaseModel
    {
        public string Nome { get; set; } = string.Empty;
        public string Login { get; set; } 
        public string Email { get; set; } = string.Empty;

        public PerfilEnum Perfil { get; set; }

        public string Senha { get; set; }

        public DateTime DataCadastro { get; set; }

        public DateTime? DataAtualizacao { get; set; }
    }
}
