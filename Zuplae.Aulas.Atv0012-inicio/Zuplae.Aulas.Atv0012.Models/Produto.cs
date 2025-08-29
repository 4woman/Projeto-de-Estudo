using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zuplae.Aulas.Atv0012.Models
{
    public class Produto : BaseModel
    {
        #region Propriedades
        
        public string NomeProduto { get; set; }
            
        public string CodigoProduto { get; private set; }

        
        public decimal Preco { get; set; }
        public Fornecedor Fornecedor { get; set; }

        #endregion

        #region Contrutores
        public Produto()
        {
            GerarCodigo(); 
        }

        public Produto(string nomeProduto, decimal preco, Fornecedor fornecedor)
        {
            this.NomeProduto = nomeProduto;
            this.Preco = preco;
            this.Fornecedor = fornecedor;

            GerarCodigo(); 
        }
        #endregion
 

        #region Metodos
        public override string ToString()
        {
            return $"Nome do Produto: {NomeProduto}\n codigo do Produto: {CodigoProduto}\n preço: {Preco}\n Fornecedores:";
           
        }

        private void GerarCodigo()
        {
            this.CodigoProduto = "PV_" + Guid.NewGuid().ToString("N").Substring(0, 8).ToUpper();
        }

        #endregion



    }
}
