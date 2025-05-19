using System.Collections.Generic;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces;
using ProjetoModeloDDD.Domain.Interfaces.Services;

namespace ProjetoModeloDDD.Domain.Services
{
    public class CarroService : ServiceBase<Carro>, ICarroService
    {
        private readonly ICarroRepository _carroRepository;

        public CarroService(ICarroRepository carroRepository)
            : base(carroRepository)
        {
            _carroRepository = carroRepository;
        }

        public IEnumerable<Carro> BuscarPorNome(string nome)
        {
            return _carroRepository.BuscarPorNome(nome);
        }
    }
}
