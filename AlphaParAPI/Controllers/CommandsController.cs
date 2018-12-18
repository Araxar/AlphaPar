using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlphaParAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Serilog;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AlphaParAPI.Controllers
{
    [Route("api/commands")]
    public class CommandsController : ControllerBase
    {

        private readonly ModelContext _context;

        public CommandsController(ModelContext context)
        {
            _context = context;
        }

        // GET: api/commands
        [HttpGet("", Name = "GetCommands")]
        public ActionResult<List<Command>> GetCommands()
        {
            Log.Warning($"Request to GetCommands by authentified user {HttpContext.User.Identity.Name}");
            Utils.GetClientMac(this.HttpContext);
            if (!HttpContext.User.Identity.IsAuthenticated)
            {
                return Forbid();
            }
            // Return the commands list
            return _context.Command.Include(x => x.Customer).Include(x => x.Plan).ToList();
        }

        // GET api/commands/id
        [HttpGet("{id}", Name = "GetCommand")]
        public ActionResult<Command> GetCommand(string id)
        {
            Log.Warning($"Request to GetCommand {id} by authentified user {HttpContext.User.Identity.Name}");
            Utils.GetClientMac(this.HttpContext);
            if (!HttpContext.User.Identity.IsAuthenticated)
            {
                return Forbid();
            }
            // Return the specified command
            var specifiedCommand = _context.Command.Find(id);

            if (specifiedCommand == null)
            {
                return NotFound();
            }

            return specifiedCommand;
        }

        // POST api/commands
        [HttpPost]
        public ActionResult AddCommand([FromBody]Command command)
        {
            Log.Warning($"Request to AddCommand {command.Id} by authentified user {HttpContext.User.Identity.Name}");
            Utils.GetClientMac(this.HttpContext);
            if (!HttpContext.User.Identity.IsAuthenticated)
            {
                return Forbid();
            }
            // Create a command with all information
            var specifiedPlan = _context.Plan.Find(command.IdPlan);
            var specifiedCustomer = _context.Customer.Find(command.IdCustomer);

            if (specifiedPlan == null || specifiedCustomer == null || command.IdCustomer == null || command.IdPlan == null || command.DeliveryDate == null)
            {
                return BadRequest();
            }
            else
            {
                _context.Command.Add(command);
                _context.SaveChanges();

                return Ok();
            }
        }

        // PUT api/commands/id
        [HttpPut("{id}")]
        public ActionResult ModifyCommand(string id, [FromBody]Command command)
        {
            Log.Warning($"Request to ModifyCommand {command.Id} by authentified user {HttpContext.User.Identity.Name}");
            Utils.GetClientMac(this.HttpContext);
            if (!HttpContext.User.Identity.IsAuthenticated)
            {
                return Forbid();
            }
            // Update the specified command
            var specifiedCommand = _context.Command.Find(id);
            if (specifiedCommand == null)
            {
                return NotFound();
            }


            if (command.IdCustomer == null || command.IdPlan == null || command.DeliveryDate == null)
            {
                return BadRequest();
            }
            else
            {
                specifiedCommand.IdCustomer = command.IdCustomer;
                specifiedCommand.IdPlan = command.IdPlan;
                specifiedCommand.Customer = command.Customer;
                specifiedCommand.Plan = command.Plan;
                specifiedCommand.PlanAmount = command.PlanAmount;
                specifiedCommand.DeliveryDate = command.DeliveryDate;
            }

            _context.Command.Update(specifiedCommand);
            _context.SaveChanges();

            return Ok();
        }

        // DELETE api/commands/id
        [HttpDelete("{id}")]
        public IActionResult DeleteCommand(string id)
        {
            Log.Warning($"Request to DeleteCommand {id} by authentified user {HttpContext.User.Identity.Name}");
            Utils.GetClientMac(this.HttpContext);
            if (!HttpContext.User.Identity.IsAuthenticated)
            {
                return Forbid();
            }
            // Delete the specified command
            var specifiedCommand = _context.Command.Find(id);
            if (specifiedCommand == null)
            {
                return NotFound();
            }

            _context.Command.Remove(specifiedCommand);
            _context.SaveChanges();
            return Ok();
        }
    }
}
