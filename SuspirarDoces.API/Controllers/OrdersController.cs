using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuspirarDoces.Application.Interfaces;
using SuspirarDoces.Application.ViewsModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuspirarDoces.API.Controllers
{
    [ApiController]
    public class OrdersController: ControllerBase
    {
        private readonly IService<OrderViewModel> _orderService;
        public OrdersController(IService<OrderViewModel> orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        [Route("/pedidos")]
        public async Task<ActionResult<IEnumerable<OrderViewModel>>> GetAll()
        {
            var orders = await _orderService.GetAll();
            return StatusCode(StatusCodes.Status200OK, orders);
        }

        [HttpGet]
        [Route("/pedidos/{id}")]
        public async Task<ActionResult<OrderViewModel>> GetById(int? id)
        {
            var order = await _orderService.GetById(id);

            if (order == null) return StatusCode(StatusCodes.Status404NotFound, "Pedido não encontrado. Verifique o Id informado");

            return StatusCode(StatusCodes.Status200OK, order);
        }

        [HttpPost]
        [Route("/pedidos")]
        public IActionResult Post([Bind("IdCliente, DataDoPedido, DataDeEntrega, LocalDeEntrega, ValorTotal, ValorDeEntrada, ValorAPagar, Status, ProdutosPedidos")] OrderViewModel order)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _orderService.Add(order);
                    return StatusCode(StatusCodes.Status201Created, "Pedido inserido com sucesso");
                }
                catch (Exception e)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar inserir o pedido. {e.Message}");
                }
            }
            return StatusCode(StatusCodes.Status400BadRequest, order);
        }

        [HttpPut]
        [Route("/pedidos/{id}")]
        public async Task<IActionResult> PutAsync([Bind("IdCliente, DataDoPedido, DataDeEntrega, LocalDeEntrega, ValorTotal, ValorDeEntrada, ValorAPagar, Status, ProdutosPedidos")] OrderViewModel order, int? id)
        {
            if (order.Id != id) return StatusCode(StatusCodes.Status400BadRequest, "Informe um id Válido");

            if (ModelState.IsValid)
            {
                try
                {
                    var model = await _orderService.GetById(id);
                    if (model == null) return StatusCode(StatusCodes.Status404NotFound, "Pedido informado não existe");

                    _orderService.Update(order);
                    return StatusCode(StatusCodes.Status200OK, $"Pedido atualizado com sucesso!");
                }
                catch (Exception e)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar atualizar o pedido. {e.Message}");
                }
            }
            return StatusCode(StatusCodes.Status400BadRequest, order);
        }

        [HttpDelete]
        [Route("/pedidos/{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            try
            {
                var model = await _orderService.GetById(id);
                if (model == null) return StatusCode(StatusCodes.Status404NotFound, "Pedido informado não existe");

                _orderService.Remove(id);
                return StatusCode(StatusCodes.Status200OK, "Pedido deletado com sucesso");
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar deletar o pedido. {e.Message}");
            }
        }
    }
}
