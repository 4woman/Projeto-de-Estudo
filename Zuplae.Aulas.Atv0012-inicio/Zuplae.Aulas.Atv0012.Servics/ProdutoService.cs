using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zuplae.Aulas.Atv0012.Models;

namespace Zuplae.Aulas.Atv0012.Servics
{
    public class ProdutoService : IProdutoService
    {
        #region Atributos
            private static List<Produto> produtos = new List<Produto>();
            private Produto produto = new Produto();
        #endregion

        #region Cadastrar
            public int Cadastrar(string nomeProduto, decimal preco, Fornecedor fornecedor)
            {
                
                this.produto = CriarProduto(nomeProduto, preco, fornecedor);
                produtos.Add(this.produto);
                int id = this.produto.GetId();
                return id;
            }
        #endregion

        #region Editar
            public bool Editar(int id, string nomeProduto, decimal preco, Fornecedor fornecedor)
            {  
                this.produto = ListarPorId(id);
                if (this.produto != null)
                {
                    CriarProduto(nomeProduto, preco, fornecedor);
                    return true;
                }
                else
                {
                    return false;
                }
            }
        #endregion

        #region Listar
            public List<Produto> Listar()
            {
                return produtos;
            }
        #endregion

        #region ListarPorId
        public Produto ListarPorId(int id)
        {
            this.produto = ObterProdutoPorId(id);
            return this.produto;
        }
        #endregion

        #region Deletar
        public bool Deletar(int id)
        {
            this.produto = this.ListarPorId(id);
            if (this.produto != null)
            {
                produtos.Remove(this.produto);
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region Metodos Auxiliares
            private Produto ObterProdutoPorId(int id)
            {
                return produtos.FirstOrDefault(p => p.GetId() == id);
            }

            private Produto CriarProduto(string nomeProduto, decimal preco, Fornecedor fornecedor)
            {
                Produto produto = new Produto();
                produto.NomeProduto = nomeProduto;
                produto.Preco = preco;
                produto.Fornecedores.Add(fornecedor);
                return produto;
            }

        #endregion


    }
}
