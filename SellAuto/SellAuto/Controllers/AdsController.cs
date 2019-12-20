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
    public class AdsController : ControllerBase
    {
        private readonly SellAutoContext _context;

        public AdsController(SellAutoContext context)
        {
            _context = context;
        }

        // GET: api/Ads/GetAd
        [HttpGet]
        public IEnumerable<Ad> GetAd()
        {
            var ads = _context.Ad
               .Include(a => a.CarModel)
               .Include(a => a.City)
               .Include(a => a.Color)
               .Include(a => a.Drive)
               .Include(a => a.Kpp)
               .Include(a => a.Mark)
               .Include(a => a.SteeringWheel)
               .Include(a => a.TypeCarBody)
               .Include(a => a.User)
               .ToList();
            return ads;
        }

        // GET: api/Ads/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAd([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var ad = await _context.Ad
                .Include(a => a.CarModel)
                .Include(a => a.City)
                .Include(a => a.Color)
                .Include(a => a.Drive)
                .Include(a => a.Kpp)
                .Include(a => a.Mark)
                .Include(a => a.SteeringWheel)
                .Include(a => a.TypeCarBody)
                .Include(a => a.User)
                .FirstOrDefaultAsync(i => i.IdAd == id);
            if (ad == null)
            {
                return NotFound();
            }

            return Ok(ad);
        }

        // PUT: api/Ads/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAd(string id, Ad ad)
        {
            if (id != ad.IdAd)
            {
                return BadRequest();
            }

            _context.Entry(ad).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdExists(id))
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

        // POST: api/Ads

        [HttpPost]
        public async Task<ActionResult<Ad>> PostAd(Ad ad)
        {
            _context.Ad.Add(ad);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAd", new { id = ad.IdAd }, ad);
        }

        // DELETE: api/Ads/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Ad>> DeleteAd(string id)
        {
            var ad = await _context.Ad.FindAsync(id);
            if (ad == null)
            {
                return NotFound();
            }

            _context.Ad.Remove(ad);
            await _context.SaveChangesAsync();

            return ad;
        }

        private bool AdExists(string id)
        {
            return _context.Ad.Any(e => e.IdAd == id);
        }
    }
}
