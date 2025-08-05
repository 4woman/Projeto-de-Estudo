using Zuplae.Aulas.Atv0012.Models;

namespace Zuplae.Aulas.Atv0012.Servics
{
    public class EnderecoService : IEnderecoService
    {
        #region Propriedades
            private static List<Endereco> enderecos = new List<Endereco>();
            private Endereco endereco = new Endereco();
        #endregion

        #region Cadastrar
            public int Cadastrar(string logradouro, string numero, string bairro, string cidade, string estado, string cep)
            {
                this.endereco = CriarEndereco(logradouro, numero, bairro, cidade, estado, cep);
                enderecos.Add(this.endereco);
                int id = this.endereco.GetId();
                return id;


            }
        #endregion

        #region Editar
            public bool Editar(int id, string logradouro, string numero, string bairro, string cidade, string estado, string cep)
            {
                this.endereco = this.ObterEnderecoPorId(id);
                if (this.endereco != null)
                {
                    CriarEndereco(logradouro, numero, bairro, cidade, estado, cep);
                    return true;
                }
                else
                {
                    return false;
                }
            
            }
        #endregion

        #region Listar
            public List<Endereco> Listar()
            {
                return enderecos;
            }
        #endregion

        #region ListarPorId
            public Endereco ListarPorId(int id) 
            {
                this.endereco = this.ObterEnderecoPorId(id);
                return this.endereco;
            }
        #endregion

        #region Deletar
            public bool Deletar(int id)
            {
                this.endereco = this.ListarPorId(id);
                if (this.endereco != null)
                {
                    enderecos.Remove(this.endereco);
                    return true;
                }
                else
                {
                    return false;
                }
            }
        #endregion

        #region Metodos Auxiliares
            private Endereco ObterEnderecoPorId(int id)
            {
                return enderecos.FirstOrDefault(e => e.GetId() == id);
            }

            private Endereco CriarEndereco(string logradouro, string numero, string bairro, string cidade, string estado, string cep)
            {
                this.endereco.Logradouro = logradouro;
                this.endereco.Numero = numero;
                this.endereco.Bairro = bairro;
                this.endereco.Cidade = cidade;
                this.endereco.Estado = estado;
                this.endereco.Cep = cep;
                return this.endereco;
            }
        #endregion
    }
}
