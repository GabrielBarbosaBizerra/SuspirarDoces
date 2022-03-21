using AutoMapper;
using SuspirarDoces.Domain.Entities;
using SuspirarDoces.Domain.Interfaces;
using SuspirarDoces.Application.Interfaces;
using SuspirarDoces.Application.ViewsModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuspirarDoces.Application.Services
{
    public class UserService : IService<UserViewModel>
    {
        public IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IMapper mapper, IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserViewModel>> GetAll()
        {
            var result = await _userRepository.GetAll();
            return _mapper.Map<IEnumerable<UserViewModel>>(result);
        }

        public async Task<UserViewModel> GetById(int? id)
        {
            var result = await _userRepository.GetById(id);
            return _mapper.Map<UserViewModel>(result);
        }

        public void Add(UserViewModel entity)
        {
            entity.Senha = Services.EncriptarSenhas(entity.Senha);
            var user = _mapper.Map<Usuario>(entity);
            _userRepository.Add(user);
        }


        public void Remove(int? id)
        {
            var user = _userRepository.GetById(id).Result;
            _userRepository.Remove(user);
        }

        public void Update(UserViewModel entity)
        {
            var user = _mapper.Map<Usuario>(entity);
            _userRepository.Update(user);
        }
    }
}