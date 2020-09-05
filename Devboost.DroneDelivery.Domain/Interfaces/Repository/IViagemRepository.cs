using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Devboost.DroneDelivery.Domain.Entities;

namespace Devboost.DroneDelivery.Domain.Interfaces.Repository
{
    public interface IViagemRepository
    {
        Task<List<ViagemEntity>> GetAll();
        Task Inserir(ViagemEntity viagem);
        Task Atualizar(ViagemEntity viagem);
        Task<ViagemEntity> GetById(Guid id);
        Task<ViagemEntity> GetByDroneID(Guid droneId);
        
    }
}