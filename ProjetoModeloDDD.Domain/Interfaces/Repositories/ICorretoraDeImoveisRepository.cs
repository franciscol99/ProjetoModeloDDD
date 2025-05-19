using System.Collections.Generic;
using ProjetoModeloDDD.Domain.Entities;

namespace ProjetoModeloDDD.Domain.Interfaces
{

    public interface ICorretoraDeImoveisRepository : IRepositoryBase<CorretoraDeImoveis>
    {
        IEnumerable<CorretoraDeImoveis> BuscarPorNome(string nome);
    }
}
