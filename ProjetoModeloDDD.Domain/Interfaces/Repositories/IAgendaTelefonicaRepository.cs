using System.Collections.Generic;
using ProjetoModeloDDD.Domain.Entities;

namespace ProjetoModeloDDD.Domain.Interfaces
{

    public interface IAgendaTelefonicaRepository : IRepositoryBase<AgendaTelefonica>
    {
        IEnumerable<AgendaTelefonica> BuscarPorNome(string nome);
    }
}
