using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Devboost.DroneDelivery.Domain.Entities;
using Devboost.DroneDelivery.Repository.Models;
using Devboost.DroneDelivery.Repository.Utils;
using Microsoft.Extensions.Configuration;
using ServiceStack;
using ServiceStack.Data;
using ServiceStack.OrmLite;

namespace Devboost.DroneDelivery.Repository.Implementation
{
    public abstract class RepositoryBase<T,E> :IDisposable
    {
        private readonly string _configConnectionString = "DroneDelivery";
        protected readonly IDbConnectionFactoryExtended DbFactory;

        public RepositoryBase(IConfiguration config)
        {
            DbFactory = new OrmLiteConnectionFactory(
                config.GetConnectionString(_configConnectionString),  
                SqlServerDialect.Provider);
        }
        public virtual async Task Inserir(E viagem)
        {
            var model = viagem.ConvertTo<T>();
            using var conn = await DbFactory.OpenAsync();
            
            await conn.CheckBase();
            await conn.SaveAsync(model,references:true);
        }
        
        public virtual async Task Atualizar(E pedido)
        {
            var model = pedido.ConvertTo<T>();
            using var conn = await DbFactory.OpenAsync();
            
            await conn.CheckBase();
            await conn.UpdateAsync(model);
         
        }
        public virtual async Task<List<E>> GetAll()
        {
            
            using var conn = await DbFactory.OpenAsync();
            await conn.CheckBase();
            
            var list = await conn.SelectAsync<T>();
            return list.ConvertTo<List<E>>();

        }
        public virtual async Task<E> GetById(Guid id)
        {
            
            using var conn = await DbFactory.OpenAsync();
            await conn.CheckBase();
            
            var model = await conn.SingleAsync<T>(new {Id = id});
            return model.ConvertTo<E>();

        }
        public void Dispose() { }
    }
}