using System.Collections.Generic;
using ProjetoModeloDDD.Domain.Entities;

namespace ProjetoModeloDDD.Application.Interface
{
    public interface ICarroAppService : IAppServiceBase<Carro>
    {
        IEnumerable<Carro> BuscarPorNome(string nome);
    }
}
