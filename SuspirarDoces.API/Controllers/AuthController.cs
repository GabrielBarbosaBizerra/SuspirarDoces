using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SuspirarDoces.Application.Interfaces;
using SuspirarDoces.Application.ViewsModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuspirarDoces.API.Controllers
{
    [ApiController]
    [AllowAnonymous]
    public class AuthController : ControllerBase
    {
        private readonly IAuthenticateService _authService;
        private readonly IConfiguration _configuration;
        public AuthController(IAuthenticateService authService, IConfiguration configuration)
        {
            _configuration = configuration;
            _authService = authService;
        }

        [HttpPost]
        [Route("/autenticar")]
        [AllowAnonymous]
        public ActionResult<UserTokenViewModel> Authenticate(UserViewModel user)
        {
            if (string.IsNullOrEmpty(user.Email))
            {
                return BadRequest("Insira um email");
            }
            if (string.IsNullOrEmpty(user.Senha))
            {
                return BadRequest("Insira a senha");
            }

            try
            {
                string secretKey = _configuration["ChaveSecreta"];
                var userToken = _authService.Authenticate(user, secretKey);

                return StatusCode(StatusCodes.Status200OK, userToken);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }

        }
    }
}