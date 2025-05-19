using System.Collections.Generic;
using System.Linq;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces;

namespace ProjetoModeloDDD.Infra.Data.Repositories
{
    public class MusicaRepository : RepositoryBase<Musica>, IMusicaRepository
    {
        public IEnumerable<Musica> BuscarPorNome(string nome)
        {
            return Db.Musicas.Where(p => p.Nome == nome);
        }
    }
}
