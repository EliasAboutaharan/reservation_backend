using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Reservation.Database;
using Reservation.DTOs;
using Reservation.Models;

namespace Reservation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisitorsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public VisitorsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Visitors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VisitorDto>>> GetVisitors()
        {
            var visitors = await _context.Visitors.ToListAsync();
            var staffDict = await _context.Staff.ToDictionaryAsync(s => s.Id, s => s.Name);

            var visitorDtos = visitors.Select(v => new VisitorDto
            {
                Id = v.Id,
                FirstName = v.FirstName,
                LastName = v.LastName,
                Phone = v.Phone,
                Email = v.Email,
                Status = v.Status,
                VisitReason = v.VisitReason,
                ContactStaffId = v.ContactStaffId,
                ContactStaffName = v.ContactStaffId.HasValue && staffDict.ContainsKey(v.ContactStaffId.Value)
                    ? staffDict[v.ContactStaffId.Value]
                    : null
            });

            return Ok(visitorDtos);
        }

        // GET: api/Visitors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VisitorDto>> GetVisitor(int id)
        {
            var visitor = await _context.Visitors.FindAsync(id);

            if (visitor == null)
                return NotFound();

            var visitorDto = new VisitorDto
            {
                Id = visitor.Id,
                FirstName = visitor.FirstName,
                LastName = visitor.LastName,
                Phone = visitor.Phone,
                Email = visitor.Email,
                Status = visitor.Status,
                VisitReason = visitor.VisitReason,
                ContactStaffId = visitor.ContactStaffId
            };

            return Ok(visitorDto);
        }

        // POST: api/Visitors
        [HttpPost]
        public async Task<ActionResult<Visitor>> PostVisitor(Visitor visitor)
        {
            _context.Visitors.Add(visitor);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetVisitor), new { id = visitor.Id }, visitor);
        }

        // PUT: api/Visitors/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVisitor(int id, Visitor visitor)
        {
            if (id != visitor.Id)
            {
                return BadRequest();
            }

            _context.Entry(visitor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await VisitorExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(new { message = "Visitor updated successfully", data = visitor });
        }

        // DELETE: api/Visitors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVisitor(int id)
        {
            var visitor = await _context.Visitors.FindAsync(id);
            if (visitor == null)
            {
                return NotFound();
            }

            _context.Visitors.Remove(visitor);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Visitor deleted successfully" });
        }

        // POST: api/Visitors/check-appointment
        [HttpPost("check-appointment")]
        public async Task<IActionResult> CheckAppointment([FromBody] AppointmentCheckRequest request)
        {
            var appointment = await _context.Appointments
                .Include(a => a.Visitor)
                .Include(a => a.Staff)
                .FirstOrDefaultAsync(a =>
                    a.Visitor.Email == request.Email &&
                    a.Date.Date == request.Date.Date &&
                    a.StaffId == request.StaffId);

            if (appointment == null)
            {
                return NotFound(new { status = "not_found", message = "Rendez-vous introuvable." });
            }

            return Ok(new
            {
                status = "confirmed",
                message = "Rendez-vous confirmé.",
                appointmentId = appointment.Id,
                visitor = new
                {
                    appointment.Visitor.Id,
                    appointment.Visitor.FirstName,
                    appointment.Visitor.LastName,
                    appointment.Visitor.Email
                },
                staff = new
                {
                    appointment.Staff.Id,
                    appointment.Staff.Name,
                    appointment.Staff.Email
                },
                date = appointment.Date
            });
        }

        private async Task<bool> VisitorExists(int id)
        {
            return await _context.Visitors.AnyAsync(e => e.Id == id);
        }
    }
}
