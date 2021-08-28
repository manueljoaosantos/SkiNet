using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        private readonly IGenericRepository<Product> _productRepo;

        private readonly IGenericRepository<ProductBrand> _productBrandRepo;

        private readonly IGenericRepository<ProductType> _productTypeRepo;

        public ProductsController(IGenericRepository<Product> productRepo,
            IGenericRepository<ProductBrand> productBrandRepo,
            IGenericRepository<ProductType> productTypeRepo)
        {
            _productRepo = productRepo;
            _productBrandRepo = productBrandRepo;
            _productTypeRepo = productTypeRepo;
        }

        [HttpGet("get-all-products")]
        public async Task<ActionResult<IReadOnlyList<Product>>> GetAllProducts()
        {
            var spec = new ProductsWithTypesAndBrandsSpecification();

            var products = await _productRepo.ListAsync(spec);
            return Ok(products);
        }

        [HttpGet("get-product-by-id/{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var spec = new ProductsWithTypesAndBrandsSpecification(id);

            var product = await _productRepo.GetEntityWithSpec(spec);
            return Ok(product);
        }

        [HttpGet("get-all-productTypes")]
        public async Task<ActionResult<IReadOnlyList<Product>>> GetAllProducTypesAysnc()
        {
            var productTypes = await _productTypeRepo.ListAllAsync();
            return Ok(productTypes);
        }

        [HttpGet("get-all-productBrands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetAllProducBrandsAysnc()
        {
            var productBrands = await _productBrandRepo.ListAllAsync();
            return Ok(productBrands);
        }
    }
}
