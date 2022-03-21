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
        public IFinancialEntryRepository _entryRepository;
        public IFinancialResultRepository _resultRepository;
        private readonly IMapper _mapper;
        public FinancialEntryService(IFinancialEntryRepository entryRepository, IFinancialResultRepository resultRepository, IMapper mapper)
        {
            _entryRepository = entryRepository;
            _resultRepository = resultRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<FinancialEntryViewModel>> GetAll()
        {
            var result = await _entryRepository.GetAll();
            return _mapper.Map<IEnumerable<FinancialEntryViewModel>>(result);
        }

        public async Task<FinancialEntryViewModel> GetByOrderId(int? id)
        {
            var result = await _entryRepository.GetByOrderId(id);
            return _mapper.Map<FinancialEntryViewModel>(result);
        }

        public async Task<FinancialEntryViewModel> GetById(int? id)
        {
            var result = await _entryRepository.GetById(id);
            return _mapper.Map<FinancialEntryViewModel>(result);
        }

        public void Add(FinancialEntryViewModel entity)
        {
            var result = _resultRepository.GetByDate(entity.Data.Day, entity.Data.Month).Result;
            if (result == null)
            {
                var resultadoFinanceiro = new FinancialResultViewModel
                {
                    Data = entity.Data,
                    Entrada = entity.Valor,
                    Saida = 0,
                    ResultadoFinanceiro = entity.Valor
                };
                var financialResultDomain = _mapper.Map<Resultado>(resultadoFinanceiro);
                _resultRepository.Add(financialResultDomain);
            }
            else
            {
                result.Entrada += entity.Valor;
                result.ResultadoFinanceiro = result.Entrada - result.Saida;
                _resultRepository.Update(result);
            }

            var entry = _mapper.Map<Entrada>(entity);
            _entryRepository.Add(entry);
        }


        public void Remove(int? id)
        {
            var entry = _entryRepository.GetById(id).Result;
            var result = _resultRepository.GetByDate(entry.Data.Day, entry.Data.Month).Result;

            result.Entrada -= entry.Valor;
            result.ResultadoFinanceiro -= entry.Valor;
            if (result.Entrada <= 0)
            {
                result.Entrada = 0;
            }
            if (result.ResultadoFinanceiro <= 0 && result.Saida.Equals(0))
            {
                result.ResultadoFinanceiro = 0;
            }

            _resultRepository.Update(result);
            _entryRepository.Remove(entry);
        }

        public void Update(FinancialEntryViewModel entity)
        {
            var entry = _mapper.Map<Entrada>(entity);

            var idEntry = entity.Id;
            var result = _resultRepository.GetByDate(entity.Data.Day, entity.Data.Month).Result;
            var oldEntry = _entryRepository.GetById(idEntry).Result;

            if (entry.Valor > oldEntry.Valor)
            {
                result.Entrada += (entry.Valor - oldEntry.Valor);
                result.ResultadoFinanceiro += (entry.Valor - oldEntry.Valor);
            }
            if (entry.Valor < oldEntry.Valor)
            {
                result.Entrada -= (oldEntry.Valor - entry.Valor);
                if (result.Entrada <= 0)
                {
                    result.Entrada = 0;
                }
                result.ResultadoFinanceiro -= (oldEntry.Valor - entry.Valor);
            }

            _resultRepository.Update(result);
            _entryRepository.Update(entry);
        }
    }
}
