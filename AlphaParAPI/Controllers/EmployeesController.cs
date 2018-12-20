using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlphaParAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Serilog;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AlphaParAPI.Controllers
{
    [Route("api/employees")]
    [ApiController]
    [AllowAnonymous]
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
            Log.Warning($"Request to GetEmployees by authentified user {HttpContext.User.Identity.Name}");
            Utils.GetClientMac(this.HttpContext);
            if (!HttpContext.User.Identity.IsAuthenticated)
            {
               // return Forbid();
            }
            // Return the employees list
            return _context.Employee.ToList();
        }

        // GET api/employees/id
        [HttpGet("{id}", Name = "GetEmployee")]
        public ActionResult<Employee> GetEmployee(string id)
        {
            Log.Warning($"Request to GetEmployee {id} by authentified user {HttpContext.User.Identity.Name}");
            Utils.GetClientMac(this.HttpContext);
            if (!HttpContext.User.Identity.IsAuthenticated)
            {
               // return Forbid();
            }
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