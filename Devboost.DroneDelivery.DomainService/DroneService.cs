﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Devboost.DroneDelivery.Domain.DTOs;
using Devboost.DroneDelivery.Domain.Entities;
using Devboost.DroneDelivery.Domain.Enums;
using Devboost.DroneDelivery.Domain.Interfaces.Repository;
using Devboost.DroneDelivery.Domain.Interfaces.Services;

namespace Devboost.DroneDelivery.DomainService
{
    public class DroneService : IDroneService
    {
        private readonly IDronesRepository _dronesRepository;
        private readonly IPedidosRepository _pedidosRepository;
        public DroneService(IDronesRepository dronesRepository, IPedidosRepository pedidosRepository)
        {
            _dronesRepository = dronesRepository;
            _pedidosRepository = pedidosRepository;
        }

        public async Task<List<ConsultaDronePedidoDTO>> ConsultaDrone()
        {
           var listaDrones = await _dronesRepository.GetAll();
           AtualizaStatusDrones(listaDrones);
           var drones = await _dronesRepository.GetAll();
           return  drones.Select(async d => await RetornConsultaDronePedido(d))
               .ToList()
               .Select(c => c.Result)
               .ToList();

        }

        private async Task<ConsultaDronePedidoDTO> RetornConsultaDronePedido(DroneEntity drone)
        {
            
            return new ConsultaDronePedidoDTO
            {

                IdDrone = drone.Id,
                Situacao = drone.Status.ToString()
            };
        }
        
        public async Task<DroneEntity> SelecionarDrone()
        {
            var listaDrones = await _dronesRepository.GetAll();

            AtualizaStatusDrones(listaDrones);
            var drones = await _dronesRepository.GetByStatus(DroneStatus.Pronto);
            return drones.Count > 0 ? drones[0] : null;
        }

        public async Task AtualizaDrone(DroneEntity drone)
        {
          await _dronesRepository.Atualizar(drone);
        }

        private void AtualizaStatusDrones(List<DroneEntity> lista)
        {
            lista.ForEach(async (d) => await AtualizaStatusDrones(d));
        }
        private async Task AtualizaStatusDrones(DroneEntity drone)
        {
            drone.DataAtualizacao ??= DateTime.Now;
            var total = (drone.DataAtualizacao - DateTime.Now).Value.TotalMinutes;
            
            switch (drone.Status)
            {
                case DroneStatus.Pronto:
                    break;
                case DroneStatus.EmTransito:
                    
                    if (total > drone.AUTONOMIA_RECARGA)
                    {
                        drone.Status = DroneStatus.Pronto;
                        drone.DataAtualizacao = DateTime.Now;
                        await _dronesRepository.Atualizar(drone);
                       
                    }

                    if (total > drone.AUTONOMIA_MAXIMA)
                    {
                        drone.Status = DroneStatus.Carregando;
                        drone.DataAtualizacao = DateTime.Now;
                        await  _dronesRepository.Atualizar(drone);
                      
                    }
                    
                    break;
                case DroneStatus.Carregando:
                    if (total > drone.TEMPO_RECARGA_MINUTOS)
                    {
                        drone.Status = DroneStatus.Pronto;
                        drone.DataAtualizacao = DateTime.Now;
                        await _dronesRepository.Atualizar(drone);
                    }
                    break;
                default:
                    drone.Status = DroneStatus.Pronto;
                    drone.DataAtualizacao = DateTime.Now;
                    await _dronesRepository.Atualizar(drone);
                    break;
            }
        }
    }
}