using Microsoft.AspNetCore.Mvc;
using projeto_customers.Models;
using projeto_customers.Operations;

namespace projeto_customers.Controllers
{

    [ApiController]
    [Route("[controller]")]

    public class CustomerController: Controller
    {

        private CustomerOperations _customers;

        public CustomerController(CustomerOperations customers)
        {
            _customers = customers; 
        }

        [HttpPost("/insertCustomer")]
        public IActionResult CreateCustomer(Customer insertCustomer)
        {
            if (insertCustomer != null)
            {
                var resultInsert = _customers.CreateCustomer(insertCustomer);
                if (resultInsert)
                {
                    return Ok();
                }
            }
            return NotFound();
        }

        [HttpPut("/updateCustomer/{id}")]
        public IActionResult UpdateCustomer([FromBody] Customer updateCustomer, int id)
        {

            if (updateCustomer != null && id > 0)
            {
                var resultUpdate = _customers.UpdateCustomer(updateCustomer, id);
                if (resultUpdate)
                {
                    return Ok();
                }
            }
            return NotFound();

        }

        [HttpDelete("/deleteCustomer/{id}")]
        public IActionResult DeleteCustomer(int id)
        {
            if (id > 0)
            {
                bool resultDelete = _customers.DeleteCustumer(id);
                if (resultDelete)
                {
                    return Ok();
                }
            }
            return NotFound();

        }

        [HttpGet("/query")]
        public IActionResult QueryCustomer([FromQuery] string queryCustomer)
        {
            if (!string.IsNullOrEmpty(queryCustomer))
            {
                var customerResult = _customers.QueryCustomer(queryCustomer);
                if (customerResult != null)
                {
                    return Ok(customerResult);
                }
            }
            return NotFound();
        }

        [HttpGet("/allCustomer")]
        public IActionResult ListCustomer()
        {
            var listCustomer = _customers.ListCustomer();
            if(listCustomer != null)
            {
                return Ok(listCustomer);
            }
            return NotFound();
        }

    }
}
