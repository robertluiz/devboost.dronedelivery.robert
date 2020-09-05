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
    public class PedidosRepository : RepositoryBase<Pedido,PedidoEntity>, IPedidosRepository
    {
    
        public PedidosRepository(IConfiguration config) : base(config)
        {
        }
        
        
    }
}