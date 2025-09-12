// See https://aka.ms/new-console-template for more information

using System.Reflection.Metadata;
using Zuplae.Aulas.Atv0012.ConsoleApp;
using Zuplae.Aulas.Atv0012.Models;
using Zuplae.Aulas.Atv0012.Servics;



Console.WriteLine("-------------------------------------------- Sistema de Cadastro da ATV0012 --------------------------------------------");

Console.WriteLine("Escolha uma das opções do menu abaixo: ");
Console.WriteLine("\t1 - Endereço");
Console.WriteLine("\t2 - Fornecedor");
Console.WriteLine("\t3 - Produto");
Console.WriteLine("\t4 - Sair");
Console.Write("Digite o número da opção desejada: ");

int opcao = Convert.ToInt32(Console.ReadLine());

switch (opcao)
{
    case 1:
        
        TelaEndereco telaEndereco = new TelaEndereco();
        telaEndereco.ExecutarMenu();

        break;
    case 2:
        TelaFornecedor telaFornecedor = new TelaFornecedor();
        telaFornecedor.ExecutarMenu();

        break;
    case 3:
        TelaProduto telaProduto = new TelaProduto();
        telaProduto.ExecutarMenu();

        break;
    case 4:
        Console.WriteLine("Saindo do sistema...");
        break;
    default:
        Console.WriteLine("Opção inválida. Por favor, escolha uma opção válida.");
        break;
}




