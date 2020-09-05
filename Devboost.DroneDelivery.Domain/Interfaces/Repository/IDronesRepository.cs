using System;
using Devboost.DroneDelivery.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using Devboost.DroneDelivery.Domain.Enums;

namespace Devboost.DroneDelivery.Domain.Interfaces.Repository
{
    public interface IDronesRepository
    {
        Task<List<DroneEntity>> GetAll();
        Task<List<DroneEntity>> GetByStatus(DroneStatus status);
        Task Atualizar(DroneEntity drone);
        Task Inserir(DroneEntity drone);
        Task<DroneEntity> GetById(Guid id);

    }
}
