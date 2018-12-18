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
    [Route("api/plans")]
    public class PlansController : ControllerBase
    {
        private readonly ModelContext _context;

        public PlansController(ModelContext context)
        {
            _context = context;
        }

        // GET: api/plans
        [HttpGet("", Name = "GetPlans")]
        public ActionResult<List<Plan>> GetPlans()
        {
            Log.Warning($"Request to GetPlans by authentified user {HttpContext.User.Identity.Name}");
            Utils.GetClientMac(this.HttpContext);
            if (!HttpContext.User.Identity.IsAuthenticated)
            {
                return Forbid();
            }
            // Return the plans list
            return _context.Plan.ToList();
        }

        // GET api/plans/id
        [HttpGet("{id}", Name = "GetPlan")]
        public ActionResult<Plan> GetPlan(string id)
        {
            Log.Warning($"Request to GetPlan {id} by authentified user {HttpContext.User.Identity.Name}");
            Utils.GetClientMac(this.HttpContext);
            if (!HttpContext.User.Identity.IsAuthenticated)
            {
                return Forbid();
            }
            // Return the specified plan
            var specifiedPlan = _context.Plan.Find(id);

            if (specifiedPlan == null)
            {
                return NotFound();
            }

            return specifiedPlan;
        }

        // POST api/plans
        [HttpPost]
        public ActionResult AddPlan([FromBody]Plan plan)
        {
            Log.Warning($"Request to AddPlan {plan.Id} by authentified user {HttpContext.User.Identity.Name}");
            Utils.GetClientMac(this.HttpContext);
            if (!HttpContext.User.Identity.IsAuthenticated)
            {
                return Forbid();
            }
            // Create the plan with all information
            var specifiedPiece = _context.Piece.Find(plan.IdPiece);

            if (specifiedPiece == null || plan.Name == null || plan.IdPiece == null || plan.Time == null)
            {
                return NotFound();
            }
            else
            {
                _context.Plan.Add(plan);
                _context.SaveChanges();

                return Ok();
            }
        }

        // PUT api/plans/id
        [HttpPut("{id}")]
        public ActionResult ModifyPlan(string id, [FromBody]Plan plan)
        {
            Log.Warning($"Request to ModifyPlan {plan.Id} by authentified user {HttpContext.User.Identity.Name}");
            Utils.GetClientMac(this.HttpContext);
            if (!HttpContext.User.Identity.IsAuthenticated)
            {
                return Forbid();
            }
            // Update the specified plan
            var specifiedPlan = _context.Plan.Find(id);
            if (specifiedPlan == null)
            {
                return NotFound();
            }


            if (plan.Name == null || plan.IdPiece == null || plan.Time == null)
            {
                return BadRequest();
            }
            else
            {
                specifiedPlan.Name = plan.Name;
                specifiedPlan.IdPiece = plan.IdPiece;
                specifiedPlan.Time = plan.Time;
                specifiedPlan.Piece = plan.Piece;
            }

            _context.Plan.Update(specifiedPlan);
            _context.SaveChanges();

            return Ok();
        }

        // DELETE api/plans/id
        [HttpDelete("{id}")]
        public IActionResult DeletePlan(string id)
        {
            Log.Warning($"Request to DeletePlan {id} by authentified user {HttpContext.User.Identity.Name}");
            Utils.GetClientMac(this.HttpContext);
            if (!HttpContext.User.Identity.IsAuthenticated)
            {
                return Forbid();
            }
            // Delete the specified plan
            var specifiedPlan = _context.Plan.Find(id);
            var PlanExistsInCommand = _context.Command.Select(x => x.IdPlan == id).FirstOrDefault();

            if (specifiedPlan == null || PlanExistsInCommand)
            {
                return NotFound();
            }

            _context.Plan.Remove(specifiedPlan);
            _context.SaveChanges();
            return Ok();
        }
    }
}
