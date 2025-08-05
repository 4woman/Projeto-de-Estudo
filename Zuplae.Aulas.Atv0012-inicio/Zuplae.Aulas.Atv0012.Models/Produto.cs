using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zuplae.Aulas.Atv0012.Models
{
    public class Produto : BaseModel
    {
        #region Propriedades
        private string _nomeProduto;
        public string NomeProduto { 
            get
            {
                return _nomeProduto.ToUpper();
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("O nome do produto não pode ser vazio ou conter apenas espaços.");
                }
                _nomeProduto = value;
            }
        }

        public string CodigoProduto { get; private set; }
        
        private decimal _preco;
        public decimal Preco { 
            get
            {
                return _preco;
            }
            set
            {
                if (value < 0 || value > 100.00m)
                {
                    throw new Exception("O preço deve estar entre R$0,00 e R$100.00.");
                }
                _preco = value;
            }
        }
        public List<Fornecedor> Fornecedores { get; set; }
        
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
            this.Fornecedores.Add(fornecedor);

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
