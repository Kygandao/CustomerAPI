using CustomerAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomerAPI.Repository
{
    public class CustomerRepository : ICustomerRepository //inherit interface
    {
        private readonly CustomerContext _context;

        public CustomerRepository(CustomerContext context)
        {
            _context = context;
        }

        public async Task<Customer> Create(Customer customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
            return customer;
        }

        public async Task Delete(int id)
        {
            var customerToDelete = await _context.Customers.FindAsync(id); //first find the entry
            _context.Customers.Remove(customerToDelete); //delete the entry once found
            await _context.SaveChangesAsync();
        }

        public Task<IEnumerable<Customer>> Get()
        {
            throw new System.NotImplementedException();
        }

        public Task<Customer> Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task Update(Customer customer)
        {
            throw new System.NotImplementedException();
        }
    }
}
