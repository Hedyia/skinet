using System.Collections.Generic;
using System.Threading.Tasks;
using API.Dtos;
using API.Errors;
using API.Helpers;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ProductsController : BaseApiController
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public ProductsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<Pagination<ProductDto>>> GetProducts([FromQuery] ProductParamsSpec productParams)
        {
            var spec = new ProductsWithTypeAndBrandSpecification(productParams);
            var countSpec = new ProductsWithFiltersForCountSpec(productParams);

            var products = await _unitOfWork.ProductRepository.GetListAsync(spec);
            var totalItems = await _unitOfWork.ProductRepository.CountAsync(countSpec);

            var data = _mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductDto>>(products);

            return Ok(new Pagination<ProductDto>
            (pageIndex: productParams.PageIndex, pageSize: productParams.PageSize, count: totalItems, data: data));
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductDto>> GetProduct(int id)
        {
            var spec = new ProductsWithTypeAndBrandSpecification(id);
            var product = await _unitOfWork.ProductRepository.GetAsync(spec);
            if (product == null)
                return NotFound(new ApiResponse(404));
            return _mapper.Map<Product, ProductDto>(product);
        }
        [HttpGet("brands")]
        public async Task<ActionResult<IEnumerable<Brand>>> GetProductBrands()
        {
            var brands = await _unitOfWork.BrandRepository.GetListAsync();
            return Ok(brands);
        }
        [HttpGet("types")]
        public async Task<ActionResult<IEnumerable<Type>>> GetProductTypes()
        {
            var types = await _unitOfWork.TypeRepository.GetListAsync();
            return Ok(types);
        }
    }
}