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

        public UserTokenViewModel Authenticate(UserViewModel user, string secretKey)
        {
            user.Senha = Services.EncriptarSenhas(user.Senha);

            var userDomain = _mapper.Map<Usuario>(user);
            var usuario = _userRepository.FindUser(userDomain).Result;

            if (usuario != null)
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(secretKey);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.Email, user.Email)
                    }),
                    Expires = DateTime.UtcNow.AddMinutes(30),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                return new UserTokenViewModel(user.Email, tokenHandler.WriteToken(token));
            }
            throw new Exception("Credenciais Inválidas");
        }
    }
}
