using System.Collections.Generic;
using ProjetoModeloDDD.Domain.Entities;

namespace ProjetoModeloDDD.Application.Interface
{
    public interface IRegistroCompraAppService : IAppServiceBase<RegistroCompra>
    {
        IEnumerable<RegistroCompra> BuscarPorNome(string nome);
    }
}
