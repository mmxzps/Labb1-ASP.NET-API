using Labb1_ASP.NET_API.Models.DTOs.Booking;
using Labb1_ASP.NET_API.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

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
            catch (JsonException ex)
            {
                return Conflict(ex.Message);
            }
        }


        [HttpPut("EditBooking/{bookingId}")]
        public async Task<IActionResult> EditBooking(EditBookingDTO bookingDTO, int bookingId)
        {
            var theBooking = await _bookingsService.GetBookingByIdAsync(bookingId);
            if(theBooking == null)
            {
                return NotFound(new { Error = $"No bookings with id.{bookingId} found!" });
            }
            try
            {
                await _bookingsService.EditBookingAsync(bookingDTO, theBooking.Id);
                return Ok();
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(ex.Message);
            }
        }


        [HttpDelete("DeleteBooking/{bookingId}")]
        public async Task<IActionResult> DeleteBooking(int bookingId)
        {
            var bookingToDelete = await _bookingsService.GetBookingByIdAsync(bookingId);
            if (bookingToDelete == null)
            {
                return NotFound(new { Error = $"No bookings with id.{bookingId} found!" });
            }
            try
            {
                await _bookingsService.DeleteBookingAsync(bookingId);
                return Ok();
            }
            catch(InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
