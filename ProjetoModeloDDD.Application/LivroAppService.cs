using System.Collections.Generic;
using ProjetoModeloDDD.Application.Interface;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces.Services;

namespace ProjetoModeloDDD.Application
{
    public class LivroAppService : AppServiceBase<Livro>, ILivroAppService
    {
        private readonly ILivroService _livroService;

        public LivroAppService(ILivroService livroService)
            : base(livroService)
        {
            _livroService = livroService;
        }

        public IEnumerable<Livro> BuscarPorNome(string nome)
        {
            return _livroService.BuscarPorNome(nome);
        }
    }
}
