using Application.Data;
using Application.Models;
using Application.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Controllers
{
    public class Appointment2Controller : Controller
    {
        private readonly ApplicationDbContext _context;
        public Appointment2Controller(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Appointment2>>> GetAppointments([FromQuery] DateTime start, [FromQuery] DateTime end)
        {
            return await _context.Appointments2.Where(e => !((e.End <= start) || (e.Start >= end))).ToListAsync();
        }

        [HttpGet("free")]
        public async Task<ActionResult<IEnumerable<Appointment2>>> GetAppointments([FromQuery] DateTime start, [FromQuery] DateTime end, [FromQuery] string patient)
        {
            return await _context.Appointments2.Where(e => (e.Status == "free" || (e.Status != "free" && e.PatientId == patient)) && !((e.End <= start) || (e.Start >= end))).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Appointment2>> GetAppointmentSlot(int id)
        {
            var appointmentSlot = await _context.Appointments2.FindAsync(id);

            if (appointmentSlot == null)
            {
                return NotFound();
            }

            return appointmentSlot;
        }

        // PUT: api/Appointments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAppointmentSlot(int id, AppointmentSlotUpdate update)
        {
            var appointmentSlot = await _context.Appointments2.FindAsync(id);
            if (appointmentSlot == null)
            {
                return NotFound();
            }

            appointmentSlot.Start = update.Start;
            appointmentSlot.End = update.End;

            if (update.Name != null)
            {
                appointmentSlot.PatientName = update.Name;
            }
            if (update.Status != null)
            {
                appointmentSlot.Status = update.Status;
            }

            _context.Appointments2.Update(appointmentSlot);
            await _context.SaveChangesAsync();

            return NoContent();
        }


        public class AppointmentSlotUpdate
        {
            public DateTime Start { get; set; }
            public DateTime End { get; set; }
            public string? Name { get; set; }
            public string? Status { get; set; }

        }

        // PUT: api/Appointments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}/request")]
        public async Task<IActionResult> PutAppointmentSlotRequest(int id, AppointmentSlotRequest slotRequest)
        {
            var appointmentSlot = await _context.Appointments2.FindAsync(id);
            if (appointmentSlot == null)
            {
                return NotFound();
            }

            appointmentSlot.PatientName = slotRequest.Name;
            appointmentSlot.PatientId = slotRequest.Patient;
            appointmentSlot.Status = "waiting";

            _context.Appointments2.Update(appointmentSlot);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        public class AppointmentSlotRequest
        {
            public string Patient { get; set; }
            public string Name { get; set; }

        }
        // POST: api/Appointments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Appointment2>> PostAppointmentSlot(Appointment2 appointmentSlot)
        {
            _context.Appointments2.Add(appointmentSlot);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAppointmentSlot", new { id = appointmentSlot.Id }, appointmentSlot);
        }

        [HttpPost("create")]
        public async Task<ActionResult<Appointment2>> PostAppointmentSlots(AppointmentSlotRange range)
        {
            var existing = await _context.Appointments2.Where(e => !((e.End <= range.Start) || (e.Start >= range.End))).ToListAsync();
            var slots = Timeline.GenerateSlots(range.Start, range.End, range.Weekends);
            slots.ForEach(slot =>
            {
                var overlaps = existing.Any(e => !((e.End <= slot.Start) || (e.Start >= slot.End)));
                if (overlaps)
                {
                    return;
                }
                _context.Appointments2.Add(slot);
            });

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPost("clear")]
        public async Task<ActionResult<Appointment2>> PostAppointmentClear(ClearRange range)
        {
            var start = range.Start;
            var end = range.End;

            _context.Appointments2.RemoveRange(_context.Appointments2.Where(e => e.Status == "free" && !((e.End <= start) || (e.Start >= end))));
            await _context.SaveChangesAsync();

            return NoContent();
        }


        public class ClearRange
        {
            public DateTime Start { get; set; }
            public DateTime End { get; set; }
        }

        public class AppointmentSlotRange
        {
            public DateTime Start { get; set; }
            public DateTime End { get; set; }
            public bool Weekends { get; set; }
        }


        // DELETE: api/Appointments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAppointmentSlot(int id)
        {
            var appointmentSlot = await _context.Appointments2.FindAsync(id);
            if (appointmentSlot == null)
            {
                return NotFound();
            }

            _context.Appointments2.Remove(appointmentSlot);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AppointmentSlotExists(int id)
        {
            return _context.Appointments2.Any(e => e.Id == id);
        }
    
    public IActionResult Index()
        {
            var appointments2 = _context.Appointments2.ToList();
            return View(appointments2);
        }
    }
}
