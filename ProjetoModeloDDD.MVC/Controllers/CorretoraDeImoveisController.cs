using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using ProjetoModeloDDD.Application;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Infra.Data.Repositories;
using ProjetoModeloDDD.MVC.ViewModels;

namespace ProjetoModeloDDD.MVC.Controllers
{
    public class CorretoraDeImoveisController : Controller
    {
        //private readonly CorretoraDeImoveisRepository _corretoradeimoveisApp = new CorretoraDeImoveisRepository();
        ///*PODE USAR ELE NO LUGAR DO CorretoraDeImoveisAppService*/
        ///
        private readonly CorretoraDeImoveisAppService _corretoradeimoveisApp;

        public CorretoraDeImoveisController(CorretoraDeImoveisAppService corretoradeimoveisApp)
        {
            _corretoradeimoveisApp = corretoradeimoveisApp;
        }

        // GET: CorretoraDeImoveiss
        public ActionResult Index(string search)
        {
            var corretoradeimoveiss = _corretoradeimoveisApp.GetAll();
            if (!string.IsNullOrEmpty(search))
            {
                search = search.ToUpper();
                corretoradeimoveiss = _corretoradeimoveisApp.GetAll().Where(p =>
                         (Convert.ToString(p.CorretoraDeImoveisID) == search) ||
                         p.Endereco.ToUpper().Contains(search) ||
                         p.Preco.ToString().ToUpper().Contains(search) ||
                         p.Tipo.ToUpper().Contains(search))
                    .ToList();
            }
            var corretoradeimoveisViewModel = Mapper.Map<IEnumerable<CorretoraDeImoveis>, IEnumerable<CorretoraDeImoveisViewModel>>(corretoradeimoveiss);
            return View(corretoradeimoveisViewModel);
        }

        // GET: CorretoraDeImoveis/Detalhes/5
        public ActionResult Detalhes(int id = 0)
        {
            if (id == 0) return RedirectToAction("Index");
            else
            {
                var corretoradeimoveis = _corretoradeimoveisApp.GetById(id);
                if (corretoradeimoveis == null)
                    return HttpNotFound();

                var corretoradeimoveisViewModel = Mapper.Map<CorretoraDeImoveis, CorretoraDeImoveisViewModel>(corretoradeimoveis);
                return View(corretoradeimoveisViewModel);
            }

        }

        // GET: CorretoraDeImoveis/Cadastrar
        public ActionResult Cadastrar()
        {
            return View();
        }

        // POST: CorretoraDeImoveis/Cadastrar
        [HttpPost]
        public ActionResult Cadastrar(CorretoraDeImoveisViewModel corretoradeimoveis)
        {
            if (ModelState.IsValid)
            {
                var corretoradeimoveisDomain = Mapper.Map<CorretoraDeImoveisViewModel, CorretoraDeImoveis>(corretoradeimoveis);
                _corretoradeimoveisApp.Add(corretoradeimoveisDomain);

                return RedirectToAction("Index");
            }
            return View(corretoradeimoveis);
        }

        // GET Editar CorretoraDeImoveis
        public ActionResult Editar(int id = 0)
        {
            if (id == 0) return RedirectToAction("Index");
            else
            {
                var corretoradeimoveis = _corretoradeimoveisApp.GetById(id);
                if (corretoradeimoveis == null)
                    return HttpNotFound();

                var corretoradeimoveisViewModel = Mapper.Map<CorretoraDeImoveis, CorretoraDeImoveisViewModel>(corretoradeimoveis);
                return View(corretoradeimoveisViewModel);
            }
        }

        // POST: CorretoraDeImoveis/Editar/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(CorretoraDeImoveisViewModel corretoradeimoveis)
        {
            if (string.IsNullOrEmpty(corretoradeimoveis.ToString()))
            {
                return RedirectToAction("Index");
            }
            if (ModelState.IsValid)
            {
                var corretoradeimoveisDomain = Mapper.Map<CorretoraDeImoveisViewModel, CorretoraDeImoveis>(corretoradeimoveis);

                _corretoradeimoveisApp.Update(corretoradeimoveisDomain);

                return RedirectToAction("Index");
            }
            return View(corretoradeimoveis);
        }


        // GET: CorretoraDeImoveis/Remover/5
        public ActionResult Remover(int id = 0)
        {
            if (id == 0) return RedirectToAction("Index");
            else
            {
                var corretoradeimoveis = _corretoradeimoveisApp.GetById(id);
                if (corretoradeimoveis == null)
                    return HttpNotFound();

                var corretoradeimoveisViewModel = Mapper.Map<CorretoraDeImoveis, CorretoraDeImoveisViewModel>(corretoradeimoveis);
                return View(corretoradeimoveisViewModel);
            }
        }

        // POST: CorretoraDeImoveis/Remover/5
        [HttpPost, ActionName("Remover")]
        [ValidateAntiForgeryToken]
        public ActionResult ConfirmarRemover(int id)
        {
            var corretoradeimoveis = _corretoradeimoveisApp.GetById(id);
            _corretoradeimoveisApp.Remove(corretoradeimoveis);

            return RedirectToAction("Index");
        }
    }
}
