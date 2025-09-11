using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zuplae.Aulas.Atv0012.Models
{
    public class RedefinirSenha : BaseModel
    {
        [Required(ErrorMessage = "Digite o login")]
        public string Login { get; set; } = string.Empty;

        [Required(ErrorMessage = "Digite o e-mail")]
        public string Email { get; set; } = string.Empty;    }
}
