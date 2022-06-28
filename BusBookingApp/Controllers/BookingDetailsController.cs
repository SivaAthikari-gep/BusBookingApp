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
    public class BookingDetailsController : ControllerBase
    {
        private readonly JourneyContext _context;

        public BookingDetailsController(JourneyContext context)
        {
            _context = context;
        }

        // GET: api/BookingDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookingDetails>>> GetBookingDetails_1()
        {
            var bookingdetails = (from a in _context.BookingDetails_1
                              join b in _context.BusDetails
                              on a.BusId equals b.BusId

                              select new BookingDetails
                              {
                                  BookingId = a.BookingId,
                                  BusId = a.BusId,
                                  PassengerName = a.PassengerName,
                                  NoOfTickets = a.NoOfTickets,
                                  TotalPrice = b.SeatPrice,

                              }).ToListAsync();
            return await bookingdetails;
        }

        // GET: api/BookingDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BookingDetails>> GetBookingDetails(int id)
        {
            var bookingDetails = await _context.BookingDetails_1.FindAsync(id);

            if (bookingDetails == null)
            {
                return NotFound();
            }

            return bookingDetails;
        }

        // PUT: api/BookingDetails/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBookingDetails(int id, BookingDetails bookingDetails)
        {
            if (id != bookingDetails.BookingId)
            {
                return BadRequest();
            }

            _context.Entry(bookingDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookingDetailsExists(id))
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

        // POST: api/BookingDetails
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<BookingDetails>> PostBookingDetails(BookingDetails bookingDetails)
        {
            _context.BookingDetails_1.Add(bookingDetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBookingDetails", new { id = bookingDetails.BookingId }, bookingDetails);
        }

        // DELETE: api/BookingDetails/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BookingDetails>> DeleteBookingDetails(int id)
        {
            var bookingDetails = await _context.BookingDetails_1.FindAsync(id);
            if (bookingDetails == null)
            {
                return NotFound();
            }

            _context.BookingDetails_1.Remove(bookingDetails);
            await _context.SaveChangesAsync();

            return bookingDetails;
        }

        private bool BookingDetailsExists(int id)
        {
            return _context.BookingDetails_1.Any(e => e.BookingId == id);
        }
    }
}
