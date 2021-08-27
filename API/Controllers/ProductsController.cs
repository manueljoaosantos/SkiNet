using Core.Entities;
using Core.Interfaces;
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
        private readonly IProductRepository _repo;
        public ProductsController(IProductRepository repo)
        {
            _repo = repo;
        }

        [HttpGet("get-all-products")]
        public async Task<ActionResult<IReadOnlyList<Product>>> GetAllProducts()
        {
            var products = await _repo.GetAllProducsAysnc();
            return Ok(products);
        }

        [HttpGet("get-product-by-id/{id}")]
        //[HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var product = await _repo.GetProductByIdAysnc(id);
            return Ok(product);
        }

        [HttpGet("get-all-productTypes")]
        public async Task<ActionResult<IReadOnlyList<Product>>> GetAllProducTypesAysnc()
        {
            var productTypes = await _repo.GetAllProducTypesAysnc();
            return Ok(productTypes);
        }

        [HttpGet("get-all-productBrands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetAllProducBrandsAysnc()
        {
            var productBrands = await _repo.GetAllProducBrandsAysnc();
            return Ok(productBrands);
        }
    }
}
