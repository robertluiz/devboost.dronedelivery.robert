using System;
using System.Collections.Generic;

namespace Devboost.DroneDelivery.Domain.Entities
{
    public class ViagemEntity
    {
        public Guid Id { get; set; }
        
        public virtual List<PedidoEntity> Pedidos { get; set; }
        
        public virtual DroneEntity Drone { get; set; }
        
        public Guid DroneId { get; set; }
        
        public DateTime InicioViagem { get; set; }
        public DateTime? FimViagem { get; set; }

        public double DistanciaTotalMetros { get; set; }
        
        public readonly double CAPACIDADE_EM_GRAMAS = 12000;
    }
}