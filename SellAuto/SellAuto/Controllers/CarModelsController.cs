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
    public class CarModelsController : ControllerBase
    {
        private readonly SellAutoContext _context;

        public CarModelsController(SellAutoContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarModel>>> GetCarModel()
        {
            return await _context.CarModel.ToListAsync();
        }

//         GET: api/CarModels/4
//        [HttpGet("{idMark}")]
//        public async Task<ActionResult<IEnumerable<CarModel>>> GetCarModel(Guid idMark)
//        {
//            return await _context.CarModel.Where(id => id.MarkId == idMark).ToListAsync();
//        }

        //// GET: api/CarModels/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<CarModel>> GetCarModel(Guid id)
        //{
        //    var carModel = await _context.CarModel.FindAsync(id);

        //    if (carModel == null)
        //    {
        //        return NotFound();
        //    }

        //    return carModel;
        //}

        // PUT: api/CarModels/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCarModel(Guid id, CarModel carModel)
        {
            if (id != carModel.IdModel)
            {
                return BadRequest();
            }

            _context.Entry(carModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarModelExists(id))
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

        // POST: api/CarModels
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<CarModel>> PostCarModel(CarModel carModel)
        {
            _context.CarModel.Add(carModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCarModel", new { id = carModel.IdModel }, carModel);
        }

        // DELETE: api/CarModels/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CarModel>> DeleteCarModel(Guid id)
        {
            var carModel = await _context.CarModel.FindAsync(id);
            if (carModel == null)
            {
                return NotFound();
            }

            _context.CarModel.Remove(carModel);
            await _context.SaveChangesAsync();

            return carModel;
        }

        private bool CarModelExists(Guid id)
        {
            return _context.CarModel.Any(e => e.IdModel == id);
        }
    }
}
