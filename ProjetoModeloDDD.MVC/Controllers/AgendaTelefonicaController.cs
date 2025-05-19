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
    public class AgendaTelefonicaController : Controller
    {
        //private readonly AgendaTelefonicaRepository _agendatelefonicaApp = new AgendaTelefonicaRepository();
        ///*PODE USAR ELE NO LUGAR DO AgendaTelefonicaAppService*/
        ///
        private readonly AgendaTelefonicaAppService _agendatelefonicaApp;

        public AgendaTelefonicaController(AgendaTelefonicaAppService agendatelefonicaApp)
        {
            _agendatelefonicaApp = agendatelefonicaApp;
        }

        // GET: AgendaTelefonicas
        public ActionResult Index(string search)
        {
            var agendatelefonicas = _agendatelefonicaApp.GetAll();
            if (!string.IsNullOrEmpty(search))
            {
                search = search.ToUpper();
                agendatelefonicas = _agendatelefonicaApp.GetAll().Where(p =>
                         (Convert.ToString(p.AgendaTelefonicaID) == search) ||
                         p.Nome.ToUpper().Contains(search) ||
                         p.Email.ToUpper().Contains(search) ||
                         p.Telefone.ToUpper().Contains(search))
                    .ToList();
            }
            var agendatelefonicaViewModel = Mapper.Map<IEnumerable<AgendaTelefonica>, IEnumerable<AgendaTelefonicaViewModel>>(agendatelefonicas);
            return View(agendatelefonicaViewModel);
        }

        // GET: AgendaTelefonica/Detalhes/5
        public ActionResult Detalhes(int id = 0)
        {
            if (id == 0) return RedirectToAction("Index");
            else
            {
                var agendatelefonica = _agendatelefonicaApp.GetById(id);
                if (agendatelefonica == null)
                    return HttpNotFound();

                var agendatelefonicaViewModel = Mapper.Map<AgendaTelefonica, AgendaTelefonicaViewModel>(agendatelefonica);
                return View(agendatelefonicaViewModel);
            }

        }

        // GET: AgendaTelefonica/Cadastrar
        public ActionResult Cadastrar()
        {
            return View();
        }

        // POST: AgendaTelefonica/Cadastrar
        [HttpPost]
        public ActionResult Cadastrar(AgendaTelefonicaViewModel agendatelefonica)
        {
            if (ModelState.IsValid)
            {
                var agendatelefonicaDomain = Mapper.Map<AgendaTelefonicaViewModel, AgendaTelefonica>(agendatelefonica);
                _agendatelefonicaApp.Add(agendatelefonicaDomain);

                return RedirectToAction("Index");
            }
            return View(agendatelefonica);
        }

        // GET Editar AgendaTelefonica
        public ActionResult Editar(int id = 0)
        {
            if (id == 0) return RedirectToAction("Index");
            else
            {
                var agendatelefonica = _agendatelefonicaApp.GetById(id);
                if (agendatelefonica == null)
                    return HttpNotFound();

                var agendatelefonicaViewModel = Mapper.Map<AgendaTelefonica, AgendaTelefonicaViewModel>(agendatelefonica);
                return View(agendatelefonicaViewModel);
            }
        }

        // POST: AgendaTelefonica/Editar/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(AgendaTelefonicaViewModel agendatelefonica)
        {
            if (string.IsNullOrEmpty(agendatelefonica.ToString()))
            {
                return RedirectToAction("Index");
            }
            if (ModelState.IsValid)
            {
                var agendatelefonicaDomain = Mapper.Map<AgendaTelefonicaViewModel, AgendaTelefonica>(agendatelefonica);

                _agendatelefonicaApp.Update(agendatelefonicaDomain);

                return RedirectToAction("Index");
            }
            return View(agendatelefonica);
        }


        // GET: AgendaTelefonica/Remover/5
        public ActionResult Remover(int id = 0)
        {
            if (id == 0) return RedirectToAction("Index");
            else
            {
                var agendatelefonica = _agendatelefonicaApp.GetById(id);
                if (agendatelefonica == null)
                    return HttpNotFound();

                var agendatelefonicaViewModel = Mapper.Map<AgendaTelefonica, AgendaTelefonicaViewModel>(agendatelefonica);
                return View(agendatelefonicaViewModel);
            }
        }

        // POST: AgendaTelefonica/Remover/5
        [HttpPost, ActionName("Remover")]
        [ValidateAntiForgeryToken]
        public ActionResult ConfirmarRemover(int id)
        {
            var agendatelefonica = _agendatelefonicaApp.GetById(id);
            _agendatelefonicaApp.Remove(agendatelefonica);

            return RedirectToAction("Index");
        }
    }
}
