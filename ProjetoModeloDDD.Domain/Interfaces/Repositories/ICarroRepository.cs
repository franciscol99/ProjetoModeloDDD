using System.Collections.Generic;
using ProjetoModeloDDD.Domain.Entities;

namespace ProjetoModeloDDD.Domain.Interfaces
{

    public interface ICarroRepository : IRepositoryBase<Carro>
    {
        IEnumerable<Carro> BuscarPorNome(string nome);
    }
}
