using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AlphaParAPI.Controllers
{
    [Route("api/productionChain")]
    public class ProductionChainsController : Controller
    {
        // GET: api/productionChain
        [HttpGet]
        public ActionResult<List<ProductionChain>> GetProductionChains()
        {
            // Return the production chains list
            return null;
        }

        // GET api/productionChain/id
        [HttpGet("{id}", Name = "ProductionChain")]
        public ActionResult<string> GetProductionChain(string id)
        {
            // Return the specified production chain list
            return "Production Chain";
        }

        // POST api/productionChain
        [HttpPost]
        public ActionResult AddProductionChain(ProductionChain productionChain)
        {
            // Create a production chain with all information
            return null;
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
            return null;
        }
    }

    public class ProductionChain
    {
    }
}
