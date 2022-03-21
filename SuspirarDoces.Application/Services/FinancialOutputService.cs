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
        public IFinancialResultRepository _resultRepository;
        private readonly IMapper _mapper;
        public FinancialOutputService(IRepository<Saida> outputRepository, IFinancialResultRepository resultRepository, IMapper mapper)
        {
            _outputRepository = outputRepository;
            _resultRepository = resultRepository;
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

            var result = _resultRepository.GetByDate(entity.Data.Day, entity.Data.Month).Result;
            if (result == null)
            {
                var resultadoFinanceiro = new FinancialResultViewModel
                {
                    Data = entity.Data,
                    Entrada = 0,
                    Saida = entity.Valor,
                    ResultadoFinanceiro = 0 - entity.Valor
                };
                var financialResultDomain = _mapper.Map<Resultado>(resultadoFinanceiro);
                _resultRepository.Add(financialResultDomain);
            }
            else
            {
                result.Saida += output.Valor;
                result.ResultadoFinanceiro = result.Entrada - result.Saida;
                _resultRepository.Update(result);
            }

            _outputRepository.Add(output);
        }


        public void Remove(int? id)
        {
            var output = _outputRepository.GetById(id).Result;
            var result = _resultRepository.GetByDate(output.Data.Day, output.Data.Month).Result;

            result.Saida -= output.Valor;
            result.ResultadoFinanceiro += output.Valor;

            _resultRepository.Update(result);
            _outputRepository.Remove(output);
        }

        public void Update(FinancialOutputViewModel entity)
        {
            var output = _mapper.Map<Saida>(entity);

            var result = _resultRepository.GetByDate(entity.Data.Day, entity.Data.Month).Result;
            var oldOutput = _outputRepository.GetById(entity.Id).Result;

            if (output.Valor > oldOutput.Valor)
            {
                result.Saida += (output.Valor - oldOutput.Valor);
                result.ResultadoFinanceiro -= (output.Valor - oldOutput.Valor);
            }
            if (output.Valor < oldOutput.Valor)
            {
                result.Saida -= (oldOutput.Valor - output.Valor);
                result.ResultadoFinanceiro += (oldOutput.Valor - output.Valor);
            }

            _resultRepository.Update(result);
            _outputRepository.Update(output);
        }
    }
}
