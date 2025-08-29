using System.Runtime.ConstrainedExecution;

namespace Zuplae.Aulas.Atv0012.Models
{
    public class Endereco : BaseModel
    {
        #region Propriedades
        public string Logradouro { get; set; }
        public string Numero { get; set; }

        public string Bairro { get; set; }
        public string Cidade { get; set; }

        private string _estado;
        public string Estado 
        { 
            get { return _estado; }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length != 2)
                {
                    throw new Exception("Estado inválido. Deve ter 2 caracteres.");
                }
                this._estado = value;
        }   }

        private string _cep;
        public string Cep
        {
            get { return _cep; }
            set {
                if (string.IsNullOrWhiteSpace(value) || value.Length != 8 || !long.TryParse(value, out _))
                {
                    throw new Exception("CEP inválido. Deve ter 8 caracteres numéricos.");
                }
                this._cep = value;
            }
        }
        #endregion

        #region Construtores
        public Endereco() { }

        public Endereco(string logradouro, string numero, string bairro, string cidade, string estado, string cep)
        {
            this.Logradouro = logradouro;
            this.Numero = numero;
            this.Bairro = bairro;
            this.Cidade = cidade;
            this.Estado = estado;
            this.Cep = cep;
        }

        #endregion


        #region Metodo
        public override string ToString()
        {
            return $"Rua: {Logradouro}, {Numero} - {Bairro}, {Cidade} - {Estado}, CEP: {Cep}";
        }
        #endregion

    } 
}
