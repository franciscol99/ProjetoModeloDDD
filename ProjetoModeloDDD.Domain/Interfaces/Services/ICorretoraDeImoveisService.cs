using System.Collections.Generic;
using ProjetoModeloDDD.Domain.Entities;

namespace ProjetoModeloDDD.Domain.Interfaces.Services
{
    public interface ICorretoraDeImoveisService : IServiceBase<CorretoraDeImoveis>
    {
        IEnumerable<CorretoraDeImoveis> BuscarPorNome(string nome);
    }
}
