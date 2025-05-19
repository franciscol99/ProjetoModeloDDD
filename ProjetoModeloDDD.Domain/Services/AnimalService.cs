using System.Collections.Generic;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces.Services;
using ProjetoModeloDDD.Domain.Interfaces;

namespace ProjetoModeloDDD.Domain.Services
{
    public class AnimalService : ServiceBase<Animal>, IAnimalService
    {
        private readonly IAnimalRepository _animalRepository;

        public AnimalService(IAnimalRepository animalRepository)
            : base(animalRepository)
        {
            _animalRepository = animalRepository;
        }

        public IEnumerable<Animal> BuscarPorNome(string nome)
        {
            return _animalRepository.BuscarPorNome(nome);
        }
    }
}
