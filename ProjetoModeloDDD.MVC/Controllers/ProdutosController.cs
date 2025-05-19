using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using ProjetoModeloDDD.MVC.ViewModels;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Application;
using System;
using System.Linq;
using System.Web.UI.WebControls;

namespace ProjetoModeloDDD.MVC.Controllers
{
    public class ProdutosController : Controller
    {
        private readonly ProdutoAppService _produtoApp;
        private readonly FabricanteAppService _fabricanteApp;
        private readonly RegistroCompraAppService _registrocompraApp;

        public ProdutosController(ProdutoAppService produtoApp, 
            FabricanteAppService fabricanteApp,
            RegistroCompraAppService registrocompraApp)
        {
            _produtoApp = produtoApp;
            _fabricanteApp = fabricanteApp;
            _registrocompraApp = registrocompraApp;
        }

        // GET: Produtos
        public ActionResult Index(string search)
        {
            var produtos = _produtoApp.GetAll();
           
            if (!string.IsNullOrEmpty(search))
            {
                search = search.ToUpper();
                produtos = _produtoApp.GetAll().Where(p =>
                         (Convert.ToString(p.ProdutoID) == search) ||
                         p.Nome.ToUpper().Contains(search) ||
                         p.Descricao.ToUpper().Contains(search) ||
                         p.CodigoFabrica.ToUpper().Contains(search))
                    .ToList();

            }
            var produtoViewModel = Mapper.Map<IEnumerable<Produto>, IEnumerable<ProdutoViewModel>>(produtos);
            ViewBag.Fabricantes = _fabricanteApp.GetAll();

            return View(produtoViewModel);
        }

        // GET: Produtos/Detalhes/5
        public ActionResult Detalhes(int id = 0)
        {
            if (id == 0) return RedirectToAction("Index");
            else
            {
                var produto = _produtoApp.GetById(id);
                if (produto == null)
                    return HttpNotFound();

                var produtoViewModel = Mapper.Map<Produto, ProdutoViewModel>(produto);
                ViewBag.registroCompras = _registrocompraApp.GetAll().Where(p => p.Produto.ToString() == produto.ProdutoID.ToString());

                return View(produtoViewModel);
            }
        }

        // GET: Produtos/Cadastrar
        public ActionResult Cadastrar(int id = 0)
        {
            ViewBag.FabricanteSelecionado = id;
            ViewBag.Fabricantes = _fabricanteApp.GetAll();
            return View();
        }

        // POST: Produtos/Cadastrar
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastrar(ProdutoViewModel produto)
        {
           if(ModelState.IsValid)
            {
                var produtoDomain = Mapper.Map<ProdutoViewModel, Produto>(produto);
                produtoDomain.ativo = produtoDomain.Estoque >= produtoDomain.EstoqueMin;

                _produtoApp.Add(produtoDomain);

                return RedirectToAction("Index");
            }
            return View(produto);
        }


        // GET: Produtos/Editar/5
        public ActionResult Editar(int id = 0)
        {
            if (id == 0) return RedirectToAction("Index");
            else
            {
                var produto = _produtoApp.GetById(id);
                if (produto == null)
                    return HttpNotFound();

                var produtoViewModel = Mapper.Map<Produto, ProdutoViewModel>(produto);
                ViewBag.Fabricantes = _fabricanteApp.GetAll();

                return View(produtoViewModel);
            }
        }

        // POST: Produtos/Editar/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(ProdutoViewModel produto)
        {
            if (ModelState.IsValid)
            {
                var produtoDomain = Mapper.Map<ProdutoViewModel, Produto>(produto);
                produtoDomain.ativo = produtoDomain.Estoque >= produtoDomain.EstoqueMin;

                _produtoApp.Update(produtoDomain);

                return RedirectToAction("Index");
            }
            return View(produto);
        }

        // GET: Produtos/Estoque/5
        public ActionResult Estoque(int id = 0)
        {
            if (id == 0) return RedirectToAction("Index");
            else
            {
                var produto = _produtoApp.GetById(id);
                if (produto == null)
                    return HttpNotFound();

                var produtoViewModel = Mapper.Map<Produto, ProdutoViewModel>(produto);
                return View(produtoViewModel);
            }
        }

        // POST: Produtos/Estoque/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Estoque(int produtoID, int Estoque, int EstoqueMin)
        {
            if (ModelState.IsValid)
            {
                var produtoDomain = _produtoApp.GetById(produtoID);

                produtoDomain.Estoque = Estoque;
                produtoDomain.EstoqueMin = EstoqueMin;
                produtoDomain.ativo = Estoque >= EstoqueMin;

                _produtoApp.Update(produtoDomain);
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

        // GET: Produtos/Remover/5
        public ActionResult Remover(int id = 0)
        {
            if (id == 0) return RedirectToAction("Index");
            else
            {
                var produto = _produtoApp.GetById(id);
                if (produto == null)
                    return HttpNotFound();

                var produtoViewModel = Mapper.Map<Produto, ProdutoViewModel>(produto);
                return View(produtoViewModel);
            }
        }

        // POST: Produtos/Remover/5
        [HttpPost, ActionName("Remover")]
        [ValidateAntiForgeryToken]
        public ActionResult ConfirmarRemover(int id)
        {
            var produto = _produtoApp.GetById(id);
            _produtoApp.Remove(produto);

            return RedirectToAction("Index");
        }


    }
}
