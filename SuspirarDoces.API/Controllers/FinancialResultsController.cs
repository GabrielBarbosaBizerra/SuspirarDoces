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
    public class FinancialResultsController : ControllerBase
    {
        private readonly IService<FinancialResultViewModel> _resultsService;
        public FinancialResultsController(IService<FinancialResultViewModel> resultsService)
        {
            _resultsService = resultsService;
        }

        [HttpGet]
        [Route("/resultados")]
        public async Task<ActionResult<IEnumerable<FinancialResultViewModel>>> GetAll()
        {
            var results = await _resultsService.GetAll();
            return StatusCode(StatusCodes.Status200OK, results);
        }

        [HttpGet]
        [Route("/resultados/{id}")]
        public async Task<ActionResult<FinancialResultViewModel>> GetById(int? id)
        {
            var result = await _resultsService.GetById(id);

            if (result == null) return StatusCode(StatusCodes.Status404NotFound, "Resultado não encontrado. Verifique o Id informado");

            return StatusCode(StatusCodes.Status200OK, result);
        }

        [HttpPost]
        [Route("/resultados")]
        public IActionResult Post([Bind("Data, Entrada, Saida, ResultadoFinanceiro")] FinancialResultViewModel result)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _resultsService.Add(result);
                    return StatusCode(StatusCodes.Status201Created, "Resultado inserido com sucesso");
                }
                catch (Exception e)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar inserir o resultado. {e.Message}");
                }
            }
            return StatusCode(StatusCodes.Status400BadRequest, result);
        }

        [HttpPut]
        [Route("/resultados/{id}")]
        public async Task<IActionResult> PutAsync([Bind("Data, Entrada, Saida, ResultadoFinanceiro")] FinancialResultViewModel result, int? id)
        {
            if (result.Id != id) return StatusCode(StatusCodes.Status400BadRequest, "Informe um id Válido");

            if (ModelState.IsValid)
            {
                try
                {
                    var model = await _resultsService.GetById(id);
                    if (model == null) return StatusCode(StatusCodes.Status404NotFound, "Resultado informado não existe");

                    _resultsService.Update(result);
                    return StatusCode(StatusCodes.Status200OK, "Resultado atualizado com sucesso!");
                }
                catch (Exception e)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar atualizar o resultado. {e.Message}");
                }
            }
            return StatusCode(StatusCodes.Status400BadRequest, result);
        }

        [HttpDelete]
        [Route("/resultados/{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            try
            {
                var model = await _resultsService.GetById(id);
                if (model == null) return StatusCode(StatusCodes.Status404NotFound, "Resultado informado não existe");

                _resultsService.Remove(id);
                return StatusCode(StatusCodes.Status200OK, "Resultado deletado com sucesso");
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar deletar o resultado. {e.Message}");
            }
        }
    }
}
