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
    public class GerenciadorDeTarefasController : Controller
    {
        //private readonly GerenciadorDeTarefasRepository _gerenciadordetarefasApp = new GerenciadorDeTarefasRepository();
        ///*PODE USAR ELE NO LUGAR DO GerenciadorDeTarefasAppService*/
        ///
        private readonly GerenciadorDeTarefasAppService _gerenciadordetarefasApp;

        public GerenciadorDeTarefasController(GerenciadorDeTarefasAppService gerenciadordetarefasApp)
        {
            _gerenciadordetarefasApp = gerenciadordetarefasApp;
        }

        // GET: GerenciadorDeTarefass
        public ActionResult Index(string search)
        {
            var gerenciadordetarefass = _gerenciadordetarefasApp.GetAll();
            if (!string.IsNullOrEmpty(search))
            {
                search = search.ToUpper();
                gerenciadordetarefass = _gerenciadordetarefasApp.GetAll().Where(p =>
                         (Convert.ToString(p.GerenciadorDeTarefasID) == search) ||
                         p.Descricao.ToUpper().Contains(search))
                    .ToList();
            }
            var gerenciadordetarefasViewModel = Mapper.Map<IEnumerable<GerenciadorDeTarefas>, IEnumerable<GerenciadorDeTarefasViewModel>>(gerenciadordetarefass);
            return View(gerenciadordetarefasViewModel);
        }

        // GET: GerenciadorDeTarefas/Detalhes/5
        public ActionResult Detalhes(int id = 0)
        {
            if (id == 0) return RedirectToAction("Index");
            else
            {
                var gerenciadordetarefas = _gerenciadordetarefasApp.GetById(id);
                if (gerenciadordetarefas == null)
                    return HttpNotFound();

                var gerenciadordetarefasViewModel = Mapper.Map<GerenciadorDeTarefas, GerenciadorDeTarefasViewModel>(gerenciadordetarefas);
                return View(gerenciadordetarefasViewModel);
            }

        }

        // GET: GerenciadorDeTarefas/Cadastrar
        public ActionResult Cadastrar()
        {
            return View();
        }

        // POST: GerenciadorDeTarefas/Cadastrar
        [HttpPost]
        public ActionResult Cadastrar(GerenciadorDeTarefasViewModel gerenciadordetarefas)
        {
            if (ModelState.IsValid)
            {
                var gerenciadordetarefasDomain = Mapper.Map<GerenciadorDeTarefasViewModel, GerenciadorDeTarefas>(gerenciadordetarefas);
                _gerenciadordetarefasApp.Add(gerenciadordetarefasDomain);

                return RedirectToAction("Index");
            }
            return View(gerenciadordetarefas);
        }

        // GET Editar GerenciadorDeTarefas
        public ActionResult Editar(int id = 0)
        {
            if (id == 0) return RedirectToAction("Index");
            else
            {
                var gerenciadordetarefas = _gerenciadordetarefasApp.GetById(id);
                if (gerenciadordetarefas == null)
                    return HttpNotFound();

                var gerenciadordetarefasViewModel = Mapper.Map<GerenciadorDeTarefas, GerenciadorDeTarefasViewModel>(gerenciadordetarefas);
                return View(gerenciadordetarefasViewModel);
            }
        }

        // POST: GerenciadorDeTarefas/Editar/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(GerenciadorDeTarefasViewModel gerenciadordetarefas)
        {
            if (string.IsNullOrEmpty(gerenciadordetarefas.ToString()))
            {
                return RedirectToAction("Index");
            }
            if (ModelState.IsValid)
            {
                var gerenciadordetarefasDomain = Mapper.Map<GerenciadorDeTarefasViewModel, GerenciadorDeTarefas>(gerenciadordetarefas);

                _gerenciadordetarefasApp.Update(gerenciadordetarefasDomain);

                return RedirectToAction("Index");
            }
            return View(gerenciadordetarefas);
        }


        // GET: GerenciadorDeTarefas/Remover/5
        public ActionResult Remover(int id = 0)
        {
            if (id == 0) return RedirectToAction("Index");
            else
            {
                var gerenciadordetarefas = _gerenciadordetarefasApp.GetById(id);
                if (gerenciadordetarefas == null)
                    return HttpNotFound();

                var gerenciadordetarefasViewModel = Mapper.Map<GerenciadorDeTarefas, GerenciadorDeTarefasViewModel>(gerenciadordetarefas);
                return View(gerenciadordetarefasViewModel);
            }
        }

        // POST: GerenciadorDeTarefas/Remover/5
        [HttpPost, ActionName("Remover")]
        [ValidateAntiForgeryToken]
        public ActionResult ConfirmarRemover(int id)
        {
            var gerenciadordetarefas = _gerenciadordetarefasApp.GetById(id);
            _gerenciadordetarefasApp.Remove(gerenciadordetarefas);

            return RedirectToAction("Index");
        }
    }
}
