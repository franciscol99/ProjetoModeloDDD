using System.Collections.Generic;
using System.Linq;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces;

namespace ProjetoModeloDDD.Infra.Data.Repositories
{
    public class CarroRepository : RepositoryBase<Carro>, ICarroRepository
    {
        public IEnumerable<Carro> BuscarPorNome(string nome)
        {
            return Db.Carros.Where(p => p.Nome == nome);
        }
    }
}
