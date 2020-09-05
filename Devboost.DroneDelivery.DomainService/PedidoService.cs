using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Devboost.DroneDelivery.Domain.Entities;
using Devboost.DroneDelivery.Domain.Enums;
using Devboost.DroneDelivery.Domain.Interfaces.Repository;
using Devboost.DroneDelivery.Domain.Interfaces.Services;
using Devboost.DroneDelivery.Domain.Params;

namespace Devboost.DroneDelivery.DomainService
{
    public class PedidoService: IPedidoService
    {
        private readonly IPedidosRepository _pedidosRepository;
        private readonly IViagemService _viagemService;

        public PedidoService( IPedidosRepository pedidosRepository, IViagemService viagemService)
        {
            _pedidosRepository = pedidosRepository;
            _viagemService = viagemService;
        }

        public async Task<bool> InserirPedido(PedidoParam pedido)
        {
            if (!ValidaPedido(pedido, out var novoPedido, out var distancia)) return false;

            if (await SelecionaDroneInserirPedido(novoPedido)) return true;

            return true;
        }

        private async Task<bool> SelecionaDroneInserirPedido(PedidoEntity novoPedido)
        {
            return true;
        }

        private static bool ValidaPedido(PedidoParam pedido, out PedidoEntity novoPedido, out double distancia)
        {
            novoPedido = new PedidoEntity
            {
                PesoGramas = pedido.Peso,
                Latitude = pedido.Latitude,
                Longitude = pedido.Longitude,
                DataHora = pedido.DataHora,
            };

            //calculoDistancia

            distancia = GeolocalizacaoService.CalcularDistanciaEmMetro(pedido.Latitude, pedido.Longitude);

            if (!novoPedido.ValidaPedido(distancia))
                return false;
            return true;
        }

        public async Task<bool> InserirPedidos(List<PedidoParam> pedidos)
        {
           
            return await _viagemService.ProcessarViagem(novoPedido);
        }
        

        public async Task AtualizaPedido(PedidoEntity pedido)
        {
           await _pedidosRepository.Atualizar(pedido);
        }
    }
}