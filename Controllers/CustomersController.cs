using Labb1_ASP.NET_API.Models;
using Labb1_ASP.NET_API.Models.DTOs.Customer;
using Labb1_ASP.NET_API.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Labb1_ASP.NET_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet("GetAllCustomers")]
        public async Task<ActionResult<IEnumerable<Customer>>> GetAllCustomers()
        {
            var allCustomers = await _customerService.GetAllCustomersAsync();
            if (allCustomers == null || !allCustomers.Any())
            {
                return NotFound(new {Error = "No customers found!"});
            }
            return Ok(allCustomers);
        }


        [HttpGet("GetCustomerById/{customerId}")]
        public async Task<ActionResult<Customer>> GetCustomerById(int customerId)
        {
            var theCustomer = await _customerService.GetCustomerByIdAsync(customerId);
            if (theCustomer == null)
            {
                return NotFound(new { Error = $"No customer with Id.{customerId} was found!" });
            }
            return Ok(theCustomer);
        }


        [HttpGet("GetCustomerByPhoneNr/{phoneNumber}")]
        public async Task<ActionResult<Customer>> GetCustomerByPhoneNr(string phoneNumber)
        {
            var phoneCustomer = await _customerService.GetCustomerByPhoneNumberAsync(phoneNumber);
            if(phoneCustomer == null)
            {
                return NotFound(new { Error = $"No customer with phone number:{phoneNumber} was found!" });
            }
            return Ok(phoneCustomer);
        }


        [HttpPost("AddCustomer")]
        public async Task<IActionResult> AddCustomer(CustomerDTO customerDTO)
        {
            try
            {
                await _customerService.AddCustomerAsync(customerDTO);
                return Ok();
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(new { Error = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = "An unexpected error occured" });
            }
        }


        [HttpPut("EditCustomer/{customerId}")]
        public async Task<IActionResult> EditCustomer(CustomerDTO customerDTO, int customerId)
        {
            try
            {
                await _customerService.EditCustomerAsync(customerDTO, customerId);
                return Ok();
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(new { Error = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = "An unexpected error occured" });
            }
        }


        [HttpDelete("DeleteCustomer/{CustomerId}")]
        public async Task<IActionResult> DeletedCustomer(int CustomerId)
        {
            try
            {
                await _customerService.DeleteCustomerAsync(CustomerId);
                return Ok();
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(new { Error = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = "An unexpected error occured" });
            }
        }
    }
}
