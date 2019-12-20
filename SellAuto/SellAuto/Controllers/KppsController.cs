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
    public class KppsController : ControllerBase
    {
        private readonly SellAutoContext _context;

        public KppsController(SellAutoContext context)
        {
            _context = context;
        }

        // GET: api/Kpps
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Kpp>>> GetKpp()
        {
            return await _context.Kpp.ToListAsync();
        }

        // GET: api/Kpps/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Kpp>> GetKpp(Guid id)
        {
            var kpp = await _context.Kpp.FindAsync(id);

            if (kpp == null)
            {
                return NotFound();
            }

            return kpp;
        }

        // PUT: api/Kpps/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKpp(Guid id, Kpp kpp)
        {
            if (id != kpp.IdKpp)
            {
                return BadRequest();
            }

            _context.Entry(kpp).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KppExists(id))
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

        // POST: api/Kpps
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Kpp>> PostKpp(Kpp kpp)
        {
            _context.Kpp.Add(kpp);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetKpp", new { id = kpp.IdKpp }, kpp);
        }

        // DELETE: api/Kpps/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Kpp>> DeleteKpp(Guid id)
        {
            var kpp = await _context.Kpp.FindAsync(id);
            if (kpp == null)
            {
                return NotFound();
            }

            _context.Kpp.Remove(kpp);
            await _context.SaveChangesAsync();

            return kpp;
        }

        private bool KppExists(Guid id)
        {
            return _context.Kpp.Any(e => e.IdKpp == id);
        }
    }
}
