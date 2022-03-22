using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
    public class InventoriesController : ControllerBase
    {
        private readonly IService<InventoryViewModel> _inventoryService;
        public InventoriesController(IService<InventoryViewModel> inventoryService)
        {
            _inventoryService = inventoryService;
        }

        [HttpGet]
        [Route("/estoques")]
        public async Task<ActionResult<IEnumerable<InventoryViewModel>>> GetAll()
        {
            var inventories = await _inventoryService.GetAll();
            return StatusCode(StatusCodes.Status200OK, inventories);
        }

        [HttpGet]
        [Route("/estoques/{id}")]
        public async Task<ActionResult<InventoryViewModel>> GetById(int? id)
        {
            var inventory = await _inventoryService.GetById(id);

            if (inventory == null) return StatusCode(StatusCodes.Status404NotFound, "Estoque não encontrado. Verifique o Id informado");

            return StatusCode(StatusCodes.Status200OK, inventory);
        }

        [HttpPost]
        [Route("/estoques")]
        public IActionResult Post([Bind("Nome, QuantidadeMinima, Quantidade")] InventoryViewModel inventory)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _inventoryService.Add(inventory);
                    return StatusCode(StatusCodes.Status201Created, "Estoque inserido com sucesso");
                }
                catch (Exception e)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar inserir o estoque. {e.Message}");
                }
            }
            return StatusCode(StatusCodes.Status400BadRequest, inventory);
        }

        [HttpPut]
        [Route("/estoques/{id}")]
        public async Task<IActionResult> PutAsync([Bind("Nome, QuantidadeMinima, Quantidade")] InventoryViewModel inventory, int? id)
        {
            if (inventory.Id != id) return StatusCode(StatusCodes.Status400BadRequest, "Informe um id Válido");

            if (ModelState.IsValid)
            {
                try
                {
                    var model = await _inventoryService.GetById(id);
                    if (model == null) return StatusCode(StatusCodes.Status404NotFound, "Estoque informado não existe");

                    _inventoryService.Update(inventory);
                    return StatusCode(StatusCodes.Status200OK, $"Estoque - {inventory.Nome} - atualizado com sucesso!");
                }
                catch (Exception e)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar atualizar o estoque. {e.Message}");
                }
            }
            return StatusCode(StatusCodes.Status400BadRequest, inventory);
        }

        [HttpDelete]
        [Route("/estoques/{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            try
            {
                var model = await _inventoryService.GetById(id);
                if (model == null) return StatusCode(StatusCodes.Status404NotFound, "Estoque informado não existe");

                _inventoryService.Remove(id);
                return StatusCode(StatusCodes.Status200OK, "Estoque deletado com sucesso");
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar deletar o estoque. {e.Message}");
            }
        }
    }
}
