using System.Collections.Generic;
using ProjetoModeloDDD.Domain.Entities;

namespace ProjetoModeloDDD.Application.Interface
{
    public interface ICorretoraDeImoveisAppService : IAppServiceBase<CorretoraDeImoveis>
    {
        IEnumerable<CorretoraDeImoveis> BuscarPorNome(string nome);
    }
}
