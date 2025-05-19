using System.Collections.Generic;
using System.Linq;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces;

namespace ProjetoModeloDDD.Infra.Data.Repositories
{
    public class ProdutoRepository : RepositoryBase<Produto>, IProdutoRepository
    {
        public IEnumerable<Produto> BuscarPorNome(string nome)
        {
            //return Db.Produtos.Where(p => p.ListaProdutos.Any(x => x.Nome.Contains(nome)));
            return Db.Produtos.Where(p => p.Nome == nome);
        }

        //public ProdutoRepository(AtividadeContext context) : base(context)
        //{
        //}
        //public void Add(Produto obj)
        //{
        //    Db.Set<Produto>().Add(obj);
        //    Db.SaveChanges();
        //}
        //public IEnumerable<Produto> GetAll()
        //{
        //    return Db.Set<Produto>().ToList();
        //}
        //public Produto GetById(int id)
        //{
        //    return Db.Set<Produto>().Find(id);
        //}
        //public void Remove(Produto obj)
        //{
        //    Db.Set<Produto>().Remove(obj);
        //    Db.SaveChanges();
        //}

    }
}
