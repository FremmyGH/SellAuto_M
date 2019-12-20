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
    public class TypeCarBodiesController : ControllerBase
    {
        private readonly SellAutoContext _context;

        public TypeCarBodiesController(SellAutoContext context)
        {
            _context = context;
        }

        // GET: api/TypeCarBodies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TypeCarBody>>> GetTypeCarBody()
        {
            return await _context.TypeCarBody.ToListAsync();
        }

        // GET: api/TypeCarBodies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TypeCarBody>> GetTypeCarBody(Guid id)
        {
            var typeCarBody = await _context.TypeCarBody.FindAsync(id);

            if (typeCarBody == null)
            {
                return NotFound();
            }

            return typeCarBody;
        }

        // PUT: api/TypeCarBodies/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTypeCarBody(Guid id, TypeCarBody typeCarBody)
        {
            if (id != typeCarBody.IdTypeCarBody)
            {
                return BadRequest();
            }

            _context.Entry(typeCarBody).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TypeCarBodyExists(id))
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

        // POST: api/TypeCarBodies
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<TypeCarBody>> PostTypeCarBody(TypeCarBody typeCarBody)
        {
            _context.TypeCarBody.Add(typeCarBody);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTypeCarBody", new { id = typeCarBody.IdTypeCarBody }, typeCarBody);
        }

        // DELETE: api/TypeCarBodies/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TypeCarBody>> DeleteTypeCarBody(Guid id)
        {
            var typeCarBody = await _context.TypeCarBody.FindAsync(id);
            if (typeCarBody == null)
            {
                return NotFound();
            }

            _context.TypeCarBody.Remove(typeCarBody);
            await _context.SaveChangesAsync();

            return typeCarBody;
        }

        private bool TypeCarBodyExists(Guid id)
        {
            return _context.TypeCarBody.Any(e => e.IdTypeCarBody == id);
        }
    }
}
