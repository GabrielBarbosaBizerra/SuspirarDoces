using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using SuspirarDoces.Application.Interfaces;
using SuspirarDoces.Application.ViewsModel;
using SuspirarDoces.Domain.Entities;
using SuspirarDoces.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SuspirarDoces.Application.Services
{
    public class AuthenticateService: IAuthenticateService
    {
        public IUserRepository _userRepository;
        private IMapper _mapper;
        public AuthenticateService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public string Authenticate(UserViewModel user, string secretKey)
        {
            user.Senha = Services.EncriptarSenhas(user.Senha);

            var userDomain = _mapper.Map<Usuario>(user);
            var usuario = _userRepository.FindUser(userDomain).Result;

            if (usuario != null)
            {
                var claims = new[]
                {
                    new Claim(ClaimTypes.Email, user.Email)
                };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

                var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.Now.AddHours(8),
                    signingCredentials: cred
                );

                return new JwtSecurityTokenHandler().WriteToken(token);
            }
            return "Credenciais Inválidas";
        }
    }
}
