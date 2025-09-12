using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zuplae.Aulas.Atv0012.Models;
using Zuplae.Aulas.Atv0012.Servics;

namespace Zuplae.Aulas.Atv0012.ConsoleApp
{
    public class TelaEndereco
    {
        #region Atributos
        private EnderecoService _enderecoService;

        #endregion
        public TelaEndereco()
        { }
        public TelaEndereco(EnderecoService endereco)
        {
            _enderecoService = endereco;
        }

        #region ExecutarMenu
        public void ExecutarMenu()
        {     
                ExibirMensagem();
                ExibirMenu();
     
        }
        #endregion

        #region Modulo
        private void ExibirMensagem()
        {
            Console.Clear();
            Console.WriteLine("================ Modulo de Endereço ======================");
            Console.WriteLine("Escolha uma das opções do menu abaixo:");
            Console.WriteLine("\t1 -  Cadastrar");
            Console.WriteLine("\t2 -  Editar");
            Console.WriteLine("\t3 -  Listar");
            Console.WriteLine("\t4 -  Listar por Id");
            Console.WriteLine("\t5 -  Deletar");
            Console.WriteLine("\t6 -  Voltar ao menu principal");
            Console.Write("Digite o número da opção desejada: ");
        }
        #endregion

        #region Menu
        private void ExibirMenu()
        {
            int opcao = Convert.ToInt32(Console.ReadLine());
            switch (opcao)
            {
                case 1:
                    Cadastrar();
                    break;
                case 2:
                    Editar();
                    break;
                case 3:
                    Listar();
                    break;
                case 4:
                    ListarPorId();
                    break;
                case 5:
                    Deletar();
                    break;
                case 6:
                    VoltarAoMenuPrincipal();
                    break;
                default:
                    Console.WriteLine("Opção inválida, tente novamente.");
                    ExecutarMenu();
                    break;
            }
            
        }
        #endregion

        #region VoltarAoMenu
        private void VoltarAoMenuPrincipal()
        {
            Console.WriteLine("Voltando ao menu principal...");
            Console.ReadKey();
            ExecutarMenu();
        }
        #endregion

        #region Cadastrar
        public void Cadastrar()
        {
            Console.WriteLine("Digite Logradouro:");
            string logradouro = Console.ReadLine();

            Console.WriteLine("Digite Número:");
            string numero = Console.ReadLine();

            Console.WriteLine("Digite Bairro:");
            string bairro = Console.ReadLine();

            Console.WriteLine("Digite Cidade:");
            string cidade = Console.ReadLine();

            Console.WriteLine("Digite Estado:");
            string estado = Console.ReadLine();

            Console.WriteLine("Digite CEP:");
            string cep = Console.ReadLine();

            var endereco = new Endereco
            {
                Logradouro = logradouro,
                Numero = numero,
                Bairro = bairro,
                Cidade = cidade,
                Estado = estado,
                Cep = cep
            };

            
            int idEndereco = _enderecoService.Cadastrar(endereco);

            Console.WriteLine($"Endereço Cadastrado ID: {idEndereco} - Rua {logradouro} - N°: {numero}");
        }

        #endregion

        #region Editar
        private void Editar()
        {
            Console.WriteLine("Digite o ID do endereço que deseja editar:");
            int id = Convert.ToInt32(Console.ReadLine());
            _enderecoService.ListarPorId(id);

        }
        #endregion

        #region Listar
        private void Listar()
        {

        }
        #endregion

        #region ListarPorId
        private void ListarPorId()
        {
            Console.WriteLine("Digite o ID do endereço que deseja listar:");
            int id = Convert.ToInt32(Console.ReadLine());
            _enderecoService.ListarPorId(id);
            BuscarEnderecoId(id);
        }
        #endregion

        #region Deletar
        private void Deletar()
        { }
        #endregion

        #region Metodos Auxiliares
        private Endereco BuscarEnderecoId(int id)
        {
            Endereco endereco = _enderecoService.ListarPorId(id);
            if (endereco == null)
            {
                Console.WriteLine("Endereço não encontrado.");
                return null;
            }
            return endereco;
        }

        
        #endregion
    }



}
 
