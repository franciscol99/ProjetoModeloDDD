using System.Collections.Generic;
using ProjetoModeloDDD.Domain.Entities;

namespace ProjetoModeloDDD.Domain.Interfaces
{
 
    public interface ILivroRepository : IRepositoryBase<Livro>
    {
        IEnumerable<Livro> BuscarPorNome(string nome);
    }
}
