using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zuplae.Aulas.Atv0012.Models;

namespace Zuplae.Aulas.Atv0012.Servics
{
    public class FornecedorService : IFornecedorService
    {
        #region Atributos
            private static List<Fornecedor> fornecedores = new List<Fornecedor>();
            private Fornecedor fornecedor = new Fornecedor();
        #endregion

        #region Cadastrar
            public int Cadastrar(string razaoSocial, string cnpj, Endereco endereco)
            {

                this.fornecedor = CriarFornecedor(razaoSocial, cnpj, endereco);
                fornecedores.Add(this.fornecedor);
                int id = this.fornecedor.GetId();
                return id;
            }
        #endregion

        #region Editar
            public bool Editar(int id, string razaoSocial, string cnpj, Endereco endereco)
            {
                this.fornecedor = this.ListarPorId(id);
                if (this.fornecedor != null)
                {
                    this.CriarFornecedor(razaoSocial, cnpj, endereco);
                    return true;
                }
                else
                {
                    return false;
                }

            }
        #endregion

        #region Listar
            public List<Fornecedor> Listar()
            {
                return fornecedores;
            }
        #endregion

        #region ListarPorId
            public Fornecedor ListarPorId(int id)
            {
                this.fornecedor = ObterFornecedorPorId(id);
                return this.fornecedor;
            }
        #endregion

        #region Deletar
            public bool Deletar(int id)
            {
                this.fornecedor = this.ListarPorId(id);
                if (this.fornecedor != null)
                {
                    fornecedores.Remove(this.fornecedor);
                    return true;
                }
                else
                {
                    return false;
                }
            }
        #endregion

        #region Metodos Auxiliares

            private Fornecedor ObterFornecedorPorId(int id)
            {
                return fornecedores.Find(f => f.GetId() == id);
            }
            private Fornecedor CriarFornecedor(string razaoSocial, string cnpj, Endereco endereco)
            {
                this.fornecedor.RazaoSocial = razaoSocial;
                this.fornecedor.CNPJ = cnpj;
                this.fornecedor.Endereco = endereco;
                return this.fornecedor;
            }
        #endregion



    }
}
