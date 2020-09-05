using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Devboost.DroneDelivery.Domain.Enums;
using Devboost.DroneDelivery.Repository.Models;
using ServiceStack.OrmLite;

namespace Devboost.DroneDelivery.Repository.Utils
{
    public static class SeedExtensions
    {
        public static async Task CheckBase(this IDbConnection con)
        {
            if (con.CreateTableIfNotExists<Drone>())
            {
                await con.InsertAllAsync(SeedDrone());
            }
            con.CreateTableIfNotExists<Viagem>();
            con.CreateTableIfNotExists<Pedido>();
            
        }
        
        private static IEnumerable<Drone> SeedDrone()
        {
            return new List<Drone>
            {
                new Drone
                {
                    Id = Guid.NewGuid(),
                    Status = DroneStatus.Pronto,
                    AutonomiaMinitos = 35,
                    CapacidadeGamas = 12000,
                    VelocidadeKmH = 60,
                    DataAtualizacao = DateTime.Now
                },
                new Drone
                {
                    Id = Guid.NewGuid(),
                    Status = DroneStatus.Pronto,
                    AutonomiaMinitos = 35,
                    CapacidadeGamas = 12000,
                    VelocidadeKmH = 60,
                    DataAtualizacao = DateTime.Now
                },
                new Drone
                {
                    Id = Guid.NewGuid(),
                    Status = DroneStatus.Pronto,
                    AutonomiaMinitos = 35,
                    CapacidadeGamas = 12000,
                    VelocidadeKmH = 60,
                    DataAtualizacao = DateTime.Now
                },
                new Drone
                {
                    Id = Guid.NewGuid(),
                    Status = DroneStatus.Pronto,
                    AutonomiaMinitos = 35,
                    CapacidadeGamas = 12000,
                    VelocidadeKmH = 60,
                    DataAtualizacao = DateTime.Now
                },
                new Drone
                {
                    Id = Guid.NewGuid(),
                    Status = DroneStatus.Pronto,
                    AutonomiaMinitos = 35,
                    CapacidadeGamas = 12000,
                    VelocidadeKmH = 60,
                    DataAtualizacao = DateTime.Now
                },
                new Drone
                {
                    Id = Guid.NewGuid(),
                    Status = DroneStatus.Pronto,
                    AutonomiaMinitos = 35,
                    CapacidadeGamas = 12000,
                    VelocidadeKmH = 60,
                    DataAtualizacao = DateTime.Now
                },
                new Drone
                {
                    Id = Guid.NewGuid(),
                    Status = DroneStatus.Pronto,
                    AutonomiaMinitos = 35,
                    CapacidadeGamas = 12000,
                    VelocidadeKmH = 60,
                    DataAtualizacao = DateTime.Now
                },
            };
        }
    }
}