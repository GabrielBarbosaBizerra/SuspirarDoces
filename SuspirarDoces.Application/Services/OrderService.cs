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
        public IFinancialEntryRepository _entryRepository;
        public IRepository<Cliente> _clientRepository;
        public IFinancialResultRepository _resultRepository;
        private readonly IMapper _mapper;
        public OrderService(IRepository<Pedido> orderRepository, IFinancialEntryRepository entryRepository, IRepository<Cliente> clientRepository, IFinancialResultRepository resultRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _entryRepository = entryRepository;
            _clientRepository = clientRepository;
            _resultRepository = resultRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<OrderViewModel>> GetAll()
        {
            var result = await _orderRepository.GetAll();
            return _mapper.Map<IEnumerable<OrderViewModel>>(result);
        }

        public async Task<OrderViewModel> GetById(int? id)
        {
            var result = await _orderRepository.GetById(id);
            return _mapper.Map<OrderViewModel>(result);
        }

        public void Add(OrderViewModel entity)
        {
            var order = _mapper.Map<Pedido>(entity);
            _orderRepository.Add(order);

            var cliente =  _clientRepository.GetById(entity.IdCliente).Result;
            var entry = new Entrada
            {
                Pedido = order,
                PedidoId = order.Id,
                Nome = "Cliente " + cliente.Nome,
                Valor = order.ValorTotal,
                Data = order.DataDoPedido
            };

            var result = _resultRepository.GetByDate(entity.DataDoPedido.Day, entity.DataDoPedido.Month).Result;
            if (result == null)
            {
                var resultadoFinanceiro = new Resultado
                {
                    Data = entry.Data,
                    Entrada = entry.Valor,
                    Saida = 0,
                    ResultadoFinanceiro = entry.Valor
                };
                _resultRepository.Add(resultadoFinanceiro);
            }
            else
            {
                result.Entrada += entry.Valor;
                result.ResultadoFinanceiro = result.Entrada - result.Saida;
                _resultRepository.Update(result);
            }

            _entryRepository.Add(entry);

        }


        public void Remove(int? id)
        {
            var order = _orderRepository.GetById(id).Result;
            var entry = _entryRepository.GetByOrderId(order.Id).Result;
            var result = _resultRepository.GetByDate(order.DataDoPedido.Day, order.DataDoPedido.Month).Result;

            result.Entrada -= entry.Valor;
            result.ResultadoFinanceiro -= entry.Valor;

            _entryRepository.Remove(entry);
            _resultRepository.Update(result);
            _orderRepository.Remove(order);
        }

        public void Update(OrderViewModel entity)
        {
            var order = _mapper.Map<Pedido>(entity);
            _orderRepository.Update(order);
        }
    }
}
