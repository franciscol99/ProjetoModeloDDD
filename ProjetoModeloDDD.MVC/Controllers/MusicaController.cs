using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using ProjetoModeloDDD.MVC.ViewModels;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Application;
using System;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace ProjetoModeloDDD.MVC.Controllers
{
    public class MusicasController : Controller
    {
        private readonly MusicaAppService _musicaApp;
        private static Random Rand = new Random();

        public MusicasController(MusicaAppService musicaApp)
        {
            _musicaApp = musicaApp;
        }

        // GET: Musicas
        public ActionResult Index(string search, string P)
        {
            var ListaMusicas = _musicaApp.GetAll();

            if (!string.IsNullOrEmpty(search))
            {
                search = search.ToUpper();
                ListaMusicas = _musicaApp.GetAll().Where(p =>
                         (Convert.ToString(p.MusicaID) == search) ||
                         p.Nome.ToUpper().Contains(search) ||
                         p.Autor.ToUpper().Contains(search) ||
                         p.Gravadora.ToUpper().Contains(search))
                    .ToList();

            }
            if (!string.IsNullOrEmpty(P))
            {
                if (P == "PlayListRandom")
                {
                    ListaMusicas = _musicaApp.GetAll().OrderBy(_ => Rand.Next()).ToList();
                }
                else if (P == "MusicaRandom")
                {
                    ListaMusicas = _musicaApp.GetAll().OrderBy(_ => Rand.Next()).Take(1);
                }
            }
            var musicaViewModel = Mapper.Map<IEnumerable<Musica>, IEnumerable<MusicaViewModel>>(ListaMusicas);
            return View(musicaViewModel);
            }


        // GET: Musicas/Detalhes/5
        public ActionResult Detalhes(int id = 0)
        {
            if (id == 0) return RedirectToAction("Index");
            else
            {
                var musica = _musicaApp.GetById(id);
                if (musica == null)
                    return HttpNotFound();


                var musicaViewModel = Mapper.Map<Musica, MusicaViewModel>(musica);
                return View(musicaViewModel);
            }
        }

        // GET: Musicas/Cadastrar
        public ActionResult Cadastrar()
        {
            return View();
        }

        // POST: Musicas/Cadastrar
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastrar(MusicaViewModel musica)
        {
            if (ModelState.IsValid)
            {
                var musicaDomain = Mapper.Map<MusicaViewModel, Musica>(musica);

                _musicaApp.Add(musicaDomain);

                return RedirectToAction("Index");
            }
            return View(musica);
        }

        // GET: Musicas/Editar/5
        public ActionResult Editar(int id = 0)
        {
            if (id == 0) return RedirectToAction("Index");
            else
            {
                var musica = _musicaApp.GetById(id);
                if (musica == null)
                    return HttpNotFound();

                var musicaViewModel = Mapper.Map<Musica, MusicaViewModel>(musica);
                return View(musicaViewModel);
            }
        }

        // POST: Musicas/Editar/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(MusicaViewModel musica)
        {
            if (ModelState.IsValid)
            {
                var musicaDomain = Mapper.Map<MusicaViewModel, Musica>(musica);

                _musicaApp.Update(musicaDomain);

                return RedirectToAction("Index");
            }
            return View(musica);
        }

        // GET: Musicas/Remover/5
        public ActionResult Remover(int id = 0)
        {
            if (id == 0) return RedirectToAction("Index");
            else
            {
                var musica = _musicaApp.GetById(id);
                if (musica == null)
                    return HttpNotFound();

                var musicaViewModel = Mapper.Map<Musica, MusicaViewModel>(musica);
                return View(musicaViewModel);
            }
        }

        // POST: Musicas/Remover/5
        [HttpPost, ActionName("Remover")]
        [ValidateAntiForgeryToken]
        public ActionResult ConfirmarRemover(int id)
        {
            var musica = _musicaApp.GetById(id);
            _musicaApp.Remove(musica);

            return RedirectToAction("Index");
        }


    }
}
