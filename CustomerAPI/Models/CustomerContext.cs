using Microsoft.EntityFrameworkCore;

namespace CustomerAPI.Models
{
    //: denotes inheritance, CustomerContext inherits DbContext
    public class CustomerContext : DbContext
    {

        public CustomerContext(DbContextOptions<CustomerContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Customer> Customers { get; set; }

    }
}
