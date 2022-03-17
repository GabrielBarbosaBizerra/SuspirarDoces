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
    public class OrderService : IService<OrderViewModel>
    {
        public IRepository<Pedido> _orderRepository;
        private readonly IMapper _mapper;
        public OrderService(IRepository<Pedido> orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<OrderViewModel>> GetAll()
        {
            var result = await _orderRepository.GetAll();
            return _mapper.Map<IEnumerable<OrderViewModel>>(result);
        }

        public async Task<OrderViewModel> GetById(int? id)
        {
            var result = await _orderRepository.GetAll();
            return _mapper.Map<OrderViewModel>(result);
        }

        public void Add(OrderViewModel entity)
        {
            var order = _mapper.Map<Pedido>(entity);
            _orderRepository.Add(order);
        }


        public void Remove(int? id)
        {
            var order = _orderRepository.GetById(id).Result;
            _orderRepository.Remove(order);
        }

        public void Update(OrderViewModel entity)
        {
            var order = _mapper.Map<Pedido>(entity);
            _orderRepository.Update(order);
        }
    }
}
