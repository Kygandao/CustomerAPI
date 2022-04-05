using CustomerAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomerAPI.Repository
{
    public interface ICustomerRepository //interacts with the DB
    {

        Task<IEnumerable<Customer>> Get(); //get all customers in the system

        Task<Customer> Get(int id); //get customer by id

        Task<Customer> Create(Customer customer); //create new customer entry

        Task Update(Customer customer); //update a customer record

        Task Delete(int id); //delete customer record

    }
}
