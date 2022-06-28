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
    public class BusDetailsController : ControllerBase
    {
        private readonly JourneyContext _context;

        public BusDetailsController(JourneyContext context)
        {
            _context = context;
        }

        // GET: api/BusDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BusDetails>>> GetCityDetails()
        {
            var busdeatils = (from a in _context.BusDetails
                              join b in _context.CityDetails_1
                              on a.SourceKeyId equals b.CityId
                              join c in _context.CityDetails_1
                              on a.DestinationCityId equals c.CityId

                              select new BusDetails
                              {
                                  BusId = a.BusId,
                                  BusNumber = a.BusNumber,
                                  SourceKeyId = a.SourceKeyId,
                                  Source = b.CityName,
                                  DestinationCityId = a.DestinationCityId,
                                  Destination = c.CityName,
                                  SeatCount = a.SeatCount,
                                  SeatPrice = a.SeatPrice,

                              }).ToListAsync();
            return await busdeatils;
        }

        // GET: api/BusDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BusDetails>> GetBusDetails(int id)
        {
            var busDetails = await _context.CityDetails.FindAsync(id);

            if (busDetails == null)
            {
                return NotFound();
            }

            return busDetails;
        }

        // PUT: api/BusDetails/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBusDetails(int id, BusDetails busDetails)
        {
            if (id != busDetails.BusId)
            {
                return BadRequest();
            }

            _context.Entry(busDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BusDetailsExists(id))
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

        // POST: api/BusDetails
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<BusDetails>> PostBusDetails(BusDetails busDetails)
        {
            _context.CityDetails.Add(busDetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBusDetails", new { id = busDetails.BusId }, busDetails);
        }

        // DELETE: api/BusDetails/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BusDetails>> DeleteBusDetails(int id)
        {
            var busDetails = await _context.CityDetails.FindAsync(id);
            if (busDetails == null)
            {
                return NotFound();
            }

            _context.CityDetails.Remove(busDetails);
            await _context.SaveChangesAsync();

            return busDetails;
        }

        private bool BusDetailsExists(int id)
        {
            return _context.CityDetails.Any(e => e.BusId == id);
        }
    }
}
