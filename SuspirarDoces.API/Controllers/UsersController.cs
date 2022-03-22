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
    public class UsersController: ControllerBase
    {
        private readonly IService<UserViewModel> _userService;
        public UsersController(IService<UserViewModel> userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Route("/usuarios")]
        [Authorize()]
        public async Task<ActionResult<IEnumerable<UserViewModel>>> GetAll()
        {
            var users = await _userService.GetAll();
            return StatusCode(StatusCodes.Status200OK, users);
        }

        [HttpGet]
        [Route("/usuarios/{id}")]
        [Authorize()]
        public async Task<ActionResult<UserViewModel>> GetById(int? id)
        {
            var user = await _userService.GetById(id);

            if (user == null) return StatusCode(StatusCodes.Status404NotFound, "Usuário não encontrado. Verifique o Id informado");

            return StatusCode(StatusCodes.Status200OK, user);
        }

        [HttpPost]
        [Route("/usuarios")]
        [AllowAnonymous]
        public IActionResult Post([Bind("Email, Senha")] UserViewModel user)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _userService.Add(user);
                    return StatusCode(StatusCodes.Status201Created, "Usuário inserido com sucesso");
                }
                catch (Exception e)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar inserir o usuário. {e.Message}");
                }
            }
            return StatusCode(StatusCodes.Status400BadRequest, user);
        }

        [HttpPut]
        [Route("/usuarios/{id}")]
        [Authorize()]
        public async Task<IActionResult> PutAsync([Bind("Email, Senha")] UserViewModel user, int? id)
        {
            if (user.Id != id) return StatusCode(StatusCodes.Status400BadRequest, "Informe um id Válido");

            if (ModelState.IsValid)
            {
                try
                {
                    var model = await _userService.GetById(id);
                    if (model == null) return StatusCode(StatusCodes.Status404NotFound, "Usuário informado não existe");

                    _userService.Update(user);
                    return StatusCode(StatusCodes.Status200OK, $"Usuário - {user.Email} - atualizado com sucesso!");
                }
                catch (Exception e)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar atualizar o usuário. {e.Message}");
                }
            }
            return StatusCode(StatusCodes.Status400BadRequest, user);
        }

        [HttpDelete]
        [Route("/usuarios/{id}")]
        [Authorize()]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            try
            {
                var model = await _userService.GetById(id);
                if (model == null) return StatusCode(StatusCodes.Status404NotFound, "Usuário informado não existe");

                _userService.Remove(id);
                return StatusCode(StatusCodes.Status200OK, "Usuário deletado com sucesso");
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar deletar o usuário. {e.Message}");
            }
        }
    }
}
