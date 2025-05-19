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
    public class AgendaController : Controller
    {
        //private readonly AgendaRepository _agendaApp = new AgendaRepository();
        ///*PODE USAR ELE NO LUGAR DO AgendaAppService*/
        ///
        private readonly AgendaAppService _agendaApp;

        public AgendaController(AgendaAppService agendaApp)
        {
            _agendaApp = agendaApp;
        }

        // GET: Agendas
        public ActionResult Index(string search)
        {
            var agendas = _agendaApp.GetAll();
            if (!string.IsNullOrEmpty(search))
            {
                search = search.ToUpper();
                agendas = _agendaApp.GetAll().Where(p =>
                         (Convert.ToString(p.AgendaID) == search) ||
                         p.Nome.ToUpper().Contains(search) ||
                         p.Idade.ToString().Contains(search) ||
                         p.Altura.ToString().ToUpper().Contains(search))
                    .ToList();
            }
            var agendaViewModel = Mapper.Map<IEnumerable<Agenda>, IEnumerable<AgendaViewModel>>(agendas);
            return View(agendaViewModel);
        }

        // GET: Agenda/Detalhes/5
        public ActionResult Detalhes(int id = 0)
        {
            if (id == 0) return RedirectToAction("Index");
            else
            {
                var agenda = _agendaApp.GetById(id);
                if (agenda == null)
                    return HttpNotFound();

                var agendaViewModel = Mapper.Map<Agenda, AgendaViewModel>(agenda);
                return View(agendaViewModel);
            }

        }

        // GET: Agenda/Cadastrar
        public ActionResult Cadastrar()
        {
            return View();
        }

        // POST: Agenda/Cadastrar
        [HttpPost]
        public ActionResult Cadastrar(AgendaViewModel agenda)
        {
            if (ModelState.IsValid)
            {
                var agendaDomain = Mapper.Map<AgendaViewModel, Agenda>(agenda);
                _agendaApp.Add(agendaDomain);

                return RedirectToAction("Index");
            }
            return View(agenda);
        }

        // GET Editar Agenda
        public ActionResult Editar(int id = 0)
        {
            if (id == 0) return RedirectToAction("Index");
            else
            {
                var agenda = _agendaApp.GetById(id);
                if (agenda == null)
                    return HttpNotFound();

                var agendaViewModel = Mapper.Map<Agenda, AgendaViewModel>(agenda);
                return View(agendaViewModel);
            }
        }

        // POST: Agenda/Editar/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(AgendaViewModel agenda)
        {
            if (string.IsNullOrEmpty(agenda.ToString()))
            {
                return RedirectToAction("Index");
            }
            if (ModelState.IsValid)
            {
                var agendaDomain = Mapper.Map<AgendaViewModel, Agenda>(agenda);

                _agendaApp.Update(agendaDomain);

                return RedirectToAction("Index");
            }
            return View(agenda);
        }


        // GET: Agenda/Remover/5
        public ActionResult Remover(int id = 0)
        {
            if (id == 0) return RedirectToAction("Index");
            else
            {
                var agenda = _agendaApp.GetById(id);
                if (agenda == null)
                    return HttpNotFound();

                var agendaViewModel = Mapper.Map<Agenda, AgendaViewModel>(agenda);
                return View(agendaViewModel);
            }
        }

        // POST: Agenda/Remover/5
        [HttpPost, ActionName("Remover")]
        [ValidateAntiForgeryToken]
        public ActionResult ConfirmarRemover(int id)
        {
            var agenda = _agendaApp.GetById(id);
            _agendaApp.Remove(agenda);

            return RedirectToAction("Index");
        }
    }
}
