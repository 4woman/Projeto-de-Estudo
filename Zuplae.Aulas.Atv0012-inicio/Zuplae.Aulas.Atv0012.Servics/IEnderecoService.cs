using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zuplae.Aulas.Atv0012.Models;

namespace Zuplae.Aulas.Atv0012.Servics
{
    public interface IEnderecoService
    {
        int Cadastrar(string logradouro, string numero, string bairro, string cidade, string estado, string cep);
        bool Editar(int id, string logradouro, string numero, string bairro, string cidade, string estado, string cep);
        List<Endereco> Listar();
        Endereco ListarPorId(int id);
        bool Deletar(int id);
     
    }
}
