using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlphaParAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AlphaParAPI.Controllers
{
    [Route("api/customers")]
    public class CustomersController : ControllerBase
    {
        private readonly ModelContext _context;

        public CustomersController(ModelContext context)
        {
            _context = context;
        }

        // GET: api/customers
        [HttpGet("", Name = "GetCustomers")]
        public ActionResult<List<Customer>> GetCustomers()
        {
            // Return the customers list
            return _context.Customer.ToList();
        }

        // GET api/customers/name
        [HttpGet("{name}", Name = "GetCustomer")]
        public ActionResult<Customer> GetCustomer(Customer customer, string name)
        {
            // Return the specified customer
            var specifiedCustomer = _context.Customer.First(x => x.Name == name);

            if (specifiedCustomer == null)
            {
                return NotFound();
            }

            return specifiedCustomer;
        }

        // POST api/customers
        [HttpPost]
        public ActionResult AddCustomer([FromBody]Customer customer)
        {
            // Create a customer with all information
            _context.Customer.Add(customer);
            _context.SaveChanges();

            return Ok();
        }

        // PUT api/customers/id
        [HttpPut("{id}")]
        public ActionResult ModifyCustomer(string id, [FromBody]Customer customer)
        {
            // Update the specified customer
            var specifiedCustomer = _context.Customer.Find(id);
            if (specifiedCustomer == null)
            {
                return NotFound();
            }


            if (customer.Name == null || customer.Phone == null || customer.Siret == null || customer.Email == null)
            {
                return BadRequest();
            }
            else
            {
                specifiedCustomer.Name = customer.Name;
                specifiedCustomer.Siret = customer.Siret;
                specifiedCustomer.Phone = customer.Phone;
                specifiedCustomer.Email = customer.Email;
            }

            _context.Customer.Update(specifiedCustomer);
            _context.SaveChanges();

            return Ok();
        }

        // DELETE api/customers/id
        [HttpDelete("{id}")]
        public IActionResult DeleteCustomer(string id)
        {
            // Delete the specified customer
            var specifiedCustomer = _context.Customer.Find(id);
            if (specifiedCustomer == null)
            {
                return NotFound();
            }

            _context.Customer.Remove(specifiedCustomer);
            _context.SaveChanges();
            return Ok();
        }
    }
}
