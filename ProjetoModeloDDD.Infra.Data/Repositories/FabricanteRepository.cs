using System.Collections.Generic;
using System.Linq;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces;

namespace ProjetoModeloDDD.Infra.Data.Repositories
{
    public class FabricanteRepository : RepositoryBase<Fabricante>, IFabricanteRepository
    {
        public IEnumerable<Fabricante> BuscarPorNome(string nome)
        {
            return Db.Fabricantes.Where(p => p.Nome == nome);
        }
    }
}
