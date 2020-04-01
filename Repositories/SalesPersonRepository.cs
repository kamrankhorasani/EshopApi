using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EshopApi.Contracts;
using EshopApi.Models;
using Microsoft.EntityFrameworkCore;

namespace EshopApi.Repositories
{
    public class SalesPersonRepository : ISalesPersonRepository
    {
        private EshopApi_DBContext _context;

        public SalesPersonRepository(EshopApi_DBContext context)
        {
            _context = context;
        }
        public IEnumerable<SalesPersons> GetAll()
        {
            return _context.SalesPersons;
        }

        public async Task<SalesPersons> Add(SalesPersons salesPersons)
        {
            await _context.SalesPersons.AddAsync(salesPersons);
            await _context.SaveChangesAsync();
            return salesPersons;
        }

        public async Task<SalesPersons> Update(SalesPersons salesPersons)
        {
            _context.SalesPersons.Update(salesPersons);
            await _context.SaveChangesAsync();
            return salesPersons;
        }

        public async Task<SalesPersons> Find(int id)
        {
            return await _context.SalesPersons.SingleOrDefaultAsync(s => s.SalesPersonsId == id);
        }

        public async Task<SalesPersons> Remove(int id)
        {
            var salesPerson = await _context.SalesPersons.SingleAsync(s => s.SalesPersonsId == id);
            _context.SalesPersons.Remove(salesPerson);
            await _context.SaveChangesAsync();
            return salesPerson;
        }

        public async Task<bool> IsExist(int id)
        {
            return await _context.SalesPersons.AnyAsync(s => s.SalesPersonsId == id);
        }
    }
}
