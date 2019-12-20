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
    public class SteeringWheelsController : ControllerBase
    {
        private readonly SellAutoContext _context;

        public SteeringWheelsController(SellAutoContext context)
        {
            _context = context;
        }

        // GET: api/SteeringWheels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SteeringWheel>>> GetSteeringWheel()
        {
            return await _context.SteeringWheel.ToListAsync();
        }

        // GET: api/SteeringWheels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SteeringWheel>> GetSteeringWheel(Guid id)
        {
            var steeringWheel = await _context.SteeringWheel.FindAsync(id);

            if (steeringWheel == null)
            {
                return NotFound();
            }

            return steeringWheel;
        }

        // PUT: api/SteeringWheels/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSteeringWheel(Guid id, SteeringWheel steeringWheel)
        {
            if (id != steeringWheel.IdSteeringWheel)
            {
                return BadRequest();
            }

            _context.Entry(steeringWheel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SteeringWheelExists(id))
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

        // POST: api/SteeringWheels
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<SteeringWheel>> PostSteeringWheel(SteeringWheel steeringWheel)
        {
            _context.SteeringWheel.Add(steeringWheel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSteeringWheel", new { id = steeringWheel.IdSteeringWheel }, steeringWheel);
        }

        // DELETE: api/SteeringWheels/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SteeringWheel>> DeleteSteeringWheel(Guid id)
        {
            var steeringWheel = await _context.SteeringWheel.FindAsync(id);
            if (steeringWheel == null)
            {
                return NotFound();
            }

            _context.SteeringWheel.Remove(steeringWheel);
            await _context.SaveChangesAsync();

            return steeringWheel;
        }

        private bool SteeringWheelExists(Guid id)
        {
            return _context.SteeringWheel.Any(e => e.IdSteeringWheel == id);
        }
    }
}
