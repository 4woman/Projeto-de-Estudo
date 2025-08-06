using Microsoft.AspNetCore.Mvc;
using Zuplae.Aulas.Atv0012.Models;
using Zuplae.Aulas.Atv0012.Servics;

namespace Zuplae.Aulas.Atv0012.Web.Controllers
{
    public class BaseController<T> : Controller where T : BaseModel
    {
        private readonly IService<T> _service;

        public BaseController(IService<T> service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        #region Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(T model)
        {
            _service.Cadastrar(model);
            return RedirectToAction("List");
        }
        #endregion

        #region List
        [HttpGet]
        public IActionResult List()
        {
            return View(_service.Listar());
        }
        #endregion

        #region Edit
        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View(_service.ListarPorId(id));
        }

        [HttpPost]
        public IActionResult Edit(T model)
        {
            var result = _service.Editar(model);
            return RedirectToAction("List");
        }
        #endregion

        #region Delete
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var deletado = _service.ListarPorId(id);
            if (deletado == null)
                return NotFound();

            return View(deletado);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult Excluir(T model)
        {
            bool deletado = _service.Deletar(model.Id);
            if (deletado)
                return RedirectToAction("List");

            ModelState.AddModelError("", "Item não encontrado.");
            return View("Delete", _service.ListarPorId(model.Id));
        }
        #endregion
    }
}
