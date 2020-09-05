using System.Collections.Generic;
using System.Threading.Tasks;
using Devboost.DroneDelivery.Domain.Entities;
using Devboost.DroneDelivery.Domain.Enums;
using Devboost.DroneDelivery.Domain.Interfaces.Repository;
using Devboost.DroneDelivery.Repository.Models;
using Devboost.DroneDelivery.Repository.Utils;
using Microsoft.Extensions.Configuration;
using ServiceStack;
using ServiceStack.OrmLite;

namespace Devboost.DroneDelivery.Repository.Implementation
{
    public class DronesRepository : RepositoryBase<Drone,DroneEntity>, IDronesRepository
    {
        public DronesRepository(IConfiguration config) : base(config)
        {
        }
        
   

        public async Task<List<DroneEntity>> GetByStatus(DroneStatus status)
        {
            using var conn = await DbFactory.OpenAsync();
            await conn.CheckBase();
            
            var list = await conn.SelectAsync<Drone>(d => d.Status == status);
            return list.ConvertTo<List<DroneEntity>>();
        }
        
    }
}