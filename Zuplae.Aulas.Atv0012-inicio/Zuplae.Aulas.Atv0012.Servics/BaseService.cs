using Microsoft.EntityFrameworkCore;
using Zuplae.Aulas.Atv0012.Data;
using Zuplae.Aulas.Atv0012.Models;

namespace Zuplae.Aulas.Atv0012.Servics
{
    public class BaseService<M> : IService<M> where M : BaseModel, new()
    {
        #region Propriedades
        private readonly OrganizerContext _context;
        private M modelOriginal = new ();
        #endregion
        public BaseService(OrganizerContext context)
        {
            _context = context;
        }
        #region Cadastrar
        public virtual int Cadastrar(M model)
        {
                _context.Add(model);
                _context.SaveChanges();
            return model.Id;
        }
        #endregion

        #region Editar
            public virtual bool Editar(M model)
            {
                var modelOriginal = ObterPorId(model.Id);

            if (modelOriginal != null)
                {
                    _context.Entry(modelOriginal).CurrentValues.SetValues(model);
                    _context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            
            }
        #endregion

        #region Listar
            public virtual List<M> Listar()
            {
                return _context.Set<M>().ToList();
            }
        #endregion

        #region ListarPorId
            public M ListarPorId(int id) 
            {
                this.modelOriginal = this.ObterPorId(id);
                return this.modelOriginal;
            }
        #endregion

        #region Deletar
            public bool Deletar(int id)
            {
                this.modelOriginal = this.ObterPorId(id);
                if (this.modelOriginal != null)
                {
                    _context.Set<M>().Remove(this.modelOriginal);
                    _context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        #endregion

        #region Metodos Auxiliares
        private M ObterPorId(int id)
        {
            return _context.Set<M>().FirstOrDefault(e => e.Id == id);
        }
        #endregion
    }
}
