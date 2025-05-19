using System.Collections.Generic;
using System.Linq;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces;

namespace ProjetoModeloDDD.Infra.Data.Repositories
{
    public class AnimalRepository : RepositoryBase<Animal>, IAnimalRepository
    {
        public IEnumerable<Animal> BuscarPorNome(string nome)
        {
            return Db.Animais.Where(p => p.Nome == nome);
        }
    }
}
