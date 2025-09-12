using Zuplae.Aulas.Atv0012.Data;
using Zuplae.Aulas.Atv0012.UserAccess;

namespace Zuplae.Aulas.Atv0012.Servics
{
    public class UsuarioService : BaseService<Usuario>
    {   
        private readonly OrganizerContext _context;
        public UsuarioService(OrganizerContext context) : base(context)
        {
            _context = context;
        }

        public override int Cadastrar(Usuario model)
        {
            model.DataCadastro = DateTime.Now;
            model.SetSenhaHash();  
            return base.Cadastrar(model);
        }

        public Usuario BuscarPorLogin(string login)
        {
            return _context.Usuarios.FirstOrDefault(x => x.Login.ToUpper() == login.ToUpper());

        }

        public Usuario BuscarPorEmailELogin(string email, string login)
        {
            return _context.Usuarios.FirstOrDefault(x => x.Email.ToUpper() == email.ToUpper() && x.Login.ToUpper() == login.ToUpper());
        }
    }
}
