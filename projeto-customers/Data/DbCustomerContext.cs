using Microsoft.EntityFrameworkCore;
using projeto_customers.Models;

namespace projeto_customers.Data
{
    public class DbCustomerContext: DbContext
    {
        public DbCustomerContext(DbContextOptions options):base(options)
        {

        }
        public DbSet<Customer> Customers { get; set; }


    }
}
