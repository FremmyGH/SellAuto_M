using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SellAuto.Models;

namespace SellAuto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrivesController : ControllerBase
    {
        private readonly SellAutoContext _context;

        public DrivesController(SellAutoContext context)
        {
            _context = context;
        }

        // GET: api/Drives
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Drive>>> GetDrive()
        {
            return await _context.Drive.ToListAsync();
        }

        // GET: api/Drives/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Drive>> GetDrive(Guid id)
        {
            var drive = await _context.Drive.FindAsync(id);

            if (drive == null)
            {
                return NotFound();
            }

            return drive;
        }

        // PUT: api/Drives/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDrive(Guid id, Drive drive)
        {
            if (id != drive.IdDrive)
            {
                return BadRequest();
            }

            _context.Entry(drive).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DriveExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Drives
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Drive>> PostDrive(Drive drive)
        {
            _context.Drive.Add(drive);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDrive", new { id = drive.IdDrive }, drive);
        }

        // DELETE: api/Drives/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Drive>> DeleteDrive(Guid id)
        {
            var drive = await _context.Drive.FindAsync(id);
            if (drive == null)
            {
                return NotFound();
            }

            _context.Drive.Remove(drive);
            await _context.SaveChangesAsync();

            return drive;
        }

        private bool DriveExists(Guid id)
        {
            return _context.Drive.Any(e => e.IdDrive == id);
        }
    }
}
