﻿using System.Collections.Generic;
using ProjetoModeloDDD.Domain.Entities;

namespace ProjetoModeloDDD.Domain.Interfaces.Services
{
    public interface IAnimalService : IServiceBase<Animal>
    {
        IEnumerable<Animal> BuscarPorNome(string nome);
    }
}
