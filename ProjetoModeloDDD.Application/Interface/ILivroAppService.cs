using System.Collections.Generic;
using ProjetoModeloDDD.Domain.Entities;

namespace ProjetoModeloDDD.Application.Interface
{
    public interface ILivroAppService : IAppServiceBase<Livro>
    {
        IEnumerable<Livro> BuscarPorNome(string nome);
    }
}
