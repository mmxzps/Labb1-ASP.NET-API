using Labb1_ASP.NET_API.Models;
using Labb1_ASP.NET_API.Models.DTOs.Customer;
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
            if(existingCustomer == null) { return null; }
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
            if (existingCustomer == null) { return null; }
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
            if(existingCustomer == null)
            {
                throw new InvalidOperationException($"Customer with Id.{id} was not found!");
            }
            existingCustomer.FirstName = customerDto.FirstName;
            existingCustomer.LastName = customerDto.LastName;
            existingCustomer.PhoneNumber = customerDto.PhoneNumber;

            await _customerRepository.EditCustomerAsync(existingCustomer);
        }

        public async Task DeleteCustomerAsync(int id)
        {
            var deleteCustomer = await _customerRepository.GetCustomerByIdAsync(id);
            if (deleteCustomer == null)
            {
                throw new InvalidOperationException($"Customer with Id.{id} was not found!");
            }
            await _customerRepository.DeleteCustomerAsync(id);
        }
    }
}
