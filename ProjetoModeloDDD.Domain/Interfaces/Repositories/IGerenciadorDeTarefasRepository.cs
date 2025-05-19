using System.Collections.Generic;
using ProjetoModeloDDD.Domain.Entities;

namespace ProjetoModeloDDD.Domain.Interfaces
{

    public interface IGerenciadorDeTarefasRepository : IRepositoryBase<GerenciadorDeTarefas>
    {
        IEnumerable<GerenciadorDeTarefas> BuscarPorNome(string nome);
    }
}
