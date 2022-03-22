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
    public class ClientsController: ControllerBase
    {
        private readonly IService<ClientViewModel> _clientService;
        public ClientsController(IService<ClientViewModel> clientService)
        {
            _clientService = clientService;
        }

        [HttpGet]
        [Route("/clientes")]
        public async Task<ActionResult<IEnumerable<ClientViewModel>>> GetAll()
        {
            var clients = await _clientService.GetAll();
            return StatusCode(StatusCodes.Status200OK, clients);
        }

        [HttpGet]
        [Route("/clientes/{id}")]
        public async Task<ActionResult<ClientViewModel>> GetById(int? id)
        {
            var client = await _clientService.GetById(id);

            if (client == null) return StatusCode(StatusCodes.Status404NotFound, "Cliente não encontrado. Verifique o Id informado");

            return StatusCode(StatusCodes.Status200OK, client);
        }

        [HttpPost]
        [Route("/clientes")]
        public IActionResult Post([Bind("CPF, Nome, Telefone, Cidade")] ClientViewModel client)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _clientService.Add(client);
                    return StatusCode(StatusCodes.Status201Created, "Cliente inserido com sucesso");
                }
                catch (Exception e)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar inserir o cliente. {e.Message}");
                }
            }
            return StatusCode(StatusCodes.Status400BadRequest, client);
        }

        [HttpPut]
        [Route("/clientes/{id}")]
        public async Task<IActionResult> PutAsync([Bind("CPF, Nome, Telefone, Cidade")] ClientViewModel client, int? id)
        {
            if (client.Id != id) return StatusCode(StatusCodes.Status400BadRequest, "Informe um id Válido");

            if (ModelState.IsValid)
            {
                try
                {
                    var model = await _clientService.GetById(id);
                    if (model == null) return StatusCode(StatusCodes.Status404NotFound, "Cliente informado não existe");

                    _clientService.Update(client);
                    return StatusCode(StatusCodes.Status200OK, $"Cliente - {client.Nome} - atualizado com sucesso!");
                }
                catch (Exception e)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar atualizar o cliente. {e.Message}");
                }
            }
            return StatusCode(StatusCodes.Status400BadRequest, client);
        }

        [HttpDelete]
        [Route("/clientes/{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            try
            {
                var model = await _clientService.GetById(id);
                if (model == null) return StatusCode(StatusCodes.Status404NotFound, "Cliente informado não existe");

                _clientService.Remove(id);
                return StatusCode(StatusCodes.Status200OK, "Cliente deletado com sucesso");
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar deletar o cliente. {e.Message}");
            }
        }
    }
}
