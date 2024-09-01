using Labb1_ASP.NET_API.Data;
using Labb1_ASP.NET_API.Models;
using Labb1_ASP.NET_API.Repositories.IRepositories;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Labb1_ASP.NET_API.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly RestaurantDbContext _context;
        public BookingRepository(RestaurantDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Booking>> GetAllBookingsAsync()
        {
            var bookingList = await _context.Bookings.Include(c=>c.Customer).Include(t=>t.Table).ToListAsync();
            return bookingList;
        }

        public async Task<Booking> GetBookingByIdAsync(int id)
        {
            var theBooking = await _context.Bookings.Include(c => c.Customer).Include(t => t.Table).SingleOrDefaultAsync(b=>b.Id == id);
            return theBooking;
        }
        public async Task AddBookingAsync(Booking booking)
        {
             _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();
        }

        public async Task EditBookingAsync(Booking booking)
        {
            _context.Bookings.Update(booking);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteBookingAsync(int id)
        {
            var deleteBooking = await _context.Bookings.FindAsync(id);
            _context.Bookings.Remove(deleteBooking);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> IsTableAvailableAsync(int tableId, DateTime bookingTime, DateTime bookingTimeEnd)
        {
            return !await _context.Bookings
                .AnyAsync(b => b.FK_TableId == tableId &&
                               b.BookingTime < bookingTimeEnd &&  
                               b.BookingTimeEnd > bookingTime);
        }
    }
}
