﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Devboost.DroneDelivery.Domain.Entities;
using Devboost.DroneDelivery.Domain.Params;

namespace Devboost.DroneDelivery.Domain.Interfaces.Services
{
    public interface IPedidoService
    {
        Task<bool> InserirPedido(PedidoParam Pedido);
        Task<bool> InserirPedidos(List<PedidoParam> Pedidos);
        Task AtualizaPedido(PedidoEntity pedido);
    }
}