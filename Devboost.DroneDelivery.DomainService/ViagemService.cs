using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Devboost.DroneDelivery.Domain.Entities;
using Devboost.DroneDelivery.Domain.Interfaces.Repository;
using Devboost.DroneDelivery.Domain.Interfaces.Services;

namespace Devboost.DroneDelivery.DomainService
{
    public class ViagemService: IViagemService
    {
        private readonly IDroneService _droneService;
        private readonly IViagemRepository _viagemRepository;

        public ViagemService(IViagemRepository viagemRepository, IDroneService droneService)
        {
            _viagemRepository = viagemRepository;
            _droneService = droneService;
        }

        public async Task<bool> ProcessarViagem(List<PedidoEntity> pedidos)
        {
            var drone = await _droneService.SelecionarDrone();
            var teste = new ViagemEntity
            {
                Id = Guid.NewGuid(),
                DistanciaTotalMetros = 1000,
                Drone = drone,
                DroneId = drone.Id,
                InicioViagem = DateTime.Now,
                Pedidos = pedidos
            };
            await _viagemRepository.Inserir(teste);
            return true;
        }
        
        public async Task<bool> ProcessarViagem(PedidoEntity pedido)
        {
            var drone = await _droneService.SelecionarDrone();
            
            await _viagemRepository.Inserir(teste);
            return true;
        }
        
        public async Task<ViagemEntity> RecuperaViagem()
        {
            var drone = await _droneService.SelecionarDrone();
            
            await _viagemRepository.Inserir(teste);
            return true;
        }
        
    }
}