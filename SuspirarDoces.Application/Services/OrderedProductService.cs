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
    public class OrderedProductService : IService<OrderedProductViewModel>
    {
        public IRepository<ProdutoPedido> _orderedProductRepository;
        private readonly IMapper _mapper;
        public OrderedProductService(IRepository<ProdutoPedido> orderedProductRepository, IMapper mapper)
        {
            _orderedProductRepository = orderedProductRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<OrderedProductViewModel>> GetAll()
        {
            var result = await _orderedProductRepository.GetAll();
            return _mapper.Map<IEnumerable<OrderedProductViewModel>>(result);
        }

        public async Task<OrderedProductViewModel> GetById(int? id)
        {
            var result = await _orderedProductRepository.GetById(id);
            return _mapper.Map<OrderedProductViewModel>(result);
        }

        public void Add(OrderedProductViewModel entity)
        {
            var orderedProduct = _mapper.Map<ProdutoPedido>(entity);
            _orderedProductRepository.Add(orderedProduct);
        }


        public void Remove(int? id)
        {
            var orderedProduct = _orderedProductRepository.GetById(id).Result;
            _orderedProductRepository.Remove(orderedProduct);
        }

        public void Update(OrderedProductViewModel entity)
        {
            var orderedProduct = _mapper.Map<ProdutoPedido>(entity);
            _orderedProductRepository.Update(orderedProduct);
        }
    }
}
