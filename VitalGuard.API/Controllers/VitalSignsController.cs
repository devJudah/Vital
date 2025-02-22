using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VitalGuard.API.Data;
using VitalGuard.API.Models;

namespace VitalGuard.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VitalSignsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public VitalSignsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/vitalsigns
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VitalSign>>> GetVitalSigns()
        {
            return await _context.VitalSigns.ToListAsync();
        }

        // GET: api/vitalsigns/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VitalSign>> GetVitalSign(Guid id)
        {
            var vitalSign = await _context.VitalSigns.FindAsync(id);

            if (vitalSign == null)
            {
                return NotFound();
            }

            return vitalSign;
        }

        // POST: api/vitalsigns
        [HttpPost]
        public async Task<ActionResult<VitalSign>> PostVitalSign(VitalSign vitalSign)
        {
            vitalSign.Id = Guid.NewGuid();
            vitalSign.RecordedAt = DateTime.UtcNow;
            _context.VitalSigns.Add(vitalSign);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetVitalSign), new { id = vitalSign.Id }, vitalSign);
        }
    }
}
