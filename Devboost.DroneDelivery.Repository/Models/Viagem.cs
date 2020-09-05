using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using ServiceStack.DataAnnotations;

namespace Devboost.DroneDelivery.Repository.Models
{
    [Table("dbo.Viagem")]
    public class Viagem
    {
        public Viagem()
        {
            Id = Guid.NewGuid();
            InicioViagem = DateTime.Now;
        }
        public Guid Id { get; set; }
        
        [Reference]
        public virtual List<Pedido> Pedidos { get; set; }
        
        [Reference]
        public virtual Drone Drone { get; set; }
        
        [References(typeof(Drone))]
        public Guid DroneId { get; set; }
        
        public DateTime InicioViagem { get; set; }
        
        public DateTime? FimViagem { get; set; }

        public double DistanciaTotalMetros { get; set; }
        
      
    }
}