﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VacationOwnershipApi.Models;

namespace VacationOwnershipApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResortController : ControllerBase
    {

        private VacationOwnershipContext _context = new VacationOwnershipContext();

        [HttpGet]
        public IEnumerable<Resort> Get()
        {
            return _context.Resort.ToList();

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var resort = await _context.Resort.FindAsync(id);

            if (resort == null)
            {
                return NotFound();
            }

            _context.Resort.Remove(resort);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
