using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using ProjetoModeloDDD.Application;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces;
using ProjetoModeloDDD.Infra.Data.Repositories;
using ProjetoModeloDDD.MVC.ViewModels;

namespace ProjetoModeloDDD.MVC.Controllers
{
    public class AnimalController : Controller
    {
        private readonly AnimalAppService _animalApp;

        public AnimalController(AnimalAppService animalApp)
        {
            _animalApp = animalApp;
        }

        // GET: AnimalW
        public ActionResult Index(string search)
        {
            var animais = _animalApp.GetAll();
            if (!string.IsNullOrEmpty(search))
            {
                search = search.ToUpper();
                animais = _animalApp.GetAll().Where(p =>
                         (Convert.ToString(p.AnimalID) == search) ||
                         (Convert.ToString(p.Idade) == search) ||
                         p.Nome.ToUpper().Contains(search) ||
                         p.Especie.ToUpper().Contains(search))
                    .ToList();
            }
            var animalViewModel = Mapper.Map<IEnumerable<Animal>, IEnumerable<AnimalViewModel>>(animais);
            return View(animalViewModel);
        }

        // GET: Animal/Details/5
        public ActionResult Detalhes(int id = 0)
        {
            if (id == 0) return RedirectToAction("Index");
            else
            {
                var animal = _animalApp.GetById(id);
                if (animal == null)
                    return HttpNotFound();

                var animalViewModel = Mapper.Map<Animal, AnimalViewModel>(animal);
                return View(animalViewModel);
            }
        }

        // GET: Animal/PlaySom/5
        public ActionResult PlaySom(int id = 0)
        {
            if (id == 0) return RedirectToAction("Index");
            else
            {
                var animal = _animalApp.GetById(id);
                if (animal == null)
                    return HttpNotFound();

                var animalViewModel = Mapper.Map<Animal, AnimalViewModel>(animal);
                return View(animalViewModel);
            }
        }

        // GET: Animal/Create
        public ActionResult Cadastrar()
        {
            return View();
        }

        // POST: Animal/Create
        [HttpPost]
        public ActionResult Cadastrar(AnimalViewModel animal)
        {
            if (ModelState.IsValid)
            {
                var animalDomain = Mapper.Map<AnimalViewModel, Animal>(animal);
                _animalApp.Add(animalDomain);

                return RedirectToAction("Index");
            }
            return View(animal);
        }

        // GET: Animal/Edit/5
        public ActionResult Editar(int id = 0)
        {
            if (id == 0) return RedirectToAction("Index");
            else
            {
                var animal = _animalApp.GetById(id);
                if (animal == null)
                    return HttpNotFound();

                var animalViewModel = Mapper.Map<Animal, AnimalViewModel>(animal);
                return View(animalViewModel);
            }
        }

        // POST: Animal/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(AnimalViewModel animal)
        {
            if (string.IsNullOrEmpty(animal.ToString()))
            {
                return RedirectToAction("Index");
            }
            if (ModelState.IsValid)
            {
                var animalDomain = Mapper.Map<AnimalViewModel, Animal>(animal);

                _animalApp.Update(animalDomain);

                return RedirectToAction("Index");
            }
            return View(animal);
        }

        // GET: Animal/Remover/5
        public ActionResult Remover(int id = 0)
        {
            if (id == 0) return RedirectToAction("Index");
            else
            {
                var animal = _animalApp.GetById(id);
                if (animal == null)
                    return HttpNotFound();

                var animalViewModel = Mapper.Map<Animal, AnimalViewModel>(animal);
                return View(animalViewModel);
            }
        }

        // POST: Animal/Remover/5
        [HttpPost, ActionName("Remover")]
        [ValidateAntiForgeryToken]
        public ActionResult ConfirmarRemover(int id)
        {
            var animal = _animalApp.GetById(id);
            _animalApp.Remove(animal);

            return RedirectToAction("Index");
        }
    }
}
