using System.Collections.Generic;
using ProjetoModeloDDD.Domain.Entities;

namespace ProjetoModeloDDD.Domain.Interfaces
{
    public interface IRegistroCompraRepository : IRepositoryBase<RegistroCompra>
    {
        IEnumerable<RegistroCompra> BuscarPorNome(string nome);
    }
}
