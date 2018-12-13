using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AlphaParAPI.Controllers
{
    [Route("api/plans")]
    public class PlansController : Controller
    {
        // GET: api/plans
        [HttpGet]
        public ActionResult<List<Plan>> GetPlans()
        {
            // Return the plans list
            return null;
        }

        // GET api/plans/id
        [HttpGet("{id}")]
        public ActionResult<string> GetPlan(string id)
        {
            // Return the specified plan
            return "Plan";
        }

        // POST api/plans
        [HttpPost]
        public ActionResult AddPlan(Plan plan)
        {
            // Create the plan with all information
            return null;
        }

        // PUT api/plans/id
        [HttpPut("{id}")]
        public ActionResult ModifyPlan(string id, Plan plan)
        {
            // Update the specified plan
            return null;
        }

        // DELETE api/plans/id
        [HttpDelete("{id}")]
        public IActionResult DeletePlan(string id)
        {
            // Delete the specified plan
            return null;
        }
    }

    public class Plan
    {
    }
}
