using System;
using Devboost.DroneDelivery.Domain.Enums;

namespace Devboost.DroneDelivery.Domain.Entities
{
    public class PedidoEntity
    {
        public Guid Id { get; set; }
        public int PesoGramas {get; set;}
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public DateTime? DataHora { get; set; }
        public PedidoStatus Status { get; set; }
        public virtual ViagemEntity Viagem { get; set; }
        public Guid? ViajemId { get; set; }
        public readonly double DistanciaMaxima = 17000;
        public readonly int PesoGamasMaximo = 12000;

        public bool ValidaPedido(double distanciaMetros)
        {
            return distanciaMetros <= DistanciaMaxima && PesoGramas <= PesoGamasMaximo;
        }
    }
}