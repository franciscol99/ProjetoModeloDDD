using System.Collections.Generic;
using ProjetoModeloDDD.Domain.Entities;

namespace ProjetoModeloDDD.Domain.Interfaces
{

    public interface IAnimalRepository : IRepositoryBase<Animal>
    {
        IEnumerable<Animal> BuscarPorNome(string nome);
    }
   
}
