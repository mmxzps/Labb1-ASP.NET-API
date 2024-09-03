using Labb1_ASP.NET_API.Data;
using Labb1_ASP.NET_API.Models;
using Labb1_ASP.NET_API.Models.DTOs;
using Labb1_ASP.NET_API.Repositories.IRepositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.Xml;

namespace Labb1_ASP.NET_API.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly RestaurantDbContext _context;
        public CustomerRepository(RestaurantDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
        {
            var fetchedCustomers = await _context.Customers.ToListAsync();
            return fetchedCustomers;
        }

        public async Task<Customer> GetCustomerByIdAsync(int id)
        {
            var theCustomer = await _context.Customers.FindAsync(id);
            return theCustomer;
        }

        public async Task<Customer> GetCustomerByPhoneNumberAsync(string number)
        {
            var customerPhone = await _context.Customers.SingleOrDefaultAsync(c=>c.PhoneNumber == number);
            return customerPhone;
        }

        public async Task AddCustomerAsync(Customer customer)
        {
            bool customerCheck = await _context.Customers.AnyAsync(x=> x.PhoneNumber == customer.PhoneNumber);
            if (customerCheck) 
            {
                throw new InvalidOperationException($"Customr with phone number: {customer.PhoneNumber} already exist!");
            }
            await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();
        }

        public async Task EditCustomerAsync(Customer customer)
        {
            bool customerCheck = await _context.Customers.AnyAsync(x => x.PhoneNumber == customer.PhoneNumber);
            if (customerCheck && customer.Id != customer.Id)
            {
                throw new InvalidOperationException($"This number is already connected to a customer");
            }
            _context.Customers.Update(customer);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCustomerAsync(int id)
        {
            var deletecustomer = await _context.Customers.FindAsync(id);
            _context.Customers.Remove(deletecustomer);
            await _context.SaveChangesAsync();
        }

    }
}
