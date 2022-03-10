using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
