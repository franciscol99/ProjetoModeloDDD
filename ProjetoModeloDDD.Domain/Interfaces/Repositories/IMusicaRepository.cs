using System.Collections.Generic;
using ProjetoModeloDDD.Domain.Entities;

namespace ProjetoModeloDDD.Domain.Interfaces
{

    public interface IMusicaRepository : IRepositoryBase<Musica>
    {
        IEnumerable<Musica> BuscarPorNome(string nome);
    }
}
