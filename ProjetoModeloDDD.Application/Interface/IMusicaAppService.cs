﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoModeloDDD.Domain.Entities;

namespace ProjetoModeloDDD.Application.Interface
{
    public interface IMusicaAppService : IAppServiceBase<Musica>
    {
        IEnumerable<Musica> BuscarPorNome(string nome);
    }
}
