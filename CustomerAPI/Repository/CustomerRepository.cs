using CustomerAPI.Models;
using Microsoft.EntityFrameworkCore;
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

        public async Task<IEnumerable<Customer>> Get()
        {
            return await _context.Customers.ToListAsync(); //get all customers as a list
        }

        public async Task<Customer> Get(int id)
        {
            return await _context.Customers.FindAsync(id); //get customer by id
        }

        public async Task Update(Customer customer)
        {
            _context.Entry(customer).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
