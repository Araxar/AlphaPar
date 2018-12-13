using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AlphaParAPI.Controllers
{
    [Route("api/customers")]
    public class CustomersController : ControllerBase
    {
        // GET: api/customers
        [HttpGet]
        public ActionResult<List<Customer>> GetCustomers()
        {
            // Return the customers list
            return null;
        }

        // GET api/customers/name
        [HttpGet("{name}")]
        public ActionResult<string> GetCustomer(string name)
        {
            // Return the specified customer
            return "Customer";
        }

        // POST api/customers
        [HttpPost]
        public ActionResult AddCustomer(Customer customer)
        {
            // Create a customer with all information
            return null;
        }

        // PUT api/customers/id
        [HttpPut("{id}")]
        public ActionResult ModifyCustomer(string id, Customer customer)
        {
            // Update the specified customer
            return null;
        }

        // DELETE api/customers/id
        [HttpDelete("{id}")]
        public IActionResult DeleteCustomer(string id)
        {
            // Delete the specified customer
            return null;
        }
    }

    public class Customer
    {
    }
}
