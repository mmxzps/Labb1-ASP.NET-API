using Labb1_ASP.NET_API.Models;
using Labb1_ASP.NET_API.Models.DTOs.Booking;
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
                BookingTime = booking.BookingTime,
                BookingTimeEnd = booking.BookingTimeEnd,
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
                BookingTime = theBooking.BookingTime,
                BookingTimeEnd = theBooking.BookingTimeEnd,
                TableId = theBooking.Table.Id,
                TableNumber = theBooking.Table.TableNumber,
            };
        }


        public async Task AddBookingAsync(CreateBookingDTO bookingDto)
        {
            //check availability of the table.
            var theTable = await _tableRepository.GetTableByIdAsync(bookingDto.TableId);
            if (theTable == null)
            {
                throw new InvalidOperationException($"Table {bookingDto.TableId} not found!");
            }
            var bookingEndTime = bookingDto.BookingTime.AddHours(2);
            var isTableBusy = await _bookingRepository.IsTableBusyAsync(bookingDto.TableId, bookingDto.BookingTime, bookingEndTime);

            if (isTableBusy)
            {
                throw new InvalidOperationException($"Table {bookingDto.TableId} is not available on {bookingDto.BookingTime}.");
            }

            //error checks
            if (bookingDto.AmountGuest == 0)
            {
                throw new InvalidOperationException($"Number of guests cannot be {bookingDto.AmountGuest}!");
            }
            if (bookingDto.BookingTime == DateTime.MinValue)
            {
                throw new InvalidOperationException($"Wrong date fromat entered! Enter: 'yyyy-MM-dd HH:mm'");
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

            //guest controlls
            if (bookingDto.AmountGuest == 0)
            {
                throw new InvalidOperationException($"Number of guests cannot be {bookingDto.AmountGuest}!");
            }
            bookingToEdit.AmountGuest = bookingDto.AmountGuest;

            //booking controlls
            if(bookingDto.BookingTime == DateTime.MinValue || bookingDto.BookingTimeEnd == DateTime.MinValue)
            {
                throw new InvalidOperationException($"Wrong date fromat entered! Enter: 'yyyy-MM-dd HH:mm'");
            }
           // var bookingEndTime = bookingDto.BookingTime.AddHours(2);

            var IsTableBusy = await _bookingRepository.IsTableBusyAsync(bookingDto.TableId, bookingDto.BookingTime, bookingDto.BookingTimeEnd, id);
            if (IsTableBusy) 
            {
                throw new InvalidOperationException($"Table {bookingDto.TableId} is not available on {bookingDto.BookingTime}.");
            }
            bookingToEdit.BookingTime = bookingDto.BookingTime;
            bookingToEdit.BookingTimeEnd = bookingDto.BookingTimeEnd;

            //table controlls
            var theTable = await _tableRepository.GetTableByIdAsync(bookingDto.TableId);
            if (theTable == null)
            {
                throw new InvalidOperationException($"Table {bookingDto.TableId} not found!");
            }
            bookingToEdit.FK_TableId = bookingDto.TableId;

            //updating booking
            await _bookingRepository.EditBookingAsync(bookingToEdit);
        }

        public async Task DeleteBookingAsync(int id)
        {
            await _bookingRepository.DeleteBookingAsync(id);
        }
    }
}
