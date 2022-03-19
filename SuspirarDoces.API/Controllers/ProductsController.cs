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
    public class ProductsController: ControllerBase
    {
        private readonly IService<ProductViewModel> _productService;
        public ProductsController(IService<ProductViewModel> productService)
        {
            _productService = productService;
        }

        [HttpGet]
        [Route("/produtos")]
        public async Task<ActionResult<IEnumerable<ProductViewModel>>> GetAll()
        {
            var products = await _productService.GetAll();
            return StatusCode(StatusCodes.Status200OK, products);
        }

        [HttpGet]
        [Route("/produtos/{id}")]
        public async Task<ActionResult<ProductViewModel>> GetById(int? id)
        {
            var product = await _productService.GetById(id);

            if (product == null) return StatusCode(StatusCodes.Status404NotFound, "Produto não encontrado. Verifique o Id informado");

            return StatusCode(StatusCodes.Status200OK, product);
        }

        [HttpPost]
        [Route("/produtos")]
        public IActionResult Post([Bind("Nome, Preco, Descricao, IdIngrediente")] ProductViewModel product)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _productService.Add(product);
                    return StatusCode(StatusCodes.Status201Created, "Produto inserido com sucesso");
                }
                catch (Exception e)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar inserir o produto. {e.Message}");
                }
            }
            return StatusCode(StatusCodes.Status400BadRequest, product);
        }

        [HttpPut]
        [Route("/produtos/{id}")]
        public async Task<IActionResult> PutAsync([Bind("Nome, Preco, Descricao, IdIngrediente")] ProductViewModel product, int? id)
        {
            if (product.Id != id) return StatusCode(StatusCodes.Status400BadRequest, "Informe um id Válido");

            if (ModelState.IsValid)
            {
                try
                {
                    var model = await _productService.GetById(id);
                    if (model == null) return StatusCode(StatusCodes.Status404NotFound, "Produto informado não existe");

                    _productService.Update(product);
                    return StatusCode(StatusCodes.Status200OK, $"Produto - {product.Nome} - atualizado com sucesso!");
                }
                catch (Exception e)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar atualizar o produto. {e.Message}");
                }
            }
            return StatusCode(StatusCodes.Status400BadRequest, product);
        }

        [HttpDelete]
        [Route("/produtos/{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            try
            {
                var model = await _productService.GetById(id);
                if (model == null) return StatusCode(StatusCodes.Status404NotFound, "Produto informado não existe");

                _productService.Remove(id);
                return StatusCode(StatusCodes.Status200OK, "Produto deletado com sucesso");
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar deletar o produto. {e.Message}");
            }
        }
    }
}
