using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using Zuplae.Aulas.Atv0012.Models;
using Zuplae.Aulas.Atv0012.Servics;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Zuplae.Aulas.Atv0012.ConsoleApp
{
    internal class TelaFornecedor
    {
        #region Atributos
            private FornecedorService fornecedorService = new FornecedorService();
            private EnderecoService enderecoService = new EnderecoService();
        #endregion

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
                Console.WriteLine("================ Modulo de Fornecedor ======================");
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
                        return;
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
            private void Cadastrar()
            {
                Console.WriteLine("Digite Razão Social:");
                string razaoSocial = Console.ReadLine();

                Console.WriteLine("Digite CNPJ:");
                string cnpj = Console.ReadLine();

                Console.WriteLine("\nDigite o ID do Endereço:");
                int idEndereco = Convert.ToInt32(Console.ReadLine());
                var enderecoSelecionado = enderecoService.ListarPorId(idEndereco);
                if (enderecoSelecionado == null)
                {
                    Console.WriteLine("Endereço não encontrado. Por favor, cadastre um endereço primeiro.");
                    return;
                }

                int idFornecedor = fornecedorService.Cadastrar(razaoSocial, cnpj, enderecoSelecionado);

                Console.WriteLine($"\nFornecedor cadastrado com sucesso!\nID: {idFornecedor}" +
                $" - Razão Social: {razaoSocial} - CNPJ: {cnpj} - Endereço: {enderecoSelecionado}");

            }
        #endregion

        #region Editar
            private void Editar()
        {
            // Implementar lógica de edição
        }
        #endregion

        #region Listar
            private void Listar()
            {
                // Implementar lógica de listagem
            }
        #endregion

        #region ListarPorId
        private void ListarPorId()
        {
            Console.WriteLine("Digite o ID do Fornecedor que deseja listar:");
            int id = Convert.ToInt32(Console.ReadLine());
            fornecedorService.ListarPorId(id);
            BuscarEnderecoId(id);
        }
        #endregion

        #region Deletar
        private void Deletar()
            {
                // Implementar lógica de deleção
            }
        #endregion

        #region BuscarEnderecoId
        private Endereco BuscarEnderecoId(int id)
        {
            Endereco endereco = enderecoService.ListarPorId(id);
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
