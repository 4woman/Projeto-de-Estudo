using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zuplae.Aulas.Atv0012.Models
{
    public class Fornecedor : BaseModel
    {
        #region Propriedades
        
        public string RazaoSocial { get; set; }
            
        public string CNPJ { get; set; }
        public int? EnderecoId { get; set; }
        public Endereco Endereco { get; set; }
        

        #endregion

        #region Construtor
        public Fornecedor() { }

        public Fornecedor(string razaoSocial, string cnpj, Endereco endereco)
        {
            this.RazaoSocial = razaoSocial;
            this.CNPJ = cnpj;
            this.Endereco = endereco;
        }
        #endregion

        #region Metodo
        public override string ToString()
        {
            return $" {RazaoSocial}, CNPJ: {CNPJ}\n {Endereco}";
        }
        #endregion

    }
}
