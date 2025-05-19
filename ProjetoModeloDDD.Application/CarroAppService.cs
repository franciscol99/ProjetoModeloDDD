using System.Collections.Generic;
using ProjetoModeloDDD.Application.Interface;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces.Services;

namespace ProjetoModeloDDD.Application
{
    public class CarroAppService : AppServiceBase<Carro>, ICarroAppService
    {
        private readonly ICarroService _carroService;

        public CarroAppService(ICarroService carroService)
            : base(carroService)
        {
            _carroService = carroService;
        }

        public IEnumerable<Carro> BuscarPorNome(string nome)
        {
            return _carroService.BuscarPorNome(nome);
        }
    }
}
