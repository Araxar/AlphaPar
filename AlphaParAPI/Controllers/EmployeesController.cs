using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AlphaParAPI.Controllers
{

    [Route("api/employees")]
    [ApiController]
    public class EmployeesController : Controller
    {
        // GET: api/employees
        [HttpGet]
        public ActionResult<List<Employee>> GetAll()
        {
            // Return the employees list
            return null;
        }

        // GET api/employees/id
        [HttpGet("{id}")]
        public ActionResult<string> Get(string id)
        {
            // Return the specified employee
            return "Employee";
        }
    }

    public class Employee
    {
    }
}
