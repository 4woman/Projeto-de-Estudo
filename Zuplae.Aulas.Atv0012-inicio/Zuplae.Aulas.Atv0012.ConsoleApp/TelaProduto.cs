using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using Zuplae.Aulas.Atv0012.Models;
using Zuplae.Aulas.Atv0012.Servics;

namespace Zuplae.Aulas.Atv0012.ConsoleApp
{
    internal class TelaProduto
    {
        #region Atributos
        private BaseService enderecoService = new BaseService();
        private FornecedorService fornecedorService = new FornecedorService();
        private ProdutoService produtoService = new ProdutoService();
        #endregion

        #region ExecutarMenu
        public void ExecutarMenu()
        {
            ExibirMensagem();
            ExibirMenu();
        }
        #endregion

        #region Modulos
        private void ExibirMensagem()
        {
            Console.Clear();
            Console.WriteLine("================ Modulo de Produto ======================");
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

            Console.WriteLine("Nome do Produto: ");
            string nomeProduto = Console.ReadLine();

            Console.WriteLine("Preço do Produto: ");
            decimal preco = Convert.ToDecimal(Console.ReadLine());


            Console.Write("\nDigite o ID do Fornecedor: ");
            int idFornecedor = Convert.ToInt32(Console.ReadLine());
            var fornSelecionado = fornecedorService.ListarPorId(idFornecedor);
            if (fornSelecionado == null)
            {
                Console.WriteLine("Endereço não encontrado. Por favor, cadastre um Fornecedor primeiro.");
                return;
            }

            int idProduto = produtoService.Cadastrar(nomeProduto, preco, fornSelecionado);

            Console.WriteLine($"\nProduto cadastrado com sucesso!");
            Console.WriteLine($"ID: {idProduto} - Nome: {nomeProduto} - Preço: R${preco:F2} - Fornecedor: {fornSelecionado}");
        }
        #endregion

        #region Editar
        private void Editar()
        {

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
            Console.WriteLine("Digite o ID do Produto que deseja listar:");
            int id = Convert.ToInt32(Console.ReadLine());
            fornecedorService.ListarPorId(id);
            BuscarEnderecoId(id);
        }
        #endregion

        #region Deletar
        private void Deletar()
        {
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
