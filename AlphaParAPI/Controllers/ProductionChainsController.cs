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
    [Route("api/productionChain")]
    [AllowAnonymous]
    public class ProductionChainsController : ControllerBase
    {
        private readonly ModelContext _context;

        public ProductionChainsController(ModelContext context)
        {
            _context = context;
        }

        // GET: api/productionChain
        [HttpGet("", Name = "GetProductionChains")]
        public ActionResult<IEnumerable<ProductionChain>> GetProductionChains()
        {
            Log.Warning($"Request to GetProductionChains by authentified user {HttpContext.User.Identity.Name}");
            Utils.GetClientMac(this.HttpContext);
            if (!HttpContext.User.Identity.IsAuthenticated)
            {
               // return Forbid();
            }
            // Return the production chains list
            return _context.ProductionChain.ToList();
        }

        // GET api/productionChain/id
        [HttpGet("{id}", Name = "GetProductionChain")]
        public ActionResult<ProductionChain> GetProductionChain(string id)
        {
            Log.Warning($"Request to GetProductionChain {id} by authentified user {HttpContext.User.Identity.Name}");
            Utils.GetClientMac(this.HttpContext);
            if (!HttpContext.User.Identity.IsAuthenticated)
            {
               // return Forbid();
            }
            // Return the specified production chain list
            var specifiedProductionChain = _context.ProductionChain.Find(id);

            if (specifiedProductionChain == null)
            {
                return NotFound();
            }

            return specifiedProductionChain;
        }

        // POST api/productionChain
        [HttpPost]
        public ActionResult AddProductionChain([FromBody]ProductionChain productionChain)
        {
            Log.Warning($"Request to AddProductionChain {productionChain.Id} by authentified user {HttpContext.User.Identity.Name}");
            Utils.GetClientMac(this.HttpContext);
            if (!HttpContext.User.Identity.IsAuthenticated)
            {
              //  return Forbid();
            }
            // Create a production chain with all information
            if (productionChain.Name == null)
            {
                return BadRequest();
            }
            else
            {
                _context.ProductionChain.Add(productionChain);
                _context.SaveChanges();

                return Ok();
            }
        }

        // PUT api/productionChain/ids
        [HttpPut("{id}")]
        public IActionResult ModifyProductionChain(string id, [FromBody]ProductionChain productionChain)
        {
            Log.Warning($"Request to ModifyProductionChain {productionChain.Id} by authentified user {HttpContext.User.Identity.Name}");
            Utils.GetClientMac(this.HttpContext);
            if (!HttpContext.User.Identity.IsAuthenticated)
            {
              //  return Forbid();
            }            // Update the specified production chain
            var specifiedProductionChain = _context.ProductionChain.Find(id);
            if (specifiedProductionChain == null)
            {
                return NotFound();
            }


            if (productionChain.Name == null)
            {
                return BadRequest();
            }
            else
            {
                specifiedProductionChain.Name = productionChain.Name;
            }

            _context.ProductionChain.Update(specifiedProductionChain);
            _context.SaveChanges();

            return Ok();
        }

        // DELETE api/productionChain/id
        [HttpDelete("{id}")]
        public IActionResult DeleteProductionChain(string id)
        {
            Log.Warning($"Request to DeleteProductionChain {id} by authentified user {HttpContext.User.Identity.Name}");
            Utils.GetClientMac(this.HttpContext);
            if (!HttpContext.User.Identity.IsAuthenticated)
            {
               // return Forbid();
            }

            // Delete the specified production chain
            var specifiedProductionChain = _context.ProductionChain.Find(id);
            var ProductionChainExistsInPiece = _context.Piece.Select(x => x.IdProductionChain == id).FirstOrDefault();

            if (specifiedProductionChain == null || ProductionChainExistsInPiece)
            {
                return NotFound();
            }

            _context.ProductionChain.Remove(specifiedProductionChain);
            _context.SaveChanges();
            return Ok();
        }
    }
}