﻿using System;
using System.Collections.Generic;
using ProjetoModeloDDD.Application.Interface;
using ProjetoModeloDDD.Domain.Interfaces.Services;

namespace ProjetoModeloDDD.Application
{
    public class AppServiceBase<TEntity> : IDisposable, IAppServiceBase<TEntity> where TEntity : class
    {
        private readonly IServiceBase<TEntity> _serviceBase;

        public AppServiceBase(IServiceBase<TEntity> serviceBase)
        {
            _serviceBase = serviceBase;
        }

        public void Add(TEntity obj) 
        {
            _serviceBase.Add(obj);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _serviceBase.GetAll();
        }

        public TEntity GetById(int id)
        {
            return _serviceBase.GetById(id);
        }


        public void Remove(TEntity obj) 
        {
            _serviceBase.Remove(obj);
        }

        public int SaveChanges()
        {
            throw new NotImplementedException();
        }

        //public IEnumerable<TEntity> Search<TEntity>(Func<TEntity, bool> predicate) where TEntity : class
        //{

        //    return _serviceBase.Search(Func<TEntity, bool> predicate);
        //}

        public void Update(TEntity obj)
        {
            _serviceBase.Update(obj);
        }

        public void Dispose()
        {
            _serviceBase.Dispose();
        }
    }
}
