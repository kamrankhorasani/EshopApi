using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EshopApi.Models;

namespace EshopApi.Contracts
{
    public interface IProductRepository
    {
        IEnumerable<Products> GetAll();
        Task<Products> Add(Products products);
        Task<Products> Find(int id);
        Task<Products> Update(Products products);
        Task<Products> Remove(int id);
        Task<bool> IsExist(int id);
    }
}
