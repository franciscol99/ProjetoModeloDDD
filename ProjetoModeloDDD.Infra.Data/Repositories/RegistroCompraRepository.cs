using System.Collections.Generic;
using System.Linq;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces;

namespace ProjetoModeloDDD.Infra.Data.Repositories
{
    public class RegistroCompraRepository : RepositoryBase<RegistroCompra>, IRegistroCompraRepository
    {
        public IEnumerable<RegistroCompra> BuscarPorNome(string nome)
        {
            return Db.RegistroCompras.Where(p => p.ListaProdutos.Any(x => x.Nome.Contains(nome)));
            //return Db.RegistroCompras.Where(p => p.Nome == nome);
        }

    }
}
