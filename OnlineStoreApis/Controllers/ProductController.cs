﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.Core.Services.contract;

namespace OnlineStoreApis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        
        {
         var result = await _productService.GetAllProductsAsync();
            return Ok(result);  
        }

        [HttpGet("brands")]
        public async Task<IActionResult> GetAllBrands()

        {
            var result = await _productService.GetAllBrandsAsync();
            return Ok(result);
        }

        [HttpGet("types")]
        public async Task<IActionResult> GetAllTypesAsync()

        {
            var result = await _productService.GetAllTypesAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int? id)

        {

            if (id is null) return BadRequest("Invalid Id !!");

            var result = await _productService.GetProductById(id.Value);

            if(result is null) return NotFound($"The Product With Id :{id} Not Found ");
            return Ok(result);
        }



    }
}
