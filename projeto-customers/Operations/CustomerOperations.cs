using projeto_customers.Data;
using projeto_customers.Models;

namespace projeto_customers.Operations
{
    public class CustomerOperations
    {
        private DbCustomerContext _context;
        private Customer _customer;


        public CustomerOperations(DbCustomerContext context, Customer customer)
        {
            _context = context;
            _customer = customer;
        }

        public Customer QueryCustomer(string queryCustomer)
        {
            Customer customerResult = _context.Customers
                .FirstOrDefault(customer =>
                customer.Id == int.Parse(queryCustomer) ||
                customer.EmailCustomer == queryCustomer || 
                customer.NameCustomer == queryCustomer);

            if (customerResult != null)
            {
                return customerResult;
            }
            return customerResult;
            
        }

        public bool CreateCustomer(Customer insertCustomer)
        {
            if (insertCustomer != null)
            {
                var resultInsert = _context.Customers.Add(insertCustomer);
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
                queryCustomer.Id = updateCustomer.Id;
                queryCustomer.NameCustomer = updateCustomer.NameCustomer;
                queryCustomer.EmailCustomer = updateCustomer.EmailCustomer;
                queryCustomer.BirthdayCustomer = updateCustomer.BirthdayCustomer;
                queryCustomer.PhoneCustomer = updateCustomer.PhoneCustomer;
                queryCustomer.CellPhoneCustomer = updateCustomer.CellPhoneCustomer;
                queryCustomer.Address = updateCustomer.Address;
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
            var listCustomer = _context.Customers.ToList();

            if (listCustomer != null)
            {
                return listCustomer;
            }
            return listCustomer;


        }
    }
}
