using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VitalGuard.API.Data;
using VitalGuard.API.Models;
using Microsoft.AspNetCore.SignalR;
using VitalGuard.API.Hubs;

namespace VitalGuard.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IHubContext<PatientHub> _hubContext;

        public PatientsController(AppDbContext context, IHubContext<PatientHub> hubContext)
        {
            _context = context;
            _hubContext = hubContext;
        }

        // GET: api/patients
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Patient>>> GetPatients()
        {
            return await _context.Patients.ToListAsync();
        }

        // GET: api/patients/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Patient>> GetPatient(Guid id)
        {
            var patient = await _context.Patients.FindAsync(id);

            if (patient == null)
            {
                return NotFound();
            }

            return patient;
        }

        // POST: api/patients
        [HttpPost]
        public async Task<ActionResult<Patient>> PostPatient(Patient patient)
        {
            patient.Id = Guid.NewGuid();
            patient.CreatedAt = DateTime.UtcNow;
            _context.Patients.Add(patient);
            await _context.SaveChangesAsync();

            // Send real-time updates after adding a new patient
            await _hubContext.Clients.All.SendAsync("ReceivePatientUpdate", patient.Id, "New patient added");

            return CreatedAtAction(nameof(GetPatient), new { id = patient.Id }, patient);
        }
    }
}
