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
    public class UnitController : ControllerBase
    {

        private VacationOwnershipContext _context = new VacationOwnershipContext();

        [HttpGet("{id}")]
        public IEnumerable<Object> Get(int Id)
        {

            using (var db = _context)
            {



                //int SelectResortId = Int32.Parse(Console.ReadLine());

                Object ResortUnits = db.Unit.Where(n => n.ResortId == Id).Join(
                    db.Resort,
                    unit => unit.ResortId,
                    resort => resort.Id,
                    (unit, resort) => new
                    {
                        UnitId = unit.Id,
                        ResortName = resort.Name,
                        ResortLocation = resort.Location,
                        UnitName = unit.Name,
                        UnitPrice = unit.Price,
                        UnitPurchased = unit.Purchased
                    }
                    ).ToList();


                return (IEnumerable<object>)ResortUnits;

            }
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Unit>> GetUnit(int id)
        {
            var database = await _context.Unit.FindAsync(id);

            if (database == null)
            {
                return NotFound();
            }

            return database;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await _context.Unit.FindAsync(id);

            if (data == null)
            {
                return NotFound();
            }

            _context.Unit.Remove(data);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}

