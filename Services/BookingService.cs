using Labb1_ASP.NET_API.Models;
using Labb1_ASP.NET_API.Models.DTOs;
using Labb1_ASP.NET_API.Repositories;
using Labb1_ASP.NET_API.Repositories.IRepositories;
using Labb1_ASP.NET_API.Services.IServices;

namespace Labb1_ASP.NET_API.Services
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly ITableRepository _tableRepository;
        public BookingService(IBookingRepository bookingRepository, ICustomerRepository customerRepository, ITableRepository tableRepository)
        {
            _bookingRepository = bookingRepository;
            _customerRepository = customerRepository;
            _tableRepository = tableRepository;
        }

        public async Task<IEnumerable<ShowBookingDTO>> GetAllBookingsAsync()
        {
            var allBookings = await _bookingRepository.GetAllBookingsAsync();
            if (allBookings == null) { return null; }

            return allBookings.Select(booking => new ShowBookingDTO
                {
                Id = booking.Id,
                CustomerId = booking.FK_CustomerId,
                CustomerName = $"{booking.Customer.FirstName} {booking.Customer.LastName}",
                CustomerPhoneNumber = booking.Customer.PhoneNumber,
                AmountGuest = booking.AmountGuest,
                BookingDate = booking.BookingTime,
                TableId = booking.Table.Id,
                TableNumber = booking.Table.TableNumber,
            }).ToList();
        }

        public async Task<ShowBookingDTO> GetBookingByIdAsync(int id)
        {
            var theBooking = await _bookingRepository.GetBookingByIdAsync(id);
            if (theBooking == null) { return null; }

            return new ShowBookingDTO
            {
                Id = theBooking.Id,
                CustomerId = theBooking.FK_CustomerId,
                CustomerName = $"{theBooking.Customer.FirstName} {theBooking.Customer.LastName}",
                CustomerPhoneNumber = theBooking.Customer.PhoneNumber,
                AmountGuest = theBooking.AmountGuest,
                BookingDate = theBooking.BookingTime,
                TableId = theBooking.Table.Id,
                TableNumber = theBooking.Table.TableNumber,
            };
        }


        public async Task AddBookingAsync(CreateBookingDTO bookingDto)
        {
            //check availability of the table.
            var table = await _tableRepository.GetTableByIdAsync(bookingDto.TableId);
            if(table == null || table.TableSeats < bookingDto.AmountGuest) 
            {
                throw new InvalidOperationException($"Table {bookingDto.TableId} cant fit {bookingDto.AmountGuest} guests.");
            }

            var bookingEndTime = bookingDto.BookingTime.AddHours(2);
            var isTableAvailable = await _bookingRepository.IsTableAvailableAsync(bookingDto.TableId, bookingDto.BookingTime, bookingEndTime);

            if (!isTableAvailable)
            {
                throw new InvalidOperationException($"Table {bookingDto.TableId} is not available on {bookingDto.BookingTime}.");
            }

            //creates a new customer at the same time as addin booking
            var existingCustomer = await _customerRepository.GetCustomerByPhoneNumberAsync(bookingDto.PhoneNumber);
            Customer customer;

            if (existingCustomer == null) 
            {
                customer = new Customer
                {
                    FirstName = bookingDto.FirstName,
                    LastName = bookingDto.LastName,
                    PhoneNumber = bookingDto.PhoneNumber,
                };
                await _customerRepository.AddCustomerAsync(customer);
            }
            else
            {
                customer = existingCustomer;
            }
            
            var newBooking = new Booking
            {
                FK_CustomerId = customer.Id,
                BookingTime = bookingDto.BookingTime,
                FK_TableId = bookingDto.TableId,
                AmountGuest = bookingDto.AmountGuest,
                BookingTimeEnd = bookingEndTime
            };
            await _bookingRepository.AddBookingAsync(newBooking);
        }

        public async Task EditBookingAsync(EditBookingDTO bookingDto, int id)
        {
           var bookingToEdit = await _bookingRepository.GetBookingByIdAsync(id);

            //Added these if-statements because in my DTO fileds can be null and it collides with my models.
            if (bookingDto.CustomerId.HasValue)
            {
                bookingToEdit.FK_CustomerId = bookingDto.CustomerId.Value;
            }
            if (bookingDto.AmountGuest.HasValue)
            {
                bookingToEdit.AmountGuest = bookingDto.AmountGuest.Value;
            }
            if (bookingDto.BookingDate.HasValue)
            {
                bookingToEdit.BookingTime = bookingDto.BookingDate.Value;
            }
            if(bookingDto.TableId.HasValue)
            {
                bookingToEdit.FK_TableId = bookingDto.TableId.Value;
            }
            
            await _bookingRepository.EditBookingAsync(bookingToEdit);
        }

        public async Task DeleteBookingAsync(int id)
        {
            await _bookingRepository.DeleteBookingAsync(id);
        }
    }
}
