using CustomerAPI.Models;
using CustomerAPI.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {

        private readonly ICustomerRepository _customerRepository;

        public CustomersController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }


        [HttpGet]
        public async Task<IEnumerable<Customer>> GetCustomers() //get all customers
        {
            return await _customerRepository.Get(); //get data from repository
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomersById(int id) //get customer by id
        {
            return await _customerRepository.Get(id);
        }


        [HttpPost]
        public async Task<ActionResult<Customer>> PostCustomers([FromBody] Customer customer) //create customer
        {
            var newCustomer = await _customerRepository.Create(customer);
            return CreatedAtAction(nameof(GetCustomers), new { id = newCustomer.id }, newCustomer);
        }

        [HttpPut]
        public async Task<ActionResult<Customer>> PutCustomers(int id, [FromBody] Customer customer) //update customer
        {
            if (id != customer.id)
            {
                return BadRequest();
            }
            await _customerRepository.Update(customer);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Customer>> DeleteCustomers(int id) //delete a customer by id
        {
            var customerToDelete = await _customerRepository.Get(id);
            if (customerToDelete != null)
            {
                return NotFound();
            }
            await _customerRepository.Delete(customerToDelete.id);
            return NoContent();
        }

    }
}
