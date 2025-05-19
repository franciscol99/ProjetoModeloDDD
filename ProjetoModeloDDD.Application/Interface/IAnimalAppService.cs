using System.Collections.Generic;
using ProjetoModeloDDD.Domain.Entities;

namespace ProjetoModeloDDD.Application.Interface
{
    public interface IAnimalAppService : IAppServiceBase<Animal>
    {
        IEnumerable<Animal> BuscarPorNome(string nome);
    }
}
