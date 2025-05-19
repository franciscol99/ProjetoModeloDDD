using System.Collections.Generic;
using System.Linq;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces;

namespace ProjetoModeloDDD.Infra.Data.Repositories
{
    public class CorretoraDeImoveisRepository : RepositoryBase<CorretoraDeImoveis>, ICorretoraDeImoveisRepository
    {
        public IEnumerable<CorretoraDeImoveis> BuscarPorNome(string nome)
        {
            return Db.CorretoraDeImoveis.Where(p => p.Endereco == nome);
        }
    }
}
