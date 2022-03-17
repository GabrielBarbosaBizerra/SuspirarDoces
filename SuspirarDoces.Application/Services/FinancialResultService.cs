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
    public class FinancialResultService : IService<FinancialResultViewModel>
    {
        public IRepository<Resultado> _resultRepository;
        private readonly IMapper _mapper;
        public FinancialResultService(IRepository<Resultado> resultRepository, IMapper mapper)
        {
            _resultRepository = resultRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<FinancialResultViewModel>> GetAll()
        {
            var result = await _resultRepository.GetAll();
            return _mapper.Map<IEnumerable<FinancialResultViewModel>>(result);
        }

        public async Task<FinancialResultViewModel> GetById(int? id)
        {
            var result = await _resultRepository.GetById(id);
            return _mapper.Map<FinancialResultViewModel>(result);
        }

        public void Add(FinancialResultViewModel entity)
        {
            var result = _mapper.Map<Resultado>(entity);
            _resultRepository.Add(result);
        }


        public void Remove(int? id)
        {
            var result = _resultRepository.GetById(id).Result;
            _resultRepository.Remove(result);
        }

        public void Update(FinancialResultViewModel entity)
        {
            var result = _mapper.Map<Resultado>(entity);
            _resultRepository.Update(result);
        }
    }
}
