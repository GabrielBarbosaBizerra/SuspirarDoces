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
    public class IngredientService : IService<IngredientViewModel>
    {
        public IRepository<Ingrediente> _ingredientRepository;
        private readonly IMapper _mapper;
        public IngredientService(IRepository<Ingrediente> ingredientRepository, IMapper mapper)
        {
            _ingredientRepository = ingredientRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<IngredientViewModel>> GetAll()
        {
            var result = await _ingredientRepository.GetAll();
            return _mapper.Map<IEnumerable<IngredientViewModel>>(result);
        }

        public async Task<IngredientViewModel> GetById(int? id)
        {
            var result = await _ingredientRepository.GetById(id);
            return _mapper.Map<IngredientViewModel>(result);
        }

        public void Add(IngredientViewModel entity)
        {
            var ingredient = _mapper.Map<Ingrediente>(entity);
            _ingredientRepository.Add(ingredient);
        }


        public void Remove(int? id)
        {
            var ingredient = _ingredientRepository.GetById(id).Result;
            _ingredientRepository.Remove(ingredient);
        }

        public void Update(IngredientViewModel entity)
        {
            var ingredient = _mapper.Map<Ingrediente>(entity);
            _ingredientRepository.Update(ingredient);
        }
    }
}
