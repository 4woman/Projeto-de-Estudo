using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zuplae.Aulas.Atv0012.UserAccess
{
    public class LoginUsuario
    {
        [Required(ErrorMessage = "Digite o login")]
        public string Login {  get; set; } = string.Empty;
        [Required(ErrorMessage = "Digite a senha")]
        public string Senha { get; set; } = string.Empty;

    }
}
