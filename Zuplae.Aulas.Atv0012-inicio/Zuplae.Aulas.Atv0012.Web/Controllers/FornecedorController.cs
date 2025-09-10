using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Zuplae.Aulas.Atv0012.Models;
using Zuplae.Aulas.Atv0012.Servics;
using Zuplae.Aulas.Atv0012.Web.Filters;
using Zuplae.Aulas.Atv0012.Web.Models;

namespace Zuplae.Aulas.Atv0012.Web.Controllers
{
    [PaginaParaUsuarioLogado]
    public class FornecedorController : Controller
    {
       private EnderecoService _enderecoService;  
        private FornecedorService _fornecedorService;

        public FornecedorController(EnderecoService enderecoService, FornecedorService fornecedorService)
        {
            _enderecoService = enderecoService;
            _fornecedorService = fornecedorService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            FornecedorViewModel viewModel = new FornecedorViewModel();   //cria a view model
            viewModel.Fornecedor = new Fornecedor();                    // inicializa o fornecedor vazio

            List<Endereco> enderecos = _enderecoService.Listar();        //busca todos os enderenços

            viewModel.Enderecos = new List<SelectListItem>();           // prepara a lista para o dropdown

            foreach (var item in enderecos)                             //transforma cada endereço em um "SelectListItem" com value=Id e Text= ToString()
            {
                SelectListItem selectListItem = new SelectListItem();
                selectListItem.Value = item.Id.ToString();
                selectListItem.Text = item.ToString();

                viewModel.Enderecos.Add(selectListItem);            // adiciona viewModel na lista de Enderecos
            }
            return View(viewModel);                                 // Retorna a view com o modelo preenchido
        }

        [HttpPost]
        public IActionResult Create(FornecedorViewModel viewModel) // Auto Binding do Model
        {
            Fornecedor model = viewModel.Fornecedor;                        //extrai o fornecedor do view model
            Endereco endereco = _enderecoService.ListarPorId(model.Endereco.Id);  //busca o endereço completo pelo Id selecionado
            model.Endereco = endereco;                                      // associa o endereço completo ao fornecedor

            var id = _fornecedorService.Cadastrar(model);                   //salva o fornecedor com o endereço
            return RedirectToAction("List");                                
        }


        #region Lista
        [HttpGet]
        public IActionResult List()
        {
            var enderecos = _fornecedorService.Listar();
            return View(enderecos);
        }
        #endregion

        [HttpGet]
        public IActionResult Edit(int id)
        {
            // Busca fornecedor no banco
            var fornecedor = _fornecedorService.ListarPorId(id);

            if (fornecedor == null)
                return NotFound();

            // Monta ViewModel
            FornecedorViewModel viewModel = new FornecedorViewModel();
            viewModel.Fornecedor = fornecedor;

            // Busca endereços para o dropdown
            List<Endereco> enderecos = _enderecoService.Listar();
            viewModel.Enderecos = new List<SelectListItem>();

            foreach (var item in enderecos)
            {
                SelectListItem selectListItem = new SelectListItem();
                selectListItem.Value = item.Id.ToString();
                selectListItem.Text = item.ToString();
                selectListItem.Selected = (fornecedor.Endereco != null && fornecedor.Endereco.Id == item.Id);

                viewModel.Enderecos.Add(selectListItem);
            }

            return View(viewModel); // ✅ passa a ViewModel para a view
        }


        [HttpPost]
        public IActionResult Edit(int id, FornecedorViewModel viewModel)
        {
            if (id != viewModel.Fornecedor.Id)
                return BadRequest();

            var fornecedor = _fornecedorService.ListarPorId(id);

            if (fornecedor == null)
                return NotFound();

            // Atualiza dados do fornecedor
            fornecedor.RazaoSocial = viewModel.Fornecedor.RazaoSocial;
            fornecedor.CNPJ = viewModel.Fornecedor.CNPJ;

            // Atualiza endereço
            if (viewModel.Fornecedor.Endereco != null)
            {
                var novoEndereco = _enderecoService.ListarPorId(viewModel.Fornecedor.Endereco.Id);

                if (novoEndereco != null)
                {
                    fornecedor.Endereco = novoEndereco; // substitui o endereço antigo pelo novo
                }
            }

            _fornecedorService.Editar(fornecedor);

            return RedirectToAction("List");
        }




        #region Delete
        public IActionResult Delete(int id)
        {
            _fornecedorService.Deletar(id);
            return RedirectToAction("List");
        }
        #endregion
    }
}

