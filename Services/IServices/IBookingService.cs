using Labb1_ASP.NET_API.Models;
using Labb1_ASP.NET_API.Models.DTOs.Booking;

namespace Labb1_ASP.NET_API.Services.IServices
{
    public interface IBookingService
    {
        Task<IEnumerable<ShowBookingDTO>> GetAllBookingsAsync();
        Task<ShowBookingDTO> GetBookingByIdAsync(int id);
        Task AddBookingAsync(CreateBookingDTO booking);
        Task EditBookingAsync(EditBookingDTO booking, int id);
        Task DeleteBookingAsync(int id);
    }
}
