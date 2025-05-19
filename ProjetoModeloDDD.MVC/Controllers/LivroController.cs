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
    public class LivroController : Controller
    {
        //private readonly LivroRepository _livroApp = new LivroRepository();
        ///*PODE USAR ELE NO LUGAR DO LivroAppService*/
        ///
        private readonly LivroAppService _livroApp;

        public LivroController(LivroAppService livroApp)
        {
            _livroApp = livroApp;
        }

        // GET: Livros
        public ActionResult Index(string search)
        {
            var livros = _livroApp.GetAll();
            if (!string.IsNullOrEmpty(search))
            {
                search = search.ToUpper();
                livros = _livroApp.GetAll().Where(p =>
                         (Convert.ToString(p.LivroID) == search) ||
                         p.Nome.ToUpper().Contains(search) ||
                         p.Autor.ToUpper().Contains(search))
                    .ToList();
            }
            var livroViewModel = Mapper.Map<IEnumerable<Livro>, IEnumerable<LivroViewModel>>(livros);
            return View(livroViewModel);
        }

        // GET: Livro/Detalhes/5
        public ActionResult Detalhes(int id = 0)
        {
            if (id == 0) return RedirectToAction("Index");
            else
            {
                var livro = _livroApp.GetById(id);
                if (livro == null)
                    return HttpNotFound();

                var livroViewModel = Mapper.Map<Livro, LivroViewModel>(livro);
                return View(livroViewModel);
            }

        }

        // GET: Livro/Cadastrar
        public ActionResult Cadastrar()
        {
            return View();
        }

        // POST: Livro/Cadastrar
        [HttpPost]
        public ActionResult Cadastrar(LivroViewModel livro)
        {
            if (ModelState.IsValid)
            {
                var livroDomain = Mapper.Map<LivroViewModel, Livro>(livro);
                _livroApp.Add(livroDomain);

                return RedirectToAction("Index");
            }
            return View(livro);
        }

        // GET Editar Livro
        public ActionResult Editar(int id = 0)
        {
            if (id == 0) return RedirectToAction("Index");
            else
            {
                var livro = _livroApp.GetById(id);
                if (livro == null)
                    return HttpNotFound();

                var livroViewModel = Mapper.Map<Livro, LivroViewModel>(livro);
                return View(livroViewModel);
            }
        }

        // POST: Livro/Editar/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(LivroViewModel livro)
        {
            if (string.IsNullOrEmpty(livro.ToString()))
            {
                return RedirectToAction("Index");
            }
            if (ModelState.IsValid)
            {
                var livroDomain = Mapper.Map<LivroViewModel, Livro>(livro);

                _livroApp.Update(livroDomain);

                return RedirectToAction("Index");
            }
            return View(livro);
        }


        // GET: Livro/Remover/5
        public ActionResult Remover(int id = 0)
        {
            if (id == 0) return RedirectToAction("Index");
            else
            {
                var livro = _livroApp.GetById(id);
                if (livro == null)
                    return HttpNotFound();

                var livroViewModel = Mapper.Map<Livro, LivroViewModel>(livro);
                return View(livroViewModel);
            }
        }

        // POST: Livro/Remover/5
        [HttpPost, ActionName("Remover")]
        [ValidateAntiForgeryToken]
        public ActionResult ConfirmarRemover(int id)
        {
            var livro = _livroApp.GetById(id);
            _livroApp.Remove(livro);

            return RedirectToAction("Index");
        }
    }
}
