using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Services.Description;
using AutoMapper;
using ProjetoModeloDDD.Application;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Infra.Data.Repositories;
using ProjetoModeloDDD.MVC.ViewModels;

namespace ProjetoModeloDDD.MVC.Controllers
{
    public class CarroController : Controller
    {
        //private readonly CarroRepository _carroApp = new CarroRepository();
        ///*PODE USAR ELE NO LUGAR DO CarroAppService*/
        ///
        private readonly CarroAppService _carroApp;

        public CarroController(CarroAppService carroApp)
        {
            _carroApp = carroApp;
        }

        // GET: Carros
        public ActionResult Index(string search)
        {
            var carros = _carroApp.GetAll();
            if (!string.IsNullOrEmpty(search))
            {
                search = search.ToUpper();
                carros = _carroApp.GetAll().Where(p =>
                         (Convert.ToString(p.CarroID) == search) ||
                         p.Nome.ToUpper().Contains(search) ||
                         p.Ano.ToString().Contains(search) ||
                         p.Modelo.ToUpper().Contains(search))
                    .ToList();
            }
            var carroViewModel = Mapper.Map<IEnumerable<Carro>, IEnumerable<CarroViewModel>>(carros);
            return View(carroViewModel);
        }

        // GET: Carro/Detalhes/5
        public ActionResult Detalhes(int id = 0)
        {
            if (id == 0) return RedirectToAction("Index");
            else
            {
                var carro = _carroApp.GetById(id);
                if (carro == null)
                    return HttpNotFound();

                var carroViewModel = Mapper.Map<Carro, CarroViewModel>(carro);
                return View(carroViewModel);
            }

        }

        // GET: Carro/Cadastrar
        public ActionResult Cadastrar()
        {
            return View();
        }

        // POST: Carro/Cadastrar
        [HttpPost]
        public ActionResult Cadastrar(CarroViewModel carro)
        {
            if (ModelState.IsValid)
            {
                var carroDomain = Mapper.Map<CarroViewModel, Carro>(carro);
                _carroApp.Add(carroDomain);

                return RedirectToAction("Index");
            }
            return View(carro);
        }

        // GET Editar Carro
        public ActionResult Editar(int id = 0)
        {
            if (id == 0) return RedirectToAction("Index");
            else
            {
                var carro = _carroApp.GetById(id);
                if (carro == null)
                    return HttpNotFound();

                var carroViewModel = Mapper.Map<Carro, CarroViewModel>(carro);
                return View(carroViewModel);
            }
        }

        // POST: Carro/Editar/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(CarroViewModel carro)
        {
            if (string.IsNullOrEmpty(carro.ToString()))
            {
                return RedirectToAction("Index");
            }
            if (ModelState.IsValid)
            {
                var carroDomain = Mapper.Map<CarroViewModel, Carro>(carro);

                _carroApp.Update(carroDomain);

                return RedirectToAction("Index");
            }
            return View(carro);
        }

        // GET: Carros/Velocidade/5
        public ActionResult Velocidade(int id = 0)
        {
            if (id == 0) return RedirectToAction("Index");
            else
            {
                var carro = _carroApp.GetById(id);
                if (carro == null)
                    return HttpNotFound();

                var carroViewModel = Mapper.Map<Carro, CarroViewModel>(carro);
                return View(carroViewModel);
            }
        }

        // POST: Carros/Velocidade/5
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Velocidade(int carroID, string Method)
        {
            if (ModelState.IsValid)
            {
                var erroVelocidade = false;
                var carroDomain = _carroApp.GetById(carroID);

                if (Method == "Acelerar")
                {
                    carroDomain.Velocidade = carroDomain.Velocidade + 10;
                }
                else if (Method == "Brecar")
                {
                    carroDomain.Velocidade = carroDomain.Velocidade - 10;
                    if (carroDomain.Velocidade <= 0)
                    {
                        carroDomain.Velocidade = 0;
                        erroVelocidade = true;
                    }
                } else
                {
                    return Json(new { novaVelocidade = false });
                }

                _carroApp.Update(carroDomain);
                return Json(new { novaVelocidade = carroDomain.Velocidade, ErroVelocidade = erroVelocidade });
            }

            return Json(new { novaVelocidade = false });
        }


        // GET: Carro/Remover/5
        public ActionResult Remover(int id = 0)
        {
            if (id == 0) return RedirectToAction("Index");
            else
            {
                var carro = _carroApp.GetById(id);
                if (carro == null)
                    return HttpNotFound();

                var carroViewModel = Mapper.Map<Carro, CarroViewModel>(carro);
                return View(carroViewModel);
            }
        }

        // POST: Carro/Remover/5
        [HttpPost, ActionName("Remover")]
        [ValidateAntiForgeryToken]
        public ActionResult ConfirmarRemover(int id)
        {
            var carro = _carroApp.GetById(id);
            _carroApp.Remove(carro);

            return RedirectToAction("Index");
        }
    }
}
