using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AlphaParAPI.Controllers
{
    [Route("api/commands")]
    public class CommandsController : Controller
    {
        // GET: api/commands
        [HttpGet]
        public ActionResult<List<Command>> GetCommands()
        {
            // Return the commands list
            return null;
        }

        // GET api/commands/id
        [HttpGet("{id}")]
        public ActionResult<string> GetCommand(string id)
        {
            // Return the specified command
            return "Command";
        }

        // POST api/commands
        [HttpPost]
        public ActionResult AddCommand(Command command)
        {
            // Create a command with all information
            return null;
        }

        // PUT api/commands/id
        [HttpPut("{id}")]
        public ActionResult ModifyCommand(string id, Command command)
        {
            // Update the specified command
            return null;
        }

        // DELETE api/commands/id
        [HttpDelete("{id}")]
        public IActionResult DeleteCommand(string id)
        {
            // Delete the specified command
            return null;
        }
    }

    public class Command
    {
    }
}
