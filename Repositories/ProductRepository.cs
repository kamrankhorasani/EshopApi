using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EshopApi.Contracts;
using EshopApi.Models;
using Microsoft.EntityFrameworkCore;

namespace EshopApi.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private EshopApi_DBContext _context;

        public ProductRepository (EshopApi_DBContext context)
        {
            _context = context;
        }
        public IEnumerable<Products> GetAll()
        {
            return _context.Products.ToList();
        }

        public async Task<Products> Add(Products products)
        {
            await _context.Products.AddAsync(products);
            await _context.SaveChangesAsync();
            return products;
        }

        public async Task<Products> Find(int id)
        {
            return await _context.Products.SingleOrDefaultAsync(p => p.ProductsId == id);
        }

        public async Task<Products> Update(Products products)
        {
            _context.Products.Update(products);
            await _context.SaveChangesAsync();
            return products;
        }

        public async Task<Products> Remove(int id)
        {
            var product = await _context.Products.SingleAsync(p => p.ProductsId == id);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<bool> IsExist(int id)
        {
            return await _context.Products.AnyAsync(p => p.ProductsId == id);
        }
    }
}
