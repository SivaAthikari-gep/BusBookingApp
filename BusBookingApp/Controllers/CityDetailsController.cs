using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BusBookingApp.Model;

namespace BusBookingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityDetailsController : ControllerBase
    {
        private readonly JourneyContext _context;

        public CityDetailsController(JourneyContext context)
        {
            _context = context;
        }

        // GET: api/CityDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CityDetails>>> GetCityDetails_1()
        {
            return await _context.CityDetails_1.ToListAsync();
        }

        // GET: api/CityDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CityDetails>> GetCityDetails(int id)
        {
            var cityDetails = await _context.CityDetails_1.FindAsync(id);

            if (cityDetails == null)
            {
                return NotFound();
            }

            return cityDetails;
        }

        // PUT: api/CityDetails/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCityDetails(int id, CityDetails cityDetails)
        {
            if (id != cityDetails.CityId)
            {
                return BadRequest();
            }

            _context.Entry(cityDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CityDetailsExists(id))
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

        // POST: api/CityDetails
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<CityDetails>> PostCityDetails(CityDetails cityDetails)
        {
            _context.CityDetails_1.Add(cityDetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCityDetails", new { id = cityDetails.CityId }, cityDetails);
        }

        // DELETE: api/CityDetails/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CityDetails>> DeleteCityDetails(int id)
        {
            var cityDetails = await _context.CityDetails_1.FindAsync(id);
            if (cityDetails == null)
            {
                return NotFound();
            }

            _context.CityDetails_1.Remove(cityDetails);
            await _context.SaveChangesAsync();

            return cityDetails;
        }

        private bool CityDetailsExists(int id)
        {
            return _context.CityDetails_1.Any(e => e.CityId == id);
        }
    }
}
