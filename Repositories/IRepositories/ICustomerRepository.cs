using Labb1_ASP.NET_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Labb1_ASP.NET_API.Repositories.IRepositories
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> GetAllCustomersAsync();
        Task<Customer> GetCustomerByIdAsync(int id);
        Task <Customer> GetCustomerByPhoneNumberAsync(string number);
        Task AddCustomerAsync(Customer customer);
        Task EditCustomerAsync(Customer customer);
        Task DeleteCustomerAsync(int id);
    }
}
