using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Devboost.DroneDelivery.Domain.Entities;
using Devboost.DroneDelivery.Domain.Interfaces.Repository;
using Devboost.DroneDelivery.Repository.Models;
using Devboost.DroneDelivery.Repository.Utils;
using Microsoft.Extensions.Configuration;
using ServiceStack;
using ServiceStack.OrmLite;

namespace Devboost.DroneDelivery.Repository.Implementation
{
    public class ViagemRepository :RepositoryBase<Viagem,ViagemEntity>, IViagemRepository
    {
        public ViagemRepository(IConfiguration config) : base(config)
        {
        }
        
        public override async Task<List<ViagemEntity>> GetAll()
        {
            using var conexao = await DbFactory.OpenAsync();
            await conexao.CheckBase();
           
            var q = conexao.From<Viagem>()
                .Join<Pedido>()
                .Join<Drone>();
            
            var list = await conexao.SelectAsync(q);

            return list.ConvertTo<List<ViagemEntity>>();

        }
        

        public async Task<ViagemEntity> GetByDroneID(Guid droneId)
        {
            using var conexao = await DbFactory.OpenAsync();
            await conexao.CheckBase();
            var q = conexao.From<Viagem>()
                .Join<Pedido>()
                .Join<Drone>()
                .Where(v => v.FimViagem == null && v.DroneId == droneId);
            
            var model = await conexao.SingleAsync(q);
            return model.ConvertTo<ViagemEntity>();
        }

       
    }
}