using Zuplae.Aulas.Atv0012.Models;

namespace Zuplae.Aulas.Atv0012.Web.Helper
{
    public interface ISessao
    {
        void CriarSessaoDoUsuario(Usuario usuario);
        void RemoverSessaoUsuario();
        Usuario BuscarSessaoDoUsuario();
    }
}
