using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
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
        public IActionResult Put([FromBody] Employees employee, int id)
        {
            using (var db = _context)
            {
                var selectedEmployee = db.Employees.Where(u => u.Id == id).FirstOrDefault();

                selectedEmployee.FirstName = employee.FirstName;
                selectedEmployee.LastName = employee.LastName;

                _context.SaveChanges();
            }

            return Ok(employee);
        }
    }
}
