using System.Collections.Generic;
using ProjetoModeloDDD.Domain.Entities;

namespace ProjetoModeloDDD.Domain.Interfaces.Services
{
    public interface IFabricanteService : IServiceBase<Fabricante>
    {
        IEnumerable<Fabricante> BuscarPorNome(string nome);
    }
}
