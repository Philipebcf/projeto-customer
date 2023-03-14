using projeto_customers.Data;
using projeto_customers.Models;

namespace projeto_customers.Operations
{
    public class CustomerOperations
    {
        private DbCustomerContext _context;

        public CustomerOperations(DbCustomerContext context)
        {
            _context = context;
        }

        public Customer QueryCustomer(string queryCustomer)
        {
            
            Customer customerResult = null;
            return customerResult = 
                _context.Customers.FirstOrDefault(customer =>
                customer.EmailCustomer == queryCustomer ||
                customer.NameCustomer == queryCustomer);
            
            
        }

        public bool CreateCustomer(Customer insertCustomer)
        {
            if (insertCustomer != null)
            {
                _context.Customers.Add(insertCustomer);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool UpdateCustomer(Customer updateCustomer, int id)
        {
            var queryCustomer = _context.Customers.Where(customer => customer.Id == id).FirstOrDefault();

            if (queryCustomer != null)
            {
                queryCustomer.Status_Register = updateCustomer.Status_Register;
                _context.Customers.Update(queryCustomer);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool DeleteCustumer(int id)
        {
            var resultDelete = _context.Customers.Where(query => query.Id == id).First();
            if(resultDelete != null)
            {
                _context.Customers.Remove(resultDelete);
                _context.SaveChanges();
                return true;
            }
            return false;

        }

        public List<Customer> ListCustomer()
        {
            return _context.Customers.ToList();            
          
        }
    }
}
