using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Zuplae.Aulas.Atv0012.Models;
using Zuplae.Aulas.Atv0012.Servics;
using Zuplae.Aulas.Atv0012.Web.Models;

namespace Zuplae.Aulas.Atv0012.Web.Controllers
{
    public class ProdutoController : Controller
    {
        private FornecedorService _fornecedorService;
        private ProdutoService _produtoService;

        public ProdutoController(FornecedorService fornecedorService, ProdutoService produtoService)
        {
            _fornecedorService = fornecedorService;
            _produtoService = produtoService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {   
            //cria a view model
            ProdutoViewModel viewModel = new ProdutoViewModel();

            //inicializa o produto vazio
            viewModel.Produto = new Produto();

            //busca todos os fornecedores
            List<Fornecedor> fornecedores = _fornecedorService.Listar();

            //prepara a lista para dropdown
            viewModel.Fornecedores = new List<SelectListItem>();

            //transforma cada fornecedor em um seleção de listas com valor = Id e texto = ToString
            foreach (var item in fornecedores)
            {
                SelectListItem itemSelect = new SelectListItem();
                itemSelect.Value = item.Id.ToString();
                itemSelect.Text = item.ToString();

                viewModel.Fornecedores.Add(itemSelect);
            }

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Create(ProdutoViewModel viewModel)
        {
            //extrair o produto do viewModel
            Produto model = viewModel.Produto;
            
            //busca o fornecedor completo pelo Id selecionado
            Fornecedor fornecedor = _fornecedorService.ListarPorId(model.Fornecedor.Id);

            //associa o fornecedor completo ao produto
            model.Fornecedor = fornecedor;

            //salva o produto com o fornecedor
            var id = _produtoService.Cadastrar(model);

            //redireciona para a lista de produtos
            return RedirectToAction("List");
        }

        #region Listar Produtos
        [HttpGet]
        public IActionResult List()
        {
            var enderecos = _produtoService.Listar();
            return View(enderecos);
        }

        #endregion


        [HttpGet]
        public IActionResult Edit(int id)
        {
            //busca produto no banco
            var produto = _produtoService.ListarPorId(id);

            //monta viewModel
            ProdutoViewModel viewModel = new ProdutoViewModel();
            viewModel.Produto = produto;

            //busca fornecedor para o dropdown
            List<Fornecedor> fornecedores = _fornecedorService.Listar();
            viewModel.Fornecedores = new List<SelectListItem>();

            foreach (var item in fornecedores)
            {
                SelectListItem itemSelect = new SelectListItem();
                itemSelect.Value = item.Id.ToString();
                itemSelect.Text = item.ToString();

                viewModel.Fornecedores.Add(itemSelect);
            }

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Edit(int id, ProdutoViewModel viewModel)
        {
            var produto = _produtoService.ListarPorId(id);

            //atualizar dados do produto
            produto.NomeProduto = viewModel.Produto.NomeProduto;
            produto.Preco = viewModel.Produto.Preco;

            //atualizar o fornecedor
            var novoFornecedor = _fornecedorService.ListarPorId(viewModel.Produto.Fornecedor.Id);

            //substitui o fornecedor antigo pelo novo
            produto.Fornecedor = novoFornecedor;
            _produtoService.Editar(produto);

            return RedirectToAction("List");

        }

        public IActionResult Delete(int id)
        {
            _produtoService.Deletar(id);
            return RedirectToAction("List");
        }

        
    }
}
