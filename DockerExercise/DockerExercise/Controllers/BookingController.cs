using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DockerExercise.Modell;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DockerExercise.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {

        private readonly CarDataContext context;

        public BookingController (CarDataContext context)
        {
            this.context = context;
        }

        // GET: api/Booking
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Booking>>> GetBookings()
        {
            return await context.Bookings.ToListAsync();
        }

        // GET: api/Booking/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Booking>> GetBooking(int id)
        {
            var booking = await context.Bookings.FindAsync(id);

            if (booking == null)
            {
                return NotFound();
            }

            return booking;
        }

        // POST: api/Booking
        [HttpPost]
        public async Task<ActionResult<Booking>> PostBooking(Booking booking)
        {
            if (booking.BookedDate != null && booking.BookedDate > DateTime.Now)
            {
                context.Bookings.Add(booking);
                await context.SaveChangesAsync();

                return CreatedAtAction("GetBooking", new { id = booking.BookingId }, booking);
            }
            return BadRequest();
        }

        // PUT: api/Booking/5
        [HttpPut("{id}")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBooking(int id, Booking booking)
        {
            if (id != booking.BookingId)
            {
                return BadRequest();
            }

            context.Entry(booking).State = EntityState.Modified;

            return NoContent();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Booking>> DeleteBooking(int id)
        {
            var booking = await context.Bookings.FindAsync(id);
            if (booking == null)
            {
                return NotFound();
            }

            context.Bookings.Remove(booking);
            await context.SaveChangesAsync();

            return booking;
        }
    }
}
