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
    public class FinancialOutputService : IService<FinancialOutputViewModel>
    {
        public IRepository<Saida> _outputRepository;
        private readonly IMapper _mapper;
        public FinancialOutputService(IRepository<Saida> outputRepository, IMapper mapper)
        {
            _outputRepository = outputRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<FinancialOutputViewModel>> GetAll()
        {
            var result = await _outputRepository.GetAll();
            return _mapper.Map<IEnumerable<FinancialOutputViewModel>>(result);
        }

        public async Task<FinancialOutputViewModel> GetById(int? id)
        {
            var result = await _outputRepository.GetById(id);
            return _mapper.Map<FinancialOutputViewModel>(result);
        }

        public void Add(FinancialOutputViewModel entity)
        {
            var output = _mapper.Map<Saida>(entity);
            _outputRepository.Add(output);
        }


        public void Remove(int? id)
        {
            var output = _outputRepository.GetById(id).Result;
            _outputRepository.Remove(output);
        }

        public void Update(FinancialOutputViewModel entity)
        {
            var output = _mapper.Map<Saida>(entity);
            _outputRepository.Update(output);
        }
    }
}
