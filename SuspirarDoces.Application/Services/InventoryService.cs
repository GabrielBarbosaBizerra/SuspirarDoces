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
    public class InventoryService : IService<InventoryViewModel>
    {
        public IRepository<Estoque> _inventoryRepository;
        private readonly IMapper _mapper;
        public InventoryService(IRepository<Estoque> inventoryRepository, IMapper mapper)
        {
            _inventoryRepository = inventoryRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<InventoryViewModel>> GetAll()
        {
            var result = await _inventoryRepository.GetAll();
            return _mapper.Map<IEnumerable<InventoryViewModel>>(result);
        }

        public async Task<InventoryViewModel> GetById(int? id)
        {
            var result = await _inventoryRepository.GetById(id);
            return _mapper.Map<InventoryViewModel>(result);
        }

        public void Add(InventoryViewModel entity)
        {
            var inventory = _mapper.Map<Estoque>(entity);
            _inventoryRepository.Add(inventory);
        }


        public void Remove(int? id)
        {
            var inventory = _inventoryRepository.GetById(id).Result;
            _inventoryRepository.Remove(inventory);
        }

        public void Update(InventoryViewModel entity)
        {
            var inventory = _mapper.Map<Estoque>(entity);
            _inventoryRepository.Update(inventory);
        }
    }
}
