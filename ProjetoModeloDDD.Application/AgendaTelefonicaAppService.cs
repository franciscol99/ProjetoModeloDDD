using System.Collections.Generic;
using ProjetoModeloDDD.Application.Interface;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces.Services;

namespace ProjetoModeloDDD.Application
{
    public class AgendaTelefonicaAppService : AppServiceBase<AgendaTelefonica>, IAgendaTelefonicaAppService
    {
        private readonly IAgendaTelefonicaService _agendatelefonicaService;

        public AgendaTelefonicaAppService(IAgendaTelefonicaService agendatelefonicaService)
            : base(agendatelefonicaService)
        {
            _agendatelefonicaService = agendatelefonicaService;
        }

        public IEnumerable<AgendaTelefonica> BuscarPorNome(string nome)
        {
            return _agendatelefonicaService.BuscarPorNome(nome);
        }
    }
}
