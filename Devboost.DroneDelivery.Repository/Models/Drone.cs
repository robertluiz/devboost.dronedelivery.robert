using System;
using System.ComponentModel.DataAnnotations.Schema;
using Devboost.DroneDelivery.Domain.Enums;
using ServiceStack.DataAnnotations;

namespace Devboost.DroneDelivery.Repository.Models
{
    [Table("dbo.Drone")]
    public class Drone
    {
        public Drone()
        {
            Id = Guid.NewGuid();
            DataAtualizacao = DateTime.Now;
        }

        public Guid Id { get; set; }
        public DroneStatus Status { get; set; }
        
        [Alias("Capacidade")]
        public int CapacidadeGamas { get; set; }
        
        [Alias("Velocidade")]
        public int VelocidadeKmH { get; set; }
        
        [Alias("Autonomia")]
        public int AutonomiaMinitos { get; set; }
        
        [Alias("Carga")]
        public int CargaGramas { get; set; }
        
        public DateTime DataAtualizacao { get; set; }
    }
}