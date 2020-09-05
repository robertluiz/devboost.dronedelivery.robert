using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Devboost.DroneDelivery.Domain.Interfaces.Services;
using Devboost.DroneDelivery.Domain.Params;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Devboost.DroneDelivery.Api.Controllers
{
    [Route("v1/pedido")]
    [ApiController]
    public class PedidoController : Controller
    {
        private readonly IPedidoService _pedidoService;

        public PedidoController(IPedidoService pedidoService)
        {
            _pedidoService = pedidoService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult>  ReceberPedido(PedidoParam pedido)
        {
            try
            {
               var resultado = await _pedidoService.InserirPedido(pedido);
               if (!resultado)
                   return BadRequest("Pedido não aceito");
               return Ok();
            }
            catch (Exception e)
            {
              return StatusCode(StatusCodes.Status500InternalServerError, e.Message);

            }

        }
        [HttpPost("lista")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult>  ReceberListaPedido(List<PedidoParam> pedidos)
        {
            try
            {
                var resultado = await _pedidoService.InserirPedidos(pedidos);
                if (!resultado)
                    return BadRequest("Pedido não aceito");
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);

            }

        }
    }
}