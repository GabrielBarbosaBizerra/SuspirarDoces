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
    public class ProductService : IService<ProductViewModel>
    {
        public IRepository<Produto> _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IMapper mapper, IRepository<Produto> productRepository)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductViewModel>> GetAll()
        {
            var result = await _productRepository.GetAll();
            return _mapper.Map<IEnumerable<ProductViewModel>>(result);
        }

        public async Task<ProductViewModel> GetById(int? id)
        {
            var result = await _productRepository.GetById(id);
            return _mapper.Map<ProductViewModel>(result);
        }

        public void Add(ProductViewModel entity)
        {
            var product = _mapper.Map<Produto>(entity);
            _productRepository.Add(product);
        }


        public void Remove(int? id)
        {
            var product = _productRepository.GetById(id).Result;
            _productRepository.Remove(product);
        }

        public void Update(ProductViewModel entity)
        {
            var product = _mapper.Map<Produto>(entity);
            _productRepository.Update(product);
        }
    }
}