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
    public class FabricanteController : Controller
    {
        //private readonly FabricanteRepository _fabricanteApp = new FabricanteRepository();
        ///*PODE USAR ELE NO LUGAR DO FabricanteAppService*/
        ///
        private readonly FabricanteAppService _fabricanteApp;
        private readonly ProdutoAppService _produtoApp;

        public FabricanteController(FabricanteAppService fabricanteApp, ProdutoAppService produtoApp)
        {
            _fabricanteApp = fabricanteApp;
            _produtoApp = produtoApp;
        }

        // GET: Fabricantes
        public ActionResult Index(string search)
        {
            var fabricantes = _fabricanteApp.GetAll();
          
            if (!string.IsNullOrEmpty(search))
            {
                search = search.ToUpper();
                fabricantes = _fabricanteApp.GetAll().Where(p =>
                         (Convert.ToString(p.FabricanteID) == search) ||
                         p.Nome.ToUpper().Contains(search) ||
                         p.Endereco.ToUpper().Contains(search) ||
                         p.Cidade.ToUpper().Contains(search))
                    .ToList();
            }
            var fabricanteViewModel = Mapper.Map<IEnumerable<Fabricante>, IEnumerable<FabricanteViewModel>>(fabricantes);
            return View(fabricanteViewModel);
        }

        // GET: Fabricante/Detalhes/5
        public ActionResult Detalhes(int id = 0)
        {
            if (id == 0) return RedirectToAction("Index");
            else
            {
                var fabricante = _fabricanteApp.GetById(id);
                if (fabricante == null)
                    return HttpNotFound();

                ViewBag.produtos = _produtoApp.GetAll();

                var fabricanteViewModel = Mapper.Map<Fabricante, FabricanteViewModel>(fabricante);
                return View(fabricanteViewModel);
            }

        }

        // GET: Fabricante/Cadastrar
        public ActionResult Cadastrar()
        {
            return View();
        }

        // POST: Fabricante/Cadastrar
        [HttpPost]
        public ActionResult Cadastrar(FabricanteViewModel fabricante)
        {
            if (ModelState.IsValid)
            {
                var fabricanteDomain = Mapper.Map<FabricanteViewModel, Fabricante>(fabricante);
                _fabricanteApp.Add(fabricanteDomain);

                return RedirectToAction("Index");
            }
            return View(fabricante);
        }

        // GET Editar Fabricante
        public ActionResult Editar(int id = 0)
        {
            if (id == 0) return RedirectToAction("Index");
            else
            {
                var fabricante = _fabricanteApp.GetById(id);
                if (fabricante == null)
                    return HttpNotFound();

                var fabricanteViewModel = Mapper.Map<Fabricante, FabricanteViewModel>(fabricante);
                return View(fabricanteViewModel);
            }
        }

        // POST: Fabricante/Editar/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(FabricanteViewModel fabricante)
        {
            if (string.IsNullOrEmpty(fabricante.ToString()))
            {
                return RedirectToAction("Index");
            }
            if (ModelState.IsValid)
            {
                var fabricanteDomain = Mapper.Map<FabricanteViewModel, Fabricante>(fabricante);

                _fabricanteApp.Update(fabricanteDomain);

                return RedirectToAction("Index");
            }
            return View(fabricante);
        }


        // GET: Fabricante/Remover/5
        public ActionResult Remover(int id = 0)
        {
            if (id == 0) return RedirectToAction("Index");
            else
            {
                var fabricante = _fabricanteApp.GetById(id);
                if (fabricante == null)
                    return HttpNotFound();

                var fabricanteViewModel = Mapper.Map<Fabricante, FabricanteViewModel>(fabricante);
                return View(fabricanteViewModel);
            }
        }

        // POST: Fabricante/Remover/5
        [HttpPost, ActionName("Remover")]
        [ValidateAntiForgeryToken]
        public ActionResult ConfirmarRemover(int id)
        {
            var fabricante = _fabricanteApp.GetById(id);
            _fabricanteApp.Remove(fabricante);

            return RedirectToAction("Index");
        }
    }
}
