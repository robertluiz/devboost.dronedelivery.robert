using System;
using System.ComponentModel.DataAnnotations.Schema;
using Devboost.DroneDelivery.Domain.Enums;
using ServiceStack.DataAnnotations;

namespace Devboost.DroneDelivery.Repository.Models
{
    [Table("dbo.Pedido")]
    public class Pedido
    {
        public Pedido()
        {
            Id = Guid.NewGuid();
            DataHora = DateTime.Now;
        }

        public Guid Id { get; set; }
        
        public int Peso { get; set; }
        
        public double Latitude { get; set; }
        
        public double Longitude { get; set; }
        public PedidoStatus Status { get; set; }
        
        [Reference]
        public virtual Viagem Viagem { get; set; }
        public DateTime? DataHora { get; set; }
        
        [References(typeof(Viagem))]
        public Guid? ViagemId { get; set; }
    }
}