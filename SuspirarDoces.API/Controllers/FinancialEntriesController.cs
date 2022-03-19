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
    public class FinancialEntriesController: ControllerBase
    {
        private readonly IService<FinancialEntryViewModel> _entryService;
        public FinancialEntriesController(IService<FinancialEntryViewModel> entryService)
        {
            _entryService = entryService;
        }

        [HttpGet]
        [Route("/entradas")]
        public async Task<ActionResult<IEnumerable<FinancialEntryViewModel>>> GetAll()
        {
            var entries = await _entryService.GetAll();
            return StatusCode(StatusCodes.Status200OK, entries);
        }

        [HttpGet]
        [Route("/entradas/{id}")]
        public async Task<ActionResult<FinancialEntryViewModel>> GetById(int? id)
        {
            var entry = await _entryService.GetById(id);

            if (entry == null) return StatusCode(StatusCodes.Status404NotFound, "Entrada não encontrada. Verifique o Id informado");

            return StatusCode(StatusCodes.Status200OK, entry);
        }

        [HttpPost]
        [Route("/entradas")]
        public IActionResult Post([Bind("PedidoId, Nome, Valor, Descricao, Data")] FinancialEntryViewModel entry)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _entryService.Add(entry);
                    return StatusCode(StatusCodes.Status201Created, "Entrada inserida com sucesso");
                }
                catch (Exception e)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar inserir a entrada. {e.Message}");
                }
            }
            return StatusCode(StatusCodes.Status400BadRequest, entry);
        }

        [HttpPut]
        [Route("/entradas/{id}")]
        public async Task<IActionResult> PutAsync([Bind("PedidoId, Nome, Valor, Descricao, Data")] FinancialEntryViewModel entry, int? id)
        {
            if (entry.Id != id) return StatusCode(StatusCodes.Status400BadRequest, "Informe um id Válido");

            if (ModelState.IsValid)
            {
                try
                {
                    var model = await _entryService.GetById(id);
                    if (model == null) return StatusCode(StatusCodes.Status404NotFound, "Entrada informada não existe");

                    _entryService.Update(entry);
                    return StatusCode(StatusCodes.Status200OK, "Entrada atualizada com sucesso!");
                }
                catch (Exception e)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar atualizar a entrada. {e.Message}");
                }
            }
            return StatusCode(StatusCodes.Status400BadRequest, entry);
        }

        [HttpDelete]
        [Route("/entradas/{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            try
            {
                var model = await _entryService.GetById(id);
                if (model == null) return StatusCode(StatusCodes.Status404NotFound, "Entrada informada não existe");

                _entryService.Remove(id);
                return StatusCode(StatusCodes.Status200OK, "Entrada deletada com sucesso");
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar deletar a entrada. {e.Message}");
            }
        }
    }
}
