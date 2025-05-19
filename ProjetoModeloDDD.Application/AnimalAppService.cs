using System.Collections.Generic;
using ProjetoModeloDDD.Application.Interface;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces.Services;

namespace ProjetoModeloDDD.Application
{
    public class AnimalAppService : AppServiceBase<Animal>, IAnimalAppService
    {
        private readonly IAnimalService _animalService;

        public AnimalAppService(IAnimalService animalService)
            : base(animalService)
        {
            _animalService = animalService;
        }

        public IEnumerable<Animal> BuscarPorNome(string nome)
        {
            return _animalService.BuscarPorNome(nome);
        }
    }
}
