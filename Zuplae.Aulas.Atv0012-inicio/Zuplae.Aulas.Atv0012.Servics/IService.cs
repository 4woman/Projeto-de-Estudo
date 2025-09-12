using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zuplae.Aulas.Atv0012.Models;

namespace Zuplae.Aulas.Atv0012.Servics
{
    public interface IService <T>
    {
        
        int Cadastrar(T model);
        bool Editar(T model);
        List<T> Listar();
        T ListarPorId(int id);
        bool Deletar(int id);

       
     
    }
}
