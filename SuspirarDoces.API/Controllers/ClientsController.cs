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
    public class ClientsController: ControllerBase
    {
        private readonly IService<ClientViewModel> _clientService;
        public ClientsController(IService<ClientViewModel> clientService)
        {
            _clientService = clientService;
        }

        [HttpGet]
        [Route("/clients")]
        public async Task<ActionResult<IEnumerable<ClientViewModel>>> GetClients()
        {
            var result = await _clientService.GetAll();
            return StatusCode(200, result);
        }
        [HttpGet]
        [Route("/clients/{id}")]
        public async Task<ActionResult<ClientViewModel>> GetById(int? id)
        {
            var client = await _clientService.GetById(id);

            if (client == null) return NotFound("Cliente não encontrado. Verifique o Id informado");

            return client;
        }
        [HttpPost]
        [Route("/clients")]
        public IActionResult Post([Bind("Id, CPF, Nome, Telefone, Cidade")] ClientViewModel client)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _clientService.Add(client);
                    return StatusCode(201);
                }
                catch (Exception e)
                {
                    return StatusCode(500, $"Erro. {e.Message}");
                }
            }
            return StatusCode(400, client);
        }

        [HttpPut]
        [Route("/clients/{id}")]
        public IActionResult Put([Bind("Id, CPF, Nome, Telefone, Cidade")] ClientViewModel client, int? id)
        {
            if (client.Id != id) return BadRequest("Informe um id Válido");

            if (ModelState.IsValid)
            {
                try
                {
                    _clientService.Update(client);
                    return StatusCode(200, $"Cliente {client.Nome} atualizado com sucesso!");
                }
                catch (Exception e)
                {
                    return StatusCode(400, $"Erro. {e.Message}");
                }
            }
            return StatusCode(400, client);
        }

        [HttpDelete]
        [Route("/clients/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _clientService.Remove(id);
                return StatusCode(200,"Cliente deletado com sucesso");
            }
            catch (Exception e)
            {
                return StatusCode(400, $"Erro. {e.Message}");
            }
        }
    }
}
