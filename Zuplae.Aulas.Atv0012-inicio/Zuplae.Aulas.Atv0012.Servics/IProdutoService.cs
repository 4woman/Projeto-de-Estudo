using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zuplae.Aulas.Atv0012.Models;

namespace Zuplae.Aulas.Atv0012.Servics
{
    public interface IProdutoService
    {
        int Cadastrar(string nomeProduto, decimal preco, Fornecedor fornecedor);
        bool Editar(int id, string nomeProduto, decimal preco, Fornecedor fornecedor);
        List<Produto> Listar();
        Produto ListarPorId(int id);
        bool Deletar(int id);
    }
}
