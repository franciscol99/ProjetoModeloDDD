using System.Collections.Generic;
using ProjetoModeloDDD.Application.Interface;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces.Services;

namespace ProjetoModeloDDD.Application
{
    public class AgendaAppService : AppServiceBase<Agenda>, IAgendaAppService
    {
        private readonly IAgendaService _agendaService;

        public AgendaAppService(IAgendaService agendaService)
            : base(agendaService)
        {
            _agendaService = agendaService;
        }

        public IEnumerable<Agenda> BuscarPorNome(string nome)
        {
            return _agendaService.BuscarPorNome(nome);
        }
    }
}
