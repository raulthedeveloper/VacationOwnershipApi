using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
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
    }
}
