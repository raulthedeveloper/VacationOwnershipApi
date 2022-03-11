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



        [HttpPost]
        public IActionResult Post([FromBody] Sales data)
        {
            _context.Sales.Add(data);
            _context.SaveChanges();
            return Ok(data);
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

        //     from post in database.Posts
        //join meta in database.Post_Metas on post.ID equals meta.Post_ID
        //where post.ID == id
        //select new { Post = post, Meta = meta
        // };

        [HttpGet("sales-report")]
        public ActionResult GetSalesReport()
        {

            object SalesReport = from sales in _context.Sales
                                 join employee in _context.Employees on sales.EmployeeId equals employee.Id
                                 join customer in _context.Customers on sales.CustomerId equals customer.Id
                                 join unit in _context.Unit on sales.UnitId equals unit.Id
                                 join resort in _context.Resort on unit.ResortId equals resort.Id
                                 orderby resort.Name descending
                                 select new
                                 {
                                     EmployeeName = employee.FirstName + " " + employee.LastName,
                                     ResortName = resort.Name,
                                     ResortLocation = resort.Location,
                                     UnitName = unit.Name,
                                     CustomerName = customer.FirstName + " " + 
                                     customer.LastName,
                                     UnitPrice = unit.Price
                                 };

            

            return Ok(SalesReport);
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
