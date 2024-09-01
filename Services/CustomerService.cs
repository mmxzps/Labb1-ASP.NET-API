using Labb1_ASP.NET_API.Models;
using Labb1_ASP.NET_API.Models.DTOs;
using Labb1_ASP.NET_API.Repositories.IRepositories;
using Labb1_ASP.NET_API.Services.IServices;

namespace Labb1_ASP.NET_API.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public async Task<IEnumerable<CustomerWithIdDTO>> GetAllCustomersAsync()
        {
            var allCustomrs = await _customerRepository.GetAllCustomersAsync();

            return allCustomrs.Select(c=> new CustomerWithIdDTO
            {
                Id = c.Id,
                FirstName = c.FirstName,
                LastName = c.LastName,
                PhoneNumber = c.PhoneNumber,
            }).ToList();
        }

        public async Task<CustomerWithIdDTO> GetCustomerByIdAsync(int id)
        {
            var existingCustomer = await _customerRepository.GetCustomerByIdAsync(id);
            return new CustomerWithIdDTO
            {
                Id = existingCustomer.Id,
                FirstName = existingCustomer.FirstName,
                LastName = existingCustomer.LastName,
                PhoneNumber = existingCustomer.PhoneNumber,
            };
        }

        public async Task<CustomerWithIdDTO> GetCustomerByPhoneNumberAsync(string number)
        {
            var existingCustomer = await _customerRepository.GetCustomerByPhoneNumberAsync(number);
            return new CustomerWithIdDTO
            {
                Id = existingCustomer.Id,
                FirstName = existingCustomer.FirstName,
                LastName = existingCustomer.LastName,
                PhoneNumber = existingCustomer.PhoneNumber,
            };
        }
        public async Task AddCustomerAsync(CustomerDTO customerDto)
        {
            await _customerRepository.AddCustomerAsync(new Customer
            {
                FirstName = customerDto.FirstName,
                LastName = customerDto.LastName,
                PhoneNumber = customerDto.PhoneNumber
            });
        }

        public async Task EditCustomerAsync(CustomerDTO customerDto, int id)
        {
            var existingCustomer = await _customerRepository.GetCustomerByIdAsync(id);

            existingCustomer.FirstName = customerDto.FirstName;
            existingCustomer.LastName = customerDto.LastName;
            existingCustomer.PhoneNumber = customerDto.PhoneNumber;
        }
        public async Task DeleteCustomerAsync(int id)
        {
            await _customerRepository.DeleteCustomerAsync(id);
        }
    }
}
