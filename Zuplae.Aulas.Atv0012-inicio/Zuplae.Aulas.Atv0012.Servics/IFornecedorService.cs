using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zuplae.Aulas.Atv0012.Models;

namespace Zuplae.Aulas.Atv0012.Servics
{
    public interface IFornecedorService
    {
        int Cadastrar(string razaoSocial, string cnpj, Endereco endereco);
        bool Editar(int ind, string razaoSocial, string cnpj, Endereco endereco);
        List<Fornecedor> Listar();
        Fornecedor ListarPorId(int id);
        bool Deletar(int id);
    }
}
