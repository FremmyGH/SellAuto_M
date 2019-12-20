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
    public class CarMarksController : ControllerBase
    {
        private readonly SellAutoContext _context;

        public CarMarksController(SellAutoContext context)
        {
            _context = context;
        }

        // GET: api/CarMarks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarMark>>> GetCarMarks()
        {
            return await _context.CarMark.ToListAsync();
        }

        // GET: api/CarMarks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CarMark>> GetCarMark(Guid id)
        {
            var carMark = await _context.CarMark.FindAsync(id);

            if (carMark == null)
            {
                return NotFound();
            }

            return carMark;
        }

        // PUT: api/CarMarks/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCarMark(Guid id, CarMark carMark)
        {
            if (id != carMark.IdMark)
            {
                return BadRequest();
            }

            _context.Entry(carMark).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarMarkExists(id))
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

        // POST: api/CarMarks
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<CarMark>> PostCarMark(CarMark carMark)
        {
            _context.CarMark.Add(carMark);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCarMark", new { id = carMark.IdMark }, carMark);
        }

        // DELETE: api/CarMarks/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CarMark>> DeleteCarMark(Guid id)
        {
            var carMark = await _context.CarMark.FindAsync(id);
            if (carMark == null)
            {
                return NotFound();
            }

            _context.CarMark.Remove(carMark);
            await _context.SaveChangesAsync();

            return carMark;
        }

        private bool CarMarkExists(Guid id)
        {
            return _context.CarMark.Any(e => e.IdMark == id);
        }
    }
}
