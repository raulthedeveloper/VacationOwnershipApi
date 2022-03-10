using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VacationOwnershipApi.Models;

namespace VacationOwnershipApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private VacationOwnershipContext _context = new VacationOwnershipContext();

        [HttpGet]
        public IEnumerable<Customers> Get()
        {
            return _context.Customers.ToList();
            
        }

      


        [HttpGet("{id}")]
        public async Task<ActionResult<Customers>> Get(int id)
        {
            var database = await _context.Customers.FindAsync(id);

            if (database == null)
            {
                return NotFound();
            }

            return database;
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await _context.Customers.FindAsync(id);

            if (data == null)
            {
                return NotFound();
            }

            _context.Customers.Remove(data);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    
}

}

