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
    [Route("api/productionChain")]
    public class ProductionChainsController : ControllerBase
    {
        private readonly ModelContext _context;

        public ProductionChainsController(ModelContext context)
        {
            _context = context;
        }

        // GET: api/productionChain
        [HttpGet("", Name = "GetProductionChains")]
        public ActionResult<List<ProductionChain>> GetProductionChains()
        {
            // Return the production chains list
            return _context.ProductionChain.ToList();
        }

        // GET api/productionChain/id
        [HttpGet("{id}", Name = "GetProductionChain")]
        public ActionResult<ProductionChain> GetProductionChain(string id)
        {
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
            // Create a production chain with all information
            _context.ProductionChain.Add(productionChain);
            _context.SaveChanges();

            return Ok();
        }

        // PUT api/productionChain/ids
        [HttpPut("{ids}")]
        public IActionResult ModifyProductionChain(string id, [FromBody]ProductionChain productionChain)
        {
            // Update the specified production chain
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
                specifiedProductionChain.PieceProductionChains = productionChain.PieceProductionChains;
            }

            _context.ProductionChain.Update(specifiedProductionChain);
            _context.SaveChanges();

            return Ok();
        }

        // PUT api/piecesToProductionChain/ids
        [HttpPut("{ids}")]
        public IActionResult AddPiecesToProductionChain(List<string> ids)
        {
            // Add pieces to the production chain
            return null;
        }

        // DELETE api/piecesToProductionChain/ids
        [HttpDelete("{ids}")]
        public IActionResult DeletePiecesFromProductionChain(List<string> ids)
        {
            // Delete pieces from the production chain
            return null;
        }

        // DELETE api/productionChain/id
        [HttpDelete("{id}")]
        public IActionResult DeleteProductionChain(string id)
        {
            // Delete the specified production chain
            var specifiedProductionChain = _context.ProductionChain.Find(id);
            if (specifiedProductionChain == null)
            {
                return NotFound();
            }

            _context.ProductionChain.Remove(specifiedProductionChain);
            _context.SaveChanges();
            return Ok();
        }
    }
}
