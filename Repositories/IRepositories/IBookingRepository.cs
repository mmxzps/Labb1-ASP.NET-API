using Labb1_ASP.NET_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Labb1_ASP.NET_API.Repositories.IRepositories
{
    public interface IBookingRepository
    {
        Task<IEnumerable<Booking>> GetAllBookingsAsync();
        Task<Booking> GetBookingByIdAsync(int id);
        Task AddBookingAsync(Booking booking);
        Task EditBookingAsync(Booking booking);
        Task DeleteBookingAsync(int id);
        Task<bool> IsTableBusyAsync(int tableId, DateTime bookingTime, DateTime bookingTimeEnd, int? bookingIdToIgnore);
        Task<bool> IsTableBusyAsync(int tableId, DateTime startTime, DateTime endTime);
    }
}
