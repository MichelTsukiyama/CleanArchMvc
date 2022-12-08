using AutoMapper;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Application.Products.Commands;
using CleanArchMvc.Application.Products.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchMvc.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ProductService(IMapper mapper, IMediator mediator)
        {

            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task AddAsync(ProductDTO productDTO)
        {
            var productCreateCommand = _mapper.Map<ProductCreateCommand>(productDTO);
            await _mediator.Send(productCreateCommand);

            //var productEntity = _mapper.Map<Product>(productDTO);
            //await _productRepository.CreateAsync(productEntity);
        }

        public async Task<ProductDTO> GetByIdAsync(int? id)
        {
            var productByIdQuery = new GetProductByIdQuery(id.Value);

            if (productByIdQuery is null) throw new Exception("Entity could not be found");

            var result = await _mediator.Send(productByIdQuery);

            return _mapper.Map<ProductDTO>(result);

            //var productEntity = await _productRepository.GetProductByIdAsync(id);
            //return _mapper.Map<ProductDTO>(productEntity);
        }

        //public async Task<ProductDTO> GetProductCategoryAsync(int? id)
        //{
        //    var productByIdQuery = new GetProductByIdQuery(id.Value);

        //    if (productByIdQuery is null) throw new Exception("Entity could not be found");

        //    var result = await _mediator.Send(productByIdQuery);

        //    return _mapper.Map<ProductDTO>(result);

        //    //var productEntity = await _productRepository.GetProductCategoryAsync(id);
        //    //return _mapper.Map<ProductDTO>(productEntity);

        //}

        public async Task<IEnumerable<ProductDTO>> GetProductsAsync()
        {
            var productsQuery = new GetProductsQuery();

            if (productsQuery == null) throw new Exception($"Entity could not be loaded.");

            var result = await _mediator.Send(productsQuery);
            return _mapper.Map<IEnumerable<ProductDTO>>(result);

            //var productsEntity = await _productRepository.GetProductsAsync();
            //return _mapper.Map<IEnumerable<ProductDTO>>(productsEntity);
        }

        public async Task RemoveAsync(ProductDTO productDTO)
        {
            var productRemoveCommand = new ProductRemoveCommand(productDTO.Id);

            if (productRemoveCommand is null) throw new Exception($"Entity could not be found.");

            await _mediator.Send(productRemoveCommand);

            //var productEntity = _mapper.Map<Product>(productDTO);
            //await _productRepository.RemoveAsync(productEntity);
        }

        public async Task UpdateAsync(ProductDTO productDTO)
        {
            var productUpdateCommand = _mapper.Map<ProductUpdateCommand>(productDTO);
            await _mediator.Send(productUpdateCommand);

            //var productEntity = _mapper.Map<Product>(productDTO);
            //await _productRepository.UpdateAsync(productEntity);
        }
    }
}
