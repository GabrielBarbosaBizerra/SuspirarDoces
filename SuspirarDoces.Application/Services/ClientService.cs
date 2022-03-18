using AutoMapper;
using SuspirarDoces.Application.Interfaces;
using SuspirarDoces.Application.ViewsModel;
using SuspirarDoces.Domain.Entities;
using SuspirarDoces.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuspirarDoces.Application.Services
{
    public class ClientService : IService<ClientViewModel>
    {
        public IRepository<Cliente> _clientRepository;
        private readonly IMapper _mapper;
        public ClientService(IMapper mapper, IRepository<Cliente> clientRepository)
        {
            _clientRepository = clientRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ClientViewModel>> GetAll()
        {
            var result = await _clientRepository.GetAll();
            return _mapper.Map<IEnumerable<ClientViewModel>>(result);
        }

        public async Task<ClientViewModel> GetById(int? id)
        {
            var result = await _clientRepository.GetById(id);
            return _mapper.Map<ClientViewModel>(result);
        }

        public void Add(ClientViewModel entity)
        {
            var client = _mapper.Map<Cliente>(entity);
            _clientRepository.Add(client);
        }


        public void Remove(int? id)
        {
            if (Exist(id))
            {
                var client = _clientRepository.GetById(id).Result;
                _clientRepository.Remove(client);
            }
            else
            {
                throw new Exception("Cliente informado não existe");
            }
        }

        public void Update(ClientViewModel entity)
        {
            var exist = Exist(entity.Id);
            if(exist == false)
            {
                throw new Exception("Cliente informado não existe");
            }
            else
            {
                var client = _mapper.Map<Cliente>(entity);
                _clientRepository.Update(client);
            }
        }

        public bool Exist(int? id)
        {
            var client = _clientRepository.GetById(id).Result;
            if (client == null) return false;
            return true;
        }
    }
}
