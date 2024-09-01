using Labb1_ASP.NET_API.Models.DTOs;
using Labb1_ASP.NET_API.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Labb1_ASP.NET_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private readonly IBookingService _bookingsService;
        public BookingsController(IBookingService bookingsService)
        {
            _bookingsService = bookingsService;
        }

        [HttpGet("ShowAllBookings")]
        public async Task<ActionResult<IEnumerable<ShowBookingDTO>>> ShowAllBookings()
        {
            var allBookings = await _bookingsService.GetAllBookingsAsync();
            if (allBookings == null || !allBookings.Any())
            {
                return NotFound(new { Error = "No bookings found!" });
            }
            return Ok(allBookings);
        }

        [HttpGet("GetBookingById/{bookingId}")]
        public async Task<ActionResult<ShowBookingDTO>> GetBookingById(int bookingId)
        {
            var theBooking = await _bookingsService.GetBookingByIdAsync(bookingId);
            if ((theBooking == null))
            {
                return NotFound(new { Error = $"No bookings with id.{bookingId} found!" });
            }
            return Ok(theBooking);
        }

        [HttpPost("AddBooking")]
        public async Task<IActionResult> AddBooking(CreateBookingDTO bookingDTO)
        {
            try
            {
                await _bookingsService.AddBookingAsync(bookingDTO);
                return Created();
            }
            catch (InvalidOperationException ex) 
            {
                return Conflict(new { Error = ex.Message });
            }
        }

        [HttpPut("EditBooking/{bookingId}")]
        public async Task<IActionResult> EditBooking(EditBookingDTO bookingDTO, int bookingId)
        {
            await _bookingsService.EditBookingAsync(bookingDTO, bookingId);
            return Ok();
        }

        [HttpDelete("DeleteBooking/{bookingId}")]
        public async Task<IActionResult> DeleteBooking(int bookingId)
        {
            await _bookingsService.DeleteBookingAsync(bookingId);
            return Ok();
        }
    }
}
