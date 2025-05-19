using System.Collections.Generic;
using ProjetoModeloDDD.Domain.Entities;

namespace ProjetoModeloDDD.Domain.Interfaces.Services
{
    public interface IRegistroCompraService : IServiceBase<RegistroCompra>
    {
        IEnumerable<RegistroCompra> BuscarPorNome(string nome);
    }
}
