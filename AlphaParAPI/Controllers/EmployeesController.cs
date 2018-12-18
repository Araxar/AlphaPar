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

    [Route("api/employees")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly ModelContext _context;

        public EmployeesController(ModelContext context)
        {
            _context = context;
        }

        // GET: api/employees
        [HttpGet("", Name = "GetEmployees")]
        public ActionResult<List<Employee>> GetEmployees()
        {
            // Return the employees list
            return _context.Employee.ToList();
        }

        // GET api/employees/id
        [HttpGet("{id}", Name = "GetEmployee")]
        public ActionResult<Employee> GetEmployee(string id)
        {
            // Return the specified employee
            var specifiedEmployee = _context.Employee.Find(id);

            if (specifiedEmployee == null)
            {
                return NotFound();
            }

            return specifiedEmployee;
        }
    }
}
