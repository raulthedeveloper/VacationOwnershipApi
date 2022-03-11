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
    public class EmployeeController : ControllerBase
    {

        private VacationOwnershipContext _context = new VacationOwnershipContext();

        [HttpGet]
        public IEnumerable<Employees> Get()
        {
            return _context.Employees.ToList();

        }

        [HttpPost]
        public IActionResult Post([FromBody] Employees employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();

            return Ok(employee);
        }

        [HttpPut("id")]
        public IActionResult Put(int id, [FromBody] Employees employee)
        {
            

            using (var db = _context)
            {

                
                var selectedEmployee = db.Employees.Where(u => u.Id == id).FirstOrDefault();

                if (id != employee.Id)
                {
                    return BadRequest();
                }

                selectedEmployee.FirstName = employee.FirstName;
                selectedEmployee.LastName = employee.LastName;

                _context.SaveChanges();
            }

            return Ok(employee);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Employees>> Get(int id)
        {
            var database = await _context.Employees.FindAsync(id);

            if (database == null)
            {
                return NotFound();
            }

            return database;
        }


        [HttpGet("single-employee/{id}")]

        public async Task<ActionResult<Employees>> SingleEmployee(int id)
        {
            var database = await _context.Employees.FindAsync(id);

            if (database == null)
            {
                return NotFound();
            }

            return database;
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var employee = await _context.Employees.FindAsync(id);

            if (employee == null)
            {
                return NotFound();
            }

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
