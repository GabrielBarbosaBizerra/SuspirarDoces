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
    public class FinancialOutputsController: ControllerBase
    {
        private readonly IService<FinancialOutputViewModel> _outputService;
        public FinancialOutputsController(IService<FinancialOutputViewModel> outputService)
        {
            _outputService = outputService;
        }

        [HttpGet]
        [Route("/saidas")]
        public async Task<ActionResult<IEnumerable<FinancialOutputViewModel>>> GetAll()
        {
            var outputs = await _outputService.GetAll();
            return StatusCode(StatusCodes.Status200OK, outputs);
        }

        [HttpGet]
        [Route("/saidas/{id}")]
        public async Task<ActionResult<FinancialOutputViewModel>> GetById(int? id)
        {
            var output = await _outputService.GetById(id);

            if (output == null) return StatusCode(StatusCodes.Status404NotFound, "Saída não encontrada. Verifique o Id informado");

            return StatusCode(StatusCodes.Status200OK, output);
        }

        [HttpPost]
        [Route("/saidas")]
        public IActionResult Post([Bind("Nome, Valor, Descricao, Data")] FinancialOutputViewModel output)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _outputService.Add(output);
                    return StatusCode(StatusCodes.Status201Created, "Saída inserida com sucesso");
                }
                catch (Exception e)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar inserir a saída. {e.Message}");
                }
            }
            return StatusCode(StatusCodes.Status400BadRequest, output);
        }

        [HttpPut]
        [Route("/saidas/{id}")]
        public async Task<IActionResult> PutAsync([Bind("Nome, Valor, Descricao, Data")] FinancialOutputViewModel output, int? id)
        {
            if (output.Id != id) return StatusCode(StatusCodes.Status400BadRequest, "Informe um id Válido");

            if (ModelState.IsValid)
            {
                try
                {
                    var model = await _outputService.GetById(id);
                    if (model == null) return StatusCode(StatusCodes.Status404NotFound, "Saída informada não existe");

                    _outputService.Update(output);
                    return StatusCode(StatusCodes.Status200OK, "Saída atualizada com sucesso!");
                }
                catch (Exception e)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar atualizar a saída. {e.Message}");
                }
            }
            return StatusCode(StatusCodes.Status400BadRequest, output);
        }

        [HttpDelete]
        [Route("/saidas/{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            try
            {
                var model = await _outputService.GetById(id);
                if (model == null) return StatusCode(StatusCodes.Status404NotFound, "Saída informada não existe");

                _outputService.Remove(id);
                return StatusCode(StatusCodes.Status200OK, "Saída deletada com sucesso");
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar deletar a saída. {e.Message}");
            }
        }
    }
}
