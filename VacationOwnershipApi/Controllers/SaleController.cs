using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VacationOwnershipApi.Models;

namespace VacationOwnershipApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleController : ControllerBase
    {
        private VacationOwnershipContext _context = new VacationOwnershipContext();

        [HttpGet]
        public IEnumerable<Sales> Get()
        {
            return _context.Sales.ToList();

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Sales>> Get(int id)
        {
            var database = await _context.Sales.FindAsync(id);

            if (database == null)
            {
                return NotFound();
            }

            return database;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await _context.Sales.FindAsync(id);

            if (data == null)
            {
                return NotFound();
            }

            _context.Sales.Remove(data);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
