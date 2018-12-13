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
            // Return the plans list
            return _context.Plan.ToList();
        }

        // GET api/plans/id
        [HttpGet("{id}", Name = "GetPlan")]
        public ActionResult<Plan> GetPlan(string id)
        {
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
            // Create the plan with all information
            _context.Plan.Add(plan);
            _context.SaveChanges();

            return Ok();
        }

        // PUT api/plans/id
        [HttpPut("{id}")]
        public ActionResult ModifyPlan(string id, [FromBody]Plan plan)
        {
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
            // Delete the specified plan
            var specifiedPlan = _context.Plan.Find(id);
            if (specifiedPlan == null)
            {
                return NotFound();
            }

            _context.Plan.Remove(specifiedPlan);
            _context.SaveChanges();
            return Ok();
        }
    }
}
