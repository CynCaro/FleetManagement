using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace FleetManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaxisController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TaxisController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetTaxis([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            var taxis = await _context.Taxis
                .Select(t => new { t.Id, t.Plate })
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return Ok(taxis);
        }
    }
}
