using Labb1_ASP.NET_API.Models;
using Labb1_ASP.NET_API.Models.DTOs.Customer;

namespace Labb1_ASP.NET_API.Services.IServices
{
    public interface ICustomerService
    {
        Task<IEnumerable<CustomerWithIdDTO>> GetAllCustomersAsync();
        Task<CustomerWithIdDTO> GetCustomerByIdAsync(int id);
        Task<CustomerWithIdDTO> GetCustomerByPhoneNumberAsync(string number);
        Task AddCustomerAsync(CustomerDTO customer);
        Task EditCustomerAsync(CustomerDTO customer, int id);
        Task DeleteCustomerAsync(int id);
    }
}
