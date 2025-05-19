using System.Collections.Generic;
using ProjetoModeloDDD.Domain.Entities;

namespace ProjetoModeloDDD.Application.Interface
{
    public interface IFabricanteAppService : IAppServiceBase<Fabricante>
    {
        IEnumerable<Fabricante> BuscarPorNome(string nome);
    }
}
