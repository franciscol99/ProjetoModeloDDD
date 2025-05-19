using System.Collections.Generic;
using ProjetoModeloDDD.Domain.Entities;

namespace ProjetoModeloDDD.Domain.Interfaces
{

    public interface IFabricanteRepository : IRepositoryBase<Fabricante>
    {
        IEnumerable<Fabricante> BuscarPorNome(string nome);
    }
}
