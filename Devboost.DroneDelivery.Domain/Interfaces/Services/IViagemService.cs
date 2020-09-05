using System.Collections.Generic;
using System.Threading.Tasks;
using Devboost.DroneDelivery.Domain.Entities;

namespace Devboost.DroneDelivery.Domain.Interfaces.Services
{
    public interface IViagemService
    {
        Task<bool> ProcessarViagem(List<PedidoEntity> pedidos);
    }
}