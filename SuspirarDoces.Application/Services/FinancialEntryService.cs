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
    public class FinancialEntryService : IService<FinancialEntryViewModel>
    {
        public IRepository<Entrada> _entryRepository;
        private readonly IMapper _mapper;
        public FinancialEntryService(IRepository<Entrada> entryRepository, IMapper mapper)
        {
            _entryRepository = entryRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<FinancialEntryViewModel>> GetAll()
        {
            var result = await _entryRepository.GetAll();
            return _mapper.Map<IEnumerable<FinancialEntryViewModel>>(result);
        }

        public async Task<FinancialEntryViewModel> GetById(int? id)
        {
            var result = await _entryRepository.GetById(id);
            return _mapper.Map<FinancialEntryViewModel>(result);
        }

        public void Add(FinancialEntryViewModel entity)
        {
            var entry = _mapper.Map<Entrada>(entity);
            _entryRepository.Add(entry);
        }


        public void Remove(int? id)
        {
            var entry = _entryRepository.GetById(id).Result;
            _entryRepository.Remove(entry);
        }

        public void Update(FinancialEntryViewModel entity)
        {
            var entry = _mapper.Map<Entrada>(entity);
            _entryRepository.Update(entry);
        }
    }
}
