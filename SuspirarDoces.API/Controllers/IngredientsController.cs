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
    public class IngredientsController: ControllerBase
    {
        private readonly IService<IngredientViewModel> _ingredienteService;
        public IngredientsController(IService<IngredientViewModel> ingredientetService)
        {
            _ingredienteService = ingredientetService;
        }

        [HttpGet]
        [Route("/ingredientes")]
        public async Task<ActionResult<IEnumerable<IngredientViewModel>>> GetAll()
        {
            var ingredients = await _ingredienteService.GetAll();
            return StatusCode(StatusCodes.Status200OK, ingredients);
        }

        [HttpGet]
        [Route("/ingredientes/{id}")]
        public async Task<ActionResult<IngredientViewModel>> GetById(int? id)
        {
            var ingredient = await _ingredienteService.GetById(id);

            if (ingredient == null) return StatusCode(StatusCodes.Status404NotFound, "Ingrediente não encontrado. Verifique o Id informado");

            return StatusCode(StatusCodes.Status200OK, ingredient);
        }

        [HttpPost]
        [Route("/ingredientes")]
        public IActionResult Post([Bind("QuantidadeOvos, QuantidadeAcucar, QuantidadeGlacucar")] IngredientViewModel ingredient)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _ingredienteService.Add(ingredient);
                    return StatusCode(StatusCodes.Status201Created, "Ingrediente inserido com sucesso");
                }
                catch (Exception e)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar inserir o ingrediente. {e.Message}");
                }
            }
            return StatusCode(StatusCodes.Status400BadRequest, ingredient);
        }

        [HttpPut]
        [Route("/ingredientes/{id}")]
        public async Task<IActionResult> PutAsync([Bind("QuantidadeOvos, QuantidadeAcucar, QuantidadeGlacucar")] IngredientViewModel ingredient, int? id)
        {
            if (ingredient.Id != id) return StatusCode(StatusCodes.Status400BadRequest, "Informe um id Válido");

            if (ModelState.IsValid)
            {
                try
                {
                    var model = await _ingredienteService.GetById(id);
                    if (model == null) return StatusCode(StatusCodes.Status404NotFound, "Ingrediente informado não existe");

                    _ingredienteService.Update(ingredient);
                    return StatusCode(StatusCodes.Status200OK, "Ingrediente atualizado com sucesso!");
                }
                catch (Exception e)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar atualizar o ingrediente. {e.Message}");
                }
            }
            return StatusCode(StatusCodes.Status400BadRequest, ingredient);
        }

        [HttpDelete]
        [Route("/ingredientes/{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            try
            {
                var model = await _ingredienteService.GetById(id);
                if (model == null) return StatusCode(StatusCodes.Status404NotFound, "Ingrediente informado não existe");

                _ingredienteService.Remove(id);
                return StatusCode(StatusCodes.Status200OK, "Ingrediente deletado com sucesso");
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar deletar o ingrediente. {e.Message}");
            }
        }
    }
}
