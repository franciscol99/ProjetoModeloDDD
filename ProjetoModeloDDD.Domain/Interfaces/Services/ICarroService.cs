﻿using System.Collections.Generic;
using ProjetoModeloDDD.Domain.Entities;

namespace ProjetoModeloDDD.Domain.Interfaces.Services
{
    public interface ICarroService : IServiceBase<Carro>
    {
        IEnumerable<Carro> BuscarPorNome(string nome);
    }
}
