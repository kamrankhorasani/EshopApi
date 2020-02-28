using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EshopApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EshopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private EshopApi_DBContext _DBContext;

        public CustomersController(EshopApi_DBContext context)
        {
            _DBContext = context;
        }

        [HttpGet]
        public IActionResult GetCustomer()
        {
            return new ObjectResult(_DBContext.Customer);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomer([FromRoute] int id)
        {
            var customer = await _DBContext.Customer.SingleOrDefaultAsync(c => c.CustomerId == id);
            return Ok(customer);
        }

        [HttpPost]
        public async Task<IActionResult> PostCustomer([FromBody] Customer customer)
        {
            _DBContext.Customer.Add(customer);
            await _DBContext.SaveChangesAsync();
            return CreatedAtAction("GetCustomer", new { id = customer.CustomerId }, customer);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer([FromRoute] int id, [FromBody] Customer customer)
        {
            _DBContext.Entry(customer).State = EntityState.Modified;
            await _DBContext.SaveChangesAsync();
            return Ok(customer);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer([FromRoute] int id)
        {
            var customer = await _DBContext.Customer.FindAsync(id);
            _DBContext.Customer.Remove(customer);
            await _DBContext.SaveChangesAsync();
            return Ok();
        }
    }
}