using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zuplae.Aulas.Atv0012.Web.Helper;



namespace Zuplae.Aulas.Atv0012.Models
{
    public class Usuario : BaseModel
    {
        [Required(ErrorMessage = "Digite o nome do usuário")]
        public string Nome { get; set; } = string.Empty;
        [Required(ErrorMessage = "Digite o login do usuário")]
        public string Login { get; set; } = string.Empty;
        [Required(ErrorMessage = "Digite o e-mail do usuário")]
        [EmailAddress(ErrorMessage ="O e-mail informado não é valido!")]
        public string Email { get; set; } = string.Empty;
        [Required(ErrorMessage = "Informe o perfil")]
        public PerfilEnum Perfil { get; set; }
    
        public string Senha { get; set; } = string.Empty;

        public DateTime DataCadastro { get; set; }

        public DateTime? DataAtualizacao { get; set; }

        public bool SenhaValida(string senha)
        {
            return Senha == senha.GerarHash();
        }

        public void SetSenhaHash()
        {
            Senha = Senha.GerarHash();
        }
    }
}
