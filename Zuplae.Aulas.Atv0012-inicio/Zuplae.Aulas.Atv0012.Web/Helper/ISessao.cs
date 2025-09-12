using Zuplae.Aulas.Atv0012.UserAccess;

namespace Zuplae.Aulas.Atv0012.Web.Helper
{
    public interface ISessao
    {
        void CriarSessaoDoUsuario(Usuario usuario);
        void RemoverSessaoUsuario();
        Usuario BuscarSessaoDoUsuario();
    }
}
