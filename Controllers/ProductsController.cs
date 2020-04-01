using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EshopApi.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EshopApi.Models;
using EshopApi.Repositories;

namespace EshopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        // GET: api/Products
        [HttpGet]
        public IEnumerable<Products> GetProducts()
        {
            return _productRepository.GetAll();
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Products>> GetProducts(int id)
        {
            var products = await _productRepository.Find(id);

            if (products == null)
            {
                return NotFound();
            }

            return products;
        }

        // PUT: api/Products/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProducts(int id, Products products)
        {
            if (id != products.ProductsId)
            {
                return BadRequest();
            }

            await _productRepository.Update(products);
            return NoContent();
        }

        // POST: api/Products
        [HttpPost]
        public async Task<ActionResult<Products>> PostProducts(Products products)
        {
            await _productRepository.Add(products);

            return CreatedAtAction("GetProducts", new { id = products.ProductsId }, products);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Products>> DeleteProducts(int id)
        {
            var products = await _productRepository.Find(id);
            if (products == null)
            {
                return NotFound();
            }

            await _productRepository.Remove(id);

            return products;
        }

        private async Task<bool> ProductsExists(int id)
        {
            return await _productRepository.IsExist(id);
        }
    }
}
