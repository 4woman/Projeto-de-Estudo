using Zuplae.Aulas.Atv0012.UserAccess;

namespace Zuplae.Aulas.Atv0012.Web.Models
{
    public class UsuarioSemSenhaModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public PerfilEnum Perfil { get; set; }
    }
}
