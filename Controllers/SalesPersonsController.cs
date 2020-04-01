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
    public class SalesPersonsController : ControllerBase
    {
        private ISalesPersonRepository _salesPersonRepository;

        public SalesPersonsController(ISalesPersonRepository salesPersonRepository)
        {
            _salesPersonRepository = salesPersonRepository;
        }

        // GET: api/SalesPersons
        [HttpGet]
        public IEnumerable<SalesPersons> GetSalesPersons()
        {
            return _salesPersonRepository.GetAll();
        }

        // GET: api/SalesPersons/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SalesPersons>> GetSalesPersons(int id)
        {
            var salesPersons = await _salesPersonRepository.Find(id);

            if (salesPersons == null)
            {
                return NotFound();
            }

            return salesPersons;
        }

        // PUT: api/SalesPersons/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSalesPersons(int id, SalesPersons salesPersons)
        {
            if (id != salesPersons.SalesPersonsId)
            {
                return BadRequest();
            }

            await _salesPersonRepository.Update(salesPersons);

            return NoContent();
        }

        // POST: api/SalesPersons
        [HttpPost]
        public async Task<ActionResult<SalesPersons>> PostSalesPersons(SalesPersons salesPersons)
        {
            await _salesPersonRepository.Add(salesPersons);

            return CreatedAtAction("GetSalesPersons", new { id = salesPersons.SalesPersonsId }, salesPersons);
        }

        // DELETE: api/SalesPersons/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SalesPersons>> DeleteSalesPersons(int id)
        {
            var salesPersons = await _salesPersonRepository.Find(id);
            if (salesPersons == null)
            {
                return NotFound();
            }

            await _salesPersonRepository.Remove(id);

            return salesPersons;
        }

        private async Task<bool> SalesPersonsExists(int id)
        {
            return await _salesPersonRepository.IsExist(id);
        }
    }
}
