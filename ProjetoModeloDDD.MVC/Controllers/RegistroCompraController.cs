using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Hosting;
using System.Web.Mvc;
using AutoMapper;
using ProjetoModeloDDD.Application;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Infra.Data.Repositories;
using ProjetoModeloDDD.MVC.ViewModels;

namespace ProjetoModeloDDD.MVC.Controllers
{
    public class RegistroCompraController : Controller
    {
        //private readonly RegistroCompraRepository _registrocompraApp = new RegistroCompraRepository();
        ///*PODE USAR ELE NO LUGAR DO RegistroCompraAppService*/
        ///
        private readonly RegistroCompraAppService _registrocompraApp;
        private readonly ProdutoAppService _produtoApp;

        public RegistroCompraController(RegistroCompraAppService registrocompraApp, ProdutoAppService produtoApp)
        {
            _registrocompraApp = registrocompraApp;
            _produtoApp = produtoApp;
        }

        // GET: RegistroCompras
        public ActionResult Index(string search)
        {
            var registros = _registrocompraApp.GetAll();
            if (!string.IsNullOrEmpty(search))
            {
                search = search.ToUpper();
                registros = _registrocompraApp.GetAll().Where(p =>
                         (Convert.ToString(p.RegistroCompraID) == search) ||
                         //_produtoApp.GetById(p.Produto).Nome.ToUpper().Contains(search) || 
                         p.Quantidade.ToString().ToUpper().Contains(search) ||
                         p.ValorTotal.ToString().ToUpper().Contains(search))
                    .ToList();
            }
            var registrocompraViewModel = Mapper.Map<IEnumerable<RegistroCompra>,
                IEnumerable<RegistroCompraViewModel>>(registros);
            ViewBag.Produtos = _produtoApp.GetAll();

            return View(registrocompraViewModel);
        }

        // GET: RegistroCompra/Detalhes/5
        public ActionResult Detalhes(int id = 0)
        {
            if (id == 0) return RedirectToAction("Index");
            else
            {
                var registrocompra = _registrocompraApp.GetById(id);
                if (registrocompra == null)
                    return HttpNotFound();

                ViewBag.Produtos = _produtoApp.GetAll().Where(p => p.ProdutoID.ToString() == registrocompra.Produto.ToString());

                var registrocompraViewModel = Mapper.Map<RegistroCompra, RegistroCompraViewModel>(registrocompra);
                return View(registrocompraViewModel);
            }

        }

        // GET: RegistroCompra/Cadastrar
        public ActionResult Cadastrar(int id = 0)
        {

            ViewBag.Produtos = _produtoApp.GetAll();
            ViewBag.ProdutoSelecionado = id;

            return View();
        }

        // POST: RegistroCompra/Cadastrar
        [HttpPost]
        public ActionResult Cadastrar(RegistroCompraViewModel registrocompra)
        {
            if (ModelState.IsValid)
            {
                var registrocompraDomain = Mapper.Map<RegistroCompraViewModel, RegistroCompra>(registrocompra);
                _registrocompraApp.Add(registrocompraDomain);

                if(registrocompraDomain.Produto > 0)
                {
                    var produto = _produtoApp.GetById(registrocompraDomain.Produto);
                    produto.Estoque = produto.Estoque + registrocompraDomain.Quantidade;
                    produto.ativo = produto.Estoque >= produto.EstoqueMin;
                    produto.valorCompra = registrocompraDomain.ValorTotal / registrocompraDomain.Quantidade;
                    _produtoApp.Update(produto);
                }

                return RedirectToAction("Index");
            }
            return View(registrocompra);
        }

        // GET Editar RegistroCompra
        public ActionResult Editar(int id = 0)
        {
            if (id == 0) return RedirectToAction("Index");
            else
            {
                var registrocompra = _registrocompraApp.GetById(id);
                if (registrocompra == null)
                    return HttpNotFound();

                var registrocompraViewModel = Mapper.Map<RegistroCompra, RegistroCompraViewModel>(registrocompra);
                return View(registrocompraViewModel);
            }
        }

        // POST: RegistroCompra/Editar/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(RegistroCompraViewModel registrocompra)
        {
            if (string.IsNullOrEmpty(registrocompra.ToString()))
            {
                return RedirectToAction("Index");
            }
            if (ModelState.IsValid)
            {
                var registrocompraDomain = Mapper.Map<RegistroCompraViewModel, RegistroCompra>(registrocompra);

                _registrocompraApp.Update(registrocompraDomain);

                return RedirectToAction("Index");
            }
            return View(registrocompra);
        }


        // GET: RegistroCompra/Remover/5
        public ActionResult Remover(int id = 0)
        {
            if (id == 0) return RedirectToAction("Index");
            else
            {
                var registrocompra = _registrocompraApp.GetById(id);
                if (registrocompra == null)
                    return HttpNotFound();

                var registrocompraViewModel = Mapper.Map<RegistroCompra, RegistroCompraViewModel>(registrocompra);
                return View(registrocompraViewModel);
            }
        }

        // POST: RegistroCompra/Remover/5
        [HttpPost, ActionName("Remover")]
        [ValidateAntiForgeryToken]
        public ActionResult ConfirmarRemover(int id)
        {
            var registrocompra = _registrocompraApp.GetById(id);
            _registrocompraApp.Remove(registrocompra);

            return RedirectToAction("Index");
        }
    }
}
